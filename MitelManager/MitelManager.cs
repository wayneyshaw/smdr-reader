//Mitel SMDR Reader
//Copyright (C) 2013 Insight4 Pty. Ltd. and Nicholas Evan Roberts

//This program is free software; you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation; either version 2 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License along
//with this program; if not, write to the Free Software Foundation, Inc.,
//51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using MiSMDR.DataAccessLayer;
using MiSMDR.Logger;
using MiSMDR.DBIntegrity;

namespace MiSMDR.MitelManager
{
    /// <summary>
    /// The MitleManager class is used to connect (telnet) to the Mitel system and retrieve
    /// any new data. Note: Once a connection is made to the Mitel system (whether or not
    /// data retrieval was successful), the Mitel system will clear its database.
    /// </summary>
    public class MiManager
    {
        Socket s = null;
        NetworkStream ns = null;

        string _connectionString = String.Empty; // internal conn string variable
        DataProvider _provider; // the database provider
        string _dataLogFilePath = String.Empty; // the text-based log file

        private string _server = ""; // the Mitel server
        private int _port = -1; // the port to use to connect to the Mitel server

        private int _callCount = 0;
        public string canConnectToMitel { get; set; }
        private bool _connectionSuccess = false;

        private int formatID = 0; //this will be set when the first piece of information is parsed and unset when the user disconnects from a server
        private CallFormat miCallFormat; // this class holds all the current format information

        /*
         * A thread is used to control the data retrieval because there is no way to terminate the
         * connection to the Mitel server (no EndOfStream / EndOfFile exists). Although the 
         * thread does not terminate the connection in a safe manner, the Mitel system recovers
         * from this termination without any problems.
         */ 
        Thread workerThread = null;

        // This event is used to alert MiForm when a connection has been made to the Mitel system
        public event EventHandler MitelConnected; 

        /* Initialise the class variables and set the log file connection string
         */ 
        public MiManager(string connString, DataProvider provider, string dataLogFilePath)
        {
            _connectionString = connString;
            _provider = provider;
            _dataLogFilePath = dataLogFilePath;
            LogManager.SetConnectionString(connString,_provider);

            //When the MiManager is created it does a check on the DB to make sure all the required tables are there
            DBControl control = new DBControl(connString, provider);
            if (!control.CheckDataAccess()) control.CreateTables();
        }

        public void Setup(string connString, DataProvider provider, string dataLogFilePath)
        {
            _connectionString = connString;
            _provider = provider;
            _dataLogFilePath = dataLogFilePath;
            LogManager.SetConnectionString(connString, _provider);
        }

        /* Attempt to connect to ther server on the specified server/port.
         * An AsyncCallBack delegate is used to return focus to the ConnectSocket method
         */ 
        public string Connect(string server, int port)
        {
            _server = server;
            _port = port;

            // Create a new socket connection with the specified server and port
            if (!IsConnected())
            {
                AsyncCallback callback = new AsyncCallback(ConnectSocket);
                Dns.BeginGetHostEntry(server, callback, server);

                return "Connecting";
            }
            else
            {
                return "Already connected";
            }
            
        }

        /*
         * End the host entry (performs the required functionality) when the asynchronous
         * operation (connection) completes. Retrieve the address list from the returned results
         * (stored in HostEntry) and attempt to connect to the address (there should only be one)
         * in the address list.
         */ 
        private void ConnectSocket(IAsyncResult result)
        {   
            try
            {
                // Get the results
                IPHostEntry hostEntry = Dns.EndGetHostEntry(result);

                if (hostEntry != null)
                {
                    foreach (IPAddress address in hostEntry.AddressList)
                    {
                        // Represent the network endpoint using an IP address and a port number
                        IPEndPoint ipe = new IPEndPoint(address, _port);

                        // Create a new TCP socket 
                        Socket tempSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                        try
                        {
                            // Attempt to connect to the specified address
                            tempSocket.Connect(ipe);
                        }
                        catch (SocketException ex)
                        {
                            // Log any errors that occur
                            LogManager.Log(LogEntryType.Error, SourceType.MitelDataCollection, "Error occurred for server: " + _server + " on port: " + _port.ToString() + ", " + ex.Message);
                        }

                        if (tempSocket.Connected)
                        {
                            // Set the class socket variable
                            s = tempSocket;

                            Connected = true;

                            // Create a new thread and set it to handle the data received from the
                            // Mitel system
                            ThreadStart threadStart = new ThreadStart(this.ThreadReceive);
                            workerThread = new Thread(threadStart);
                            workerThread.Start();

                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    s = null;
                    Connected = false;
                }

            }
            // Store the exception message.
            catch (SocketException)
            {
                s = null;
                Connected = false;
            }
            finally
            {
            }
        }

        /*
         * This method is required because the ThreadStart method requires a method with a
         * void return value.
         */ 
        public void ThreadReceive()
        {
            string error = Receive();
            WriteToLog(error);
        }

        /*
         * While the thread is still active, retrieve any new data from the Mitel database.
         */ 
        public string Receive()
        {
            if (s != null)
            {
                if (s.Connected)
                {
                    // Create a new NetworkStream and StreamReader to handle the pathway and
                    // data handling between the Mitel system and MiSMDR
                    ns = new NetworkStream(s, true);
                    StreamReader reader = new StreamReader(ns);

                    try
                    {
                        // The EndOfStream will never occur, but the thread will be aborted when
                        // the program exits. This means that only one computer should have
                        // MiSMDR installed at any one time!
                        while (!reader.EndOfStream)
                        {
                            // Read the line of data
                            string data = reader.ReadLine();
                            // Log the line of data for analysis purposes
                            WriteToDataLog(data);
                            // Parse the data and write it to the MiSMDR database
                            SmartParseString(data);
                            // Increment the call counter
                            _callCount++;
                        }
                    }
                    catch (Exception)
                    {
                        // An error has occurred, so disconnect from the Mitel system
                        Disconnect();
                    }
                    // maybe needs to be true?
                    return "Data received.";
                }
                else
                {
                    return "Could not receive data, not connected to server.";
                }
            }
            else
            {
                return "Could not receive data, not connected to server.";
            }
        }

        /*
         * This method determines if MiSMDR is connected to the Mitel system.
         * If no connection exists, it creates a new event handler that will relay information
         * back to the MiForm class to display to the user.
         */ 
        public bool Connected
        {
            get { return this._connectionSuccess; }
            set
            {
                this._connectionSuccess = value;
                if (this.MitelConnected != null)
                    this.MitelConnected(this, new EventArgs());
            }
        }


        /// <summary>
        /// Write data to the Mitel log file (txt)
        /// </summary>
        /// <param name="data">The data to write to the log file</param>
        private void WriteToDataLog(string data)
        {
            if (!String.IsNullOrEmpty(_dataLogFilePath))
            {
                StreamWriter logFile = new StreamWriter(new FileStream(_dataLogFilePath, FileMode.Append));
                logFile.WriteLine(data);
                logFile.Flush();
                logFile.Close();
            }
            else
            {
                // No log file path - alert user and display Settings screen
            }
        }

        /*
         * Parse the incoming data into a database-friendly format
         */ 
        public int SmartParseString(string data)
        {
            try
            {
                string source = "";
                string type = "";
                string direction = "";

                if (formatID == 0)
                {
                    miCallFormat = new CallFormat();
                    using (IDBManager managerHardware = new DBManager(_provider, _connectionString))
                    {

                        managerHardware.Open();

                        string sqlCommand = @"SELECT MH.Name,MH.Version, MF.ID, MS.StartPosition, MS.EndPosition, MF.Name AS FieldName, MH.ID
                                                FROM MiSMDRSeparations MS
                                                INNER JOIN MiSMDRFields MF ON MF.ID = MS.FieldID
                                                INNER JOIN MiSMDRHardware MH ON MH.ID = MS.HardwareID
                                                WHERE
                                                SUBSTR('" + data + @"',(MH.StartPosition+1),(MH.EndPosition-MH.StartPosition)+1) REGEXP MH.DefiningRegex
                                                ";

                        IDataReader myReader = managerHardware.ExecuteReader(CommandType.Text, sqlCommand);
                        int count = 0;
                        
                        while (myReader.Read())
                        {
                            source = myReader.GetValue(0).ToString()+ " " + myReader.GetValue(1).ToString();
                            

                            //Loop through each Field
                            count = count + 1;
                            switch (Convert.ToInt32(myReader.GetValue(2)))
                            {
                                case 1: //CallDate
                                    miCallFormat.date[0] = Convert.ToInt32(myReader.GetValue(3));
                                    miCallFormat.date[1] = Convert.ToInt32(myReader.GetValue(4));
                                    break;
                                case 2: //Duration
                                    miCallFormat.time[0] = Convert.ToInt32(myReader.GetValue(3));
                                    miCallFormat.time[1] = Convert.ToInt32(myReader.GetValue(4));
                                    break;
                                case 3: //CallerExtension
                                    miCallFormat.callerExtension[0] = Convert.ToInt32(myReader.GetValue(3));
                                    miCallFormat.callerExtension[1] = Convert.ToInt32(myReader.GetValue(4));
                                    break;
                                case 4: //AnswerTime
                                    miCallFormat.timeToAnswer[0] = Convert.ToInt32(myReader.GetValue(3));
                                    miCallFormat.timeToAnswer[1] = Convert.ToInt32(myReader.GetValue(4));
                                    break;
                                case 5: //Digits Dialled
                                    miCallFormat.dialledExtension[0] = Convert.ToInt32(myReader.GetValue(3));
                                    miCallFormat.dialledExtension[1] = Convert.ToInt32(myReader.GetValue(4));
                                    break;
                                case 6: //receiverExtension
                                    miCallFormat.receiverExtension[0] = Convert.ToInt32(myReader.GetValue(3));
                                    miCallFormat.receiverExtension[1] = Convert.ToInt32(myReader.GetValue(4));
                                    break;
                                case 7: //External Caller
                                    miCallFormat.callerExternal[0] = Convert.ToInt32(myReader.GetValue(3));
                                    miCallFormat.callerExternal[1] = Convert.ToInt32(myReader.GetValue(4));
                                    formatID = Convert.ToInt32(myReader.GetValue(6));
                                    break;
                            }
                        }
                        managerHardware.CloseReader();
                        if (count < 1)
                        {
                            // We do not have entries that match the format
                            WriteToLog("Error: Unable to parse data because there is not matching Hardware Format (Please contact MiSMDR Support) \n");
                        }
                    }
                }

                /*
                //WriteToLog(LogEntryType.Information,"data Length: " + data.Length);
                // Iterate through the columns and retrieve the required data
                int index = 1; // The start index is 1 because the first character in the data is not required

                int date = 12, time = 10, callerExtension = 7, timeToAnswer = 4, dialledExtension = 25, type = 1
                    , receiverExtension = 4, rawData = 38, callerExternal = 12;

                // date, time, callerExtension, timeToAnswer, dialledExtension, type, receiverExtension, callerExternal
                int[] columnLengths = { date, time, callerExtension, timeToAnswer, dialledExtension, type, receiverExtension, rawData, callerExternal };


                StringCollection values = new StringCollection();
                for (int i = 0; i < columnLengths.Length; i++)
                {

                    values.Add(data.Substring(index, columnLengths[i]).Trim());
                    index = index + columnLengths[i] + 1;
                }*/


                using (IDBManager managerHardware = new DBManager(_provider, _connectionString))
                {
                    managerHardware.Open();
                    string sqlCommand = @"SELECT MT.Name
                                        FROM MiSMDRTypes MT
                                        INNER JOIN MiSMDRTypeRegex MTR ON  MTR.TypeID = MT.ID
                                        WHERE
                                        MTR.HardwareID = " + formatID + @" AND '" + data + @"' REGEXP MTR.Regex
                                        ";

                    IDataReader myReader = managerHardware.ExecuteReader(CommandType.Text, sqlCommand);
                    while (myReader.Read())
                    {
                        direction = myReader.GetValue(0).ToString(); // get the Type Name
                    }
                    managerHardware.CloseReader();
                }
                if (direction == "Internal") type = "Internal";
                else type = "External";

                StringCollection values = new StringCollection();
                //values[0] is date
                values.Add(data.Substring(miCallFormat.date[0], miCallFormat.date[1] - miCallFormat.date[0]+1).Trim());
                //values[1] is time
                values.Add(data.Substring(miCallFormat.time[0], miCallFormat.time[1] - miCallFormat.time[0]+1).Trim());
                //values[2] is internal caller extension
                values.Add(data.Substring(miCallFormat.callerExtension[0], miCallFormat.callerExtension[1] - miCallFormat.callerExtension[0]+1).Trim());
                //values[3] is time before call was answered
                values.Add(data.Substring(miCallFormat.timeToAnswer[0], miCallFormat.timeToAnswer[1] - miCallFormat.timeToAnswer[0]+1).Trim());
                //values[4] is the extension dialled
                values.Add(data.Substring(miCallFormat.dialledExtension[0], miCallFormat.dialledExtension[1] - miCallFormat.dialledExtension[0] + 1).Trim().Replace("#","").Replace("*",""));
                //values[5] is the type of call
                values.Add(type);
                //values[6] is the incoming receiver extension - just get the first receiver extension if there is a space seperated list
                values.Add(data.Substring(miCallFormat.receiverExtension[0], miCallFormat.receiverExtension[1] - miCallFormat.receiverExtension[0] + 1).Trim());
                //values[7] is the raw string data
                values.Add(data.Substring(0, data.Length-1).Trim());
                //values[8] is the external caller - just get the first caller external number if there is a space seperated list
                if (miCallFormat.callerExternal[1] < data.Length)
                {
                    values.Add(data.Substring(miCallFormat.callerExternal[0], miCallFormat.callerExternal[1] - miCallFormat.callerExternal[0] + 1).Trim());
                }
                else values.Add(""); //add blank value for external caller if the ANI columns are not included in the SDMR output

                //append the year to the date
                StringBuilder sb = new StringBuilder(DateTime.Now.Year.ToString());
                sb.Append("/");
                sb.Append(values[0]);
                values[0] = sb.ToString().Replace("A"," AM").Replace("P"," PM");
                values[0] = Convert.ToDateTime(values[0]).ToString("yyyy-MM-dd HH:mm:ss");

                //Make the Answer Time into 0000:00:00 format OR **** if unanswered
                string answerTime = values[3];
                if (answerTime.Length > 0)
                {
                    if ((answerTime != "****") && (answerTime != "***")) //different lengths of unanswered in Mitel 3300 Standard and MS Format
                    {
                        //if not unanswered then convert to 0000:00:00 format
                        int answerTimeInt = Convert.ToInt32(answerTime);
                        TimeSpan ts = new TimeSpan(0, 0, answerTimeInt);
                        values[3] = ts.ToString();
                    }
                    else values[3] = "****";
                }

                /* Remove references to the CallerExtension in the DialledExtension, ReceiverExt and ExternalCaller */
                values[4] = values[4].Replace(values[2] + " ", "");
                //values[7] = values[7].Replace(values[3] + " ", "");
                //if (values.Count>9) values[9] = values[9].Replace(values[3] + " ", "");

                // date, time, callerExtension, TimeToAnswer, dialledExtension, type, receiverExtension, rawData(unused data), caller (if external), direction
                return WriteToDB(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], direction, "");
            }
            catch (Exception ex)
            {
                WriteToLog("Error parsing Mitel data\n Error Details: "+ex.ToString()+"\n\n Data: " + data);
                return 0; //report unknown error
            }
        }

        /// <summary>
        /// Write the data to the database
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="callerExtension"></param>
        /// <param name="timeToAnswer"></param>
        /// <param name="dialledExtension"></param>
        /// <param name="type"></param>
        /// <param name="receiverExtension"></param>
        /// <param name="callerExternal"></param>
        /// <param name="direction"></param>
        /// <param name="rawType"></param>
        protected int WriteToDB(string date, string time, string callerExtension, string timeToAnswer, string dialledExtension, string type, string receiverExtension, string rawData, string callerExternal, string direction, string rawType)
        {
            DBManager manager = new DBManager(_provider, _connectionString);

            try
            {
                manager.Open();
                // Setup the parameter list
                manager.CreateParameters(11);
                // Setup the date to be in the correct format
                DateTime d = Convert.ToDateTime(date);
                // Add the parameters to the list
                manager.AddParameters(0, "@CallDate", d.ToString("yyyy-MM-dd HH:mm:ss"));
                manager.AddParameters(1, "@Duration", time);
                manager.AddParameters(2, "@CallerExtension", callerExtension);
                manager.AddParameters(3, "@TimeToAnswer", timeToAnswer);
                manager.AddParameters(4, "@DialledExtension", dialledExtension);
                manager.AddParameters(5, "@Type", type);
                manager.AddParameters(6, "@ReceiverExtension", receiverExtension);
                manager.AddParameters(7, "@CallerExternal", callerExternal);
                manager.AddParameters(8, "@Direction", direction);
                manager.AddParameters(9, "@RawData", rawData);
                manager.AddParameters(10, "@RawType", rawType);
                //Add different sources here for future development

                string insertQuery = "INSERT INTO [Calls] ([CallDate], [Duration], [CallerExtension], [TimeToAnswer], [DialledExtension], [Type], [ReceiverExtension], [CallerExternal], [Direction], [RawData], [RawType], [Source]) VALUES (@CallDate, @Duration, @CallerExtension, @TimeToAnswer, @DialledExtension, @Type, @ReceiverExtension, @CallerExternal, @Direction, @RawData, @RawType, 'Mitel3300')";

                manager.ExecuteNonQuery(CommandType.Text, insertQuery);

                manager.Dispose();
                return 1; // report success
            }
            catch (Exception ex)
            {
                WriteToLog("Error adding data to database: " + date + ", " + time + ", " + callerExtension + ", " + timeToAnswer + ", " + dialledExtension + ", " + type + ", " + receiverExtension + ", " + callerExternal + "," + direction + ", " + rawData + ", " + rawType + ", " + "Mitel3300" + ". Error Message: " + ex.Message);
                manager.Dispose();
                if (ex.Message.Contains("constraint violation")) return -1; //report that a UNIQUE constraint has been broken
                else return 0; // report unknown error
            }
        }

        /*
         * Write the input data string to the log file
         */ 
        protected void WriteToLog(string logMsg)
        {
            LogManager.Log(LogEntryType.Error, SourceType.MitelDataCollection, logMsg);
        }

        protected void WriteToLog(LogEntryType type, string logMsg)
        {
            LogManager.Log(type, SourceType.MitelDataCollection, logMsg);
        }

        /*
         * Returns a boolean indicating if MiSMDR is connected to the Mitel system
         */ 
        public bool IsConnected()
        {
            if (s != null)
            {
                return s.Connected;
            }
            return false;
        }

        /*
         * Disconnect from the Mitel system by aborting the thread that is used to handle
         * the retrieval of data from the Mitel system. Also, disconnect the Mitel socket.
         */ 
        public string Disconnect()
        {
            if (workerThread != null)
            {
                if (workerThread.ThreadState == ThreadState.Running)
                {
                    workerThread.Abort();
                }
            }
            if (s != null)
            {
                if(s.Connected)
                    s.Disconnect(false);
                s = null;
            }
            if (ns != null)
            {
                ns.Close();
            }
            _connectionSuccess = false;
            
            formatID = 0; // this unsets the formatID just in case there are multiple ICPs with different formats we are connecting to!

            return "Disconnected from server";
        }

        /*
         * The Call Counter is used to display the number of calls retrieved from the Mitel
         * database in the last x seconds (60 seconds by default)
         */ 
        public Int32 CallCount
        {
            get
            {
                int c = _callCount;
                _callCount = 0;
                return c;
            }
            
        }

        private class CallFormat
        {
            // Class to store the Call Format information
            public int[] date = new int[2];
            public int[] time = new int[2];
            public int[] callerExtension = new int[2];
            public int[] timeToAnswer = new int[2];
            public int[] dialledExtension = new int[2];
            public int[] type = new int[2];
            public int[] receiverExtension = new int[2];
            public int[] rawData = new int[2];
            public int[] callerExternal = new int[2];
        }
    }
}
