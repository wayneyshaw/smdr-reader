//Mitel SMDR Reader
//Copyright (C) 2013  Insight4 Pty. Ltd. and Nicholas Evan Roberts

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
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using MiSMDR.DataAccessLayer;
using MiSMDR.Logger;
using MiSMDR.DBIntegrity;

namespace MiSMDR.BusinessLogicLayer
{
    public class CallManager
    {
        public List<caller> Callers { get; set; }
        public Dictionary<string, string> Receivers { get; set; }
        public TimeSpan TotalDuration { get; set; }
        public double TotalCost { get; set; }
        public int Internals { get; set; }
        public int Externals { get; set; }
        public int Outgoings { get; set; }
        public int Incomings { get; set; }
        public int Unanswered { get; set; }
        public DataSet Calls { get; set; }
        public DataTable test { get; set; }

        private string searchQuery = "";

        private string _callDate = "";
        private string _endDate = "";

        private string _duration = "";
        private string _durationCombo = "";
        private string _timeToAnswer = "";
        private string _timeToAnswerCombo = "";

        private string _callType = "";
        private string _direction = "";

        private string _callerName = "";
        private string _callerNumber = "";
        private string _callerExtension = "";
        private string _dialledExtension = "";
        private string _receiverName = "";
        private string _receiverNumber = "";
        private string _receiverExtension = "";

        // added v1.1.1 for new simplified search screen
        private string _callerExact = "";
        private string _receiverExact = "";

        private string _connectionString;
        private DataProvider _provider;

        //Testable vars
        private bool _searchContainsDate;
        private bool _searchContainsDateRange;


        public CallManager() { }

        public CallManager(string connString, DataProvider prov)
        {
            _connectionString = connString;
            _provider = prov;

            DBControl control = new DBControl(connString, prov);
            if (!control.CheckDataAccess()) control.CreateTables();
        }

        #region Setup
        // Advanced Search
        public List<ValidationError> CreateConnection(string startDate, string endDate, string callDirection, string duration, string durationCombo, string timeToAnswer, string timeToAnswerCombo, string callerIdentifier, string callerExact, string receiverIdentifier, string receiverExact, string dialledNumber, int recordLimit, string connectionString, DataProvider provider)
        {
            _connectionString = connectionString;
            _provider = provider;
            List<ValidationError> errors = new List<ValidationError>();

            try
            {
                // Attempt to parse the parameters, storing any errors in the errorList variable
                errors = ParseParameters(startDate, endDate, callDirection, duration, durationCombo, timeToAnswer, timeToAnswerCombo, callerIdentifier, callerExact, receiverIdentifier, receiverExact, dialledNumber);

                // If there were no errors parsing the user input, calculate the statistical data
                if (errors.Count == 0)
                {
                    // Assign the class variables their values
                    searchQuery = GetSearchQuery();// Create the search query
                    Callers = GetCallers(searchQuery + " LIMIT " + recordLimit.ToString());
                    Receivers = GetReceivers(searchQuery + " LIMIT " + recordLimit.ToString());
                    TotalCost = GetTotalCost(searchQuery + " LIMIT " + recordLimit.ToString());
                    TotalDuration = GetTotalDuration(searchQuery + " LIMIT " + recordLimit.ToString());
                    Internals = GetInternals(searchQuery + " LIMIT " + recordLimit.ToString());
                    Externals = GetExternals(searchQuery + " LIMIT " + recordLimit.ToString());
                    Outgoings = GetOutgoings(searchQuery + " LIMIT " + recordLimit.ToString());
                    Incomings = GetIncomings(searchQuery + " LIMIT " + recordLimit.ToString());
                    Unanswered = GetUnanswered(searchQuery + " LIMIT " + recordLimit.ToString());
                    Calls = GetDataSet(searchQuery + " ORDER BY [Call Date] DESC LIMIT " + recordLimit.ToString());
                }
            }
            catch (Exception ex)
            {
                errors.Add(new ValidationError("Unexpected Error: " + ex.ToString().Replace('\'', '"')));
            }
            return errors;
        }

        private List<ValidationError> ParseParameters(string startDate, string endDate, string callDirection, string duration, string durationCombo, string timeToAnswer, string timeToAnswerCombo, string callerIdentifier, string callerExact, string receiverIdentifier, string receiverExact, string dialledNumber)
        {
            List<ValidationError> errors = new List<ValidationError>();

            // Variables that do not require strict conversion of their values
            _dialledExtension = dialledNumber; // cannot be number because sometimes it has spaces
            _callerExact = callerExact;
            _receiverExact = receiverExact;

            // These values are no longer is needed for the search
            _callType = "";

            // Direction conversion
            if ((callDirection == "Incoming") || (callDirection == "Outgoing") || (callDirection == "Internal"))
            {
                _direction = callDirection;
            }
            else
            {
                _direction = "";
            }

            //Caller identifier conversion to database equivalents
            try
            {
                long Num;
                if (long.TryParse(callerIdentifier,out Num))
                {
                    //these numbers are searched for using an OR statement
                    _callerNumber = callerIdentifier;
                    _callerExtension = callerIdentifier;
                }
                else
                {
                    //if it is not a number then we can assume we are search for a name
                    _callerName = callerIdentifier;
                }
            }
            catch (Exception ex)
            {
                errors.Add(new ValidationError("Unexpected Error: " + ex.ToString()));
                errors.Add(new ValidationError("Problem occured when searching for caller name/number"));
            }

            //Caller identifier conversion to database equivalents
            try
            {
                long Num;
                if (long.TryParse(receiverIdentifier,out Num))
                {
                    //these numbers are searched for using an OR statement
                    _receiverNumber = receiverIdentifier;
                    _receiverExtension = receiverIdentifier;
                }
                else
                {
                    //if it is not a number then we can assume we are search for a name
                    _receiverName = receiverIdentifier;
                }
            }
            catch (Exception ex)
            {
                errors.Add(new ValidationError("Unexpected Error: "+ex.ToString()));
                errors.Add(new ValidationError("Problem occured when searching for receiver name/number"));
            }

            // Date Conversions
            try
            {
                _searchContainsDate = false;
                DateTimeFormatInfo dtfo = new CultureInfo(CultureInfo.CurrentCulture.ToString(), true).DateTimeFormat;
                if (startDate != String.Empty)
                {
                    DateTime cDate = Convert.ToDateTime(startDate, dtfo);
                    _callDate = cDate.ToString("yyyy-MM-dd");
                    _searchContainsDate = true;
                }
                else
                {
                    _callDate = startDate;
                }
            }
            catch
            {
                errors.Add(new ValidationError("Date " + startDate + " is not a valid Date for culture " + CultureInfo.CurrentCulture.ToString()));
            }

            try
            {
                _searchContainsDateRange = false;
                DateTimeFormatInfo dtfo = new CultureInfo(CultureInfo.CurrentCulture.ToString(), true).DateTimeFormat;
                if (endDate != String.Empty)
                {
                    DateTime cDate = Convert.ToDateTime(endDate, dtfo);
                    _endDate = cDate.ToString("yyyy-MM-dd");
                    _searchContainsDateRange = true;
                }
                else
                {
                    _endDate = endDate;
                }
            }
            catch
            {
                errors.Add(new ValidationError("Date " + endDate + " is not a valid Date for culture " + CultureInfo.CurrentCulture.ToString()));
            }

            // TimeToAnswer conversion
            try
            {
                //String comparison works if the formatting is kept very strict
                _timeToAnswerCombo = "";

                if ((timeToAnswer != String.Empty) && (timeToAnswer != "****"))
                {
                    string part1 = ""; // hh
                    string part2 = ""; // mm
                    string part3 = ""; // ss
                    string allParts = ""; // hh:mm:ss - the format accepted by the database

                    string[] splitTimes = timeToAnswer.Split(':');

                    if (splitTimes.Length == 3)
                    {
                        part1 = splitTimes[0].PadLeft(2, '0');
                        part2 = splitTimes[1].PadLeft(2, '0');
                        part3 = splitTimes[2].PadLeft(2, '0');
                    }
                    else if (splitTimes.Length == 2)
                    {
                        part1 = "00";
                        part2 = splitTimes[0].PadLeft(2, '0');
                        part3 = splitTimes[1].PadLeft(2, '0');
                    }
                    else if (splitTimes.Length == 1)
                    {
                        part1 = "00";
                        part2 = "00";
                        part3 = splitTimes[0].PadLeft(2, '0');
                    }
                    else
                    {
                        errors.Add(new ValidationError("Answer Time should be in hh:mm:ss format"));
                    }

                    //check part1, part2 and part3 values now they are padded

                    if (Convert.ToInt32(part1) <= 99)
                    {
                        if (Convert.ToInt32(part2) <= 59)
                        {
                            if (Convert.ToInt32(part3) <= 59)
                            {
                                allParts = "'" + part1 + ":" + part2 + ":" + part3 + "'";

                                if (timeToAnswerCombo == "greater than") _timeToAnswerCombo = ">="; // only set combo box if there is a valid and in-range numbers
                                else if (timeToAnswerCombo == "less than") _timeToAnswerCombo = "<=";
                            }
                            else
                            {
                                errors.Add(new ValidationError("Time To Answer Error: There cannot be more than 59 seconds in the seconds field"));
                            }
                        }
                        else
                        {
                            errors.Add(new ValidationError("Time To Answer Error: There cannot be more than 59 minutes in the minutes field"));
                        }
                    }
                    else
                    {
                        errors.Add(new ValidationError("Time To Answer Error: There cannot be more than 99 hours in the hours field"));
                    }
                    _timeToAnswer = allParts;
                }
                else if (timeToAnswer == "****")
                {
                    _timeToAnswer = "'****'";
                    _timeToAnswerCombo = "=";
                }
            }
            catch (Exception ex)
            {
                errors.Add(new ValidationError("Unexpected Error: " + ex.ToString()));
                errors.Add(new ValidationError("Time To Answer value must be in hh:mm:ss format"));
            }

            // Duration conversion
            try
            {
                //String comparison works if the formatting is kept very strict
                _durationCombo = "";
                if (duration != String.Empty)
                {
                    string part1 = ""; // hh
                    string part2 = ""; // mm
                    string part3 = ""; // ss
                    string allParts = ""; // hh:mm:ss - the format accepted by the database

                    string[] splitTimes = duration.Split(':');

                    if (splitTimes.Length == 3)
                    {
                        part1 = splitTimes[0].PadLeft(2, '0');
                        part2 = splitTimes[1].PadLeft(2, '0');
                        part3 = splitTimes[2].PadLeft(2, '0');
                    }
                    else if (splitTimes.Length == 2)
                    {
                        part1 = "00";
                        part2 = splitTimes[0].PadLeft(2, '0');
                        part3 = splitTimes[1].PadLeft(2, '0');
                    }
                    else if (splitTimes.Length == 1)
                    {
                        part1 = "00";
                        part2 = "00";
                        part3 = splitTimes[0].PadLeft(2, '0');
                    }
                    else
                    {
                        errors.Add(new ValidationError("Duration should be in a hh:mm:ss format"));
                    }

                    //check part1, part2 and part3 values now they are padded
                    if (Convert.ToInt32(part1) <= 99)
                    {
                        if (Convert.ToInt32(part2) <= 59)
                        {
                            if (Convert.ToInt32(part3) <= 59)
                            {
                                allParts = "'" + part1 + ":" + part2 + ":" + part3 + "'";

                                if (durationCombo == "greater than") _durationCombo = ">="; // only set combo box if there is a valid number
                                else if (durationCombo == "less than") _durationCombo = "<=";
                            }
                            else
                            {
                                errors.Add(new ValidationError("Duration Error: There cannot be more than 59 seconds in the seconds field"));
                            }
                        }
                        else
                        {
                            errors.Add(new ValidationError("Duration Error: There cannot be more than 59 minutes in the minutes field"));
                        }
                    }
                    else
                    {
                        errors.Add(new ValidationError("Duration Error: There cannot be more than 99 hours in the hours field"));
                    }
                    _duration = allParts;
                }
            }
            catch(Exception ex)
            {
                errors.Add(new ValidationError("Unexpected Error: "+ex.ToString()));
                errors.Add(new ValidationError("Duration value must be in hh:mm:ss format"));
            }

            // Return the error list as a string array
            return errors;
        }

        public DataSet GetDataSet(string commandText)
        {
            using(IDBManager manager = new DBManager(_provider,_connectionString))
            {
                manager.Open();
                return manager.ExecuteDataSet(CommandType.Text, commandText);
            }
        }

        #endregion

        #region Query Strings

        /// <summary>
        /// This method is used internally to get the search query to be used to generate the statistical data such as number
        /// of internal / external calls, total costs, etc
        /// </summary>
        /// <returns>The 'Advanced Search' query string to use in the calculation of the statistical data</returns>
        private string GetSearchQuery()
        {
            //CONVERT(datetime, CallDate, 103)
            string query = @"
                SELECT
                *
                FROM
                newSearch AS All_Data
                ";
            //string query = "SELECT * FROM ( SELECT Phone_Data.[CallDate] AS [Call Date], Phone_Data.[Duration] AS [Duration], Callers.[Name] AS [Caller Name], Phone_Data.[CallerExtension] AS [Caller Extension], Phone_Data.[TimeToAnswer], Phone_Data.[DialledExtension] AS [Dialled Extension], Phone_Data.[Type], Receivers.Name AS [Receiver Name], Phone_Data.[ReceiverExtension] AS [Receiver Extension], Phone_Data.[CallerExternal] AS [Caller (if external conversation)], Phone_Data.[Direction] AS [Direction] FROM [Phone_Data] LEFT JOIN [User] AS Callers ON Phone_Data.[CallerExtension] = Callers.[Extension] LEFT JOIN [User] AS Receivers ON Phone_Data.[ReceiverExtension] = Receivers.[Extension]) as All_Data ";

            ArrayList result = GenerateWhereString();


            if (_searchContainsDate)
            {
                if (_searchContainsDateRange)
                {
                    DateTime startdate = new DateTime();
                    DateTime enddate = new DateTime();
                    startdate = Convert.ToDateTime(_callDate);
                    enddate = Convert.ToDateTime(_endDate);
                    if (_provider == DataProvider.SqlServer)
                    {
                        string startDateValue = startdate.ToString("dd-MM-yyyy");
                        string endDateValue = enddate.ToString("dd-MM-yyyy");
                        query += "WHERE Convert(datetime, All_Data.[Call Date], 103) BETWEEN Convert(datetime,'" + startDateValue + "',103) AND Convert(datetime,'" + endDateValue + "',103)+1 "; // added 1 so it is inclusive
                    }
                    else if (_provider == DataProvider.Sqlite)
                    {
                        string startDateValue = startdate.ToString("yyyy-MM-dd");
                        string endDateValue = enddate.ToString("yyyy-MM-dd");
                        query += @"WHERE julianday(All_Data.[Call Date]) > julianday('" + startDateValue + "') AND julianday(All_Data.[Call Date]) < (julianday('" + endDateValue + "')+1) ";
                    }
                }
                else
                {
                    DateTime date = new DateTime();
                    date = Convert.ToDateTime(_callDate);
                    if (_provider == DataProvider.SqlServer)
                    {
                        string dateValue = date.ToString("dd-MM-yyyy");
                        query += "WHERE datediff(day,Convert(datetime, All_Data.[Call Date], 103), Convert(datetime,'" + dateValue + "',103)) = 0 ";
                    }
                    else if (_provider == DataProvider.Sqlite)
                    {
                        string dateValue = date.ToString("yyyy-MM-dd");
                        query += "WHERE (julianday(All_Data.[Call Date]) - julianday('" + dateValue + "')) > 0 AND (julianday(All_Data.[Call Date]) - julianday('" + dateValue + "')) < 1 ";
                    }
                }
            }
            else
            {
                query += "WHERE 1 = 1 "; // make sure the WHERE clause appears in the query
            }
            if (_durationCombo != String.Empty)
            {
                query += "AND [Duration] " + _durationCombo + " " + _duration + " ";
            }
            if (_timeToAnswerCombo != String.Empty)
            {
                query += "AND [Time To Answer] " + _timeToAnswerCombo + " " + _timeToAnswer + " ";
            }

            string likeOrEquals = "="; // default is equals, which will speed up the query
            if (_callerExact != String.Empty) likeOrEquals = "LIKE";

            if (_callerName != String.Empty)
            {
                query += "AND All_Data.[Caller Name] "+likeOrEquals+" '" + _callerExact + _callerName + _callerExact + "' ";
            }
            else if ((_callerNumber != String.Empty) || (_callerExtension != String.Empty))
            {
                query += "AND (All_Data.[Caller Number] "+likeOrEquals+" '" + _callerExact + _callerNumber + _callerExact + "' ";
                query += "OR All_Data.[Caller Extension] "+likeOrEquals+" '" + _callerExact + _callerExtension + _callerExact + "') ";
            }

            likeOrEquals = "="; // default is equals, which will speed up the query
            if (_receiverExact != String.Empty) likeOrEquals = "LIKE";

            if (_receiverName != String.Empty)
            {
                query += "AND All_Data.[Receiver Name] "+likeOrEquals+" '" + _receiverExact + _receiverName + _receiverExact + "' ";
            }
            else if ((_receiverNumber != String.Empty) || (_receiverExtension != String.Empty))
            {
                query += "AND (All_Data.[Receiver Number] "+likeOrEquals+" '" + _receiverExact + _receiverNumber + _receiverExact + "' ";
                query += "OR All_Data.[Receiver Extension] "+likeOrEquals+" '" + _receiverExact + _receiverExtension + _receiverExact + "') ";
            }

            //Now process the string queries
            for (int i = 0; i < result.Count; i++)
            {
                string[] valuePair = result[i] as string[];
                query += "AND " + valuePair[0] + " LIKE '%" + valuePair[1] + "%' ";
            }
            return query;

        }

        /// <summary>
        /// This method generates the where string using a list of the database field names and the user input values
        /// </summary>
        /// <returns>An arraylist of string arrays that each contain a field name and value, respectively</returns>
        private ArrayList GenerateWhereString()
        {
            string[] fields = { "All_Data.[Type]", "All_Data.[Direction]",  "All_Data.[Dialled Extension]"  };
            string[] values = { _callType.ToString(), _direction.ToString(), _dialledExtension.ToString() };


            ArrayList returnList = new ArrayList();

            for (int i = 0; i < fields.Length; i++)
            {
                if (values[i] != String.Empty)
                {
                    // column name, value
                    string[] valuePair = { fields[i], values[i] };
                    returnList.Add(valuePair);
                }
            }
            return returnList;
        }
        #endregion

        #region Statistical Data

        // Get all unique caller names
        public List<caller> GetCallers(string query)
        {
            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();

                string searchQuery = "SELECT DISTINCT Callers.[Caller Number], Callers.[Caller Name] FROM (" + query + ") AS Callers WHERE Callers.[Direction] = 'Outgoing' AND Callers.[Duration] > '00:00:00' ORDER BY Callers.[Caller Name]";

                IDataReader reader = manager.ExecuteReader(CommandType.Text, searchQuery);

                List<caller> callers = new List<caller>();

                while (reader.Read())
                {
                    string callNumber = reader.GetValue(0).ToString();
                    string callName = reader.GetValue(1).ToString();
                    if (callName == String.Empty) callName = "Unknown";
                    callers.Add(new caller(callName, callNumber));
                }
                manager.CloseReader();
                return callers;
            }
        }

        // Get all unique receiver names
        public Dictionary<string, string> GetReceivers(string query)
        {
            using(IDBManager manager = new DBManager(_provider,_connectionString))
            {
                manager.Open();
                string searchQuery = "SELECT DISTINCT Receivers.[Receiver Number], Receivers.[Receiver Name] FROM (" + query + ") AS Receivers WHERE Receivers.[Direction] = 'Outgoing' AND Receivers.[Duration] > '00:00:00' ORDER BY Receivers.[Receiver Name]";
                IDataReader reader = manager.ExecuteReader(CommandType.Text, searchQuery);
                Dictionary<string, string> receivers = new Dictionary<string, string>();

                while (reader.Read())
                {
                    string recNumber = reader.GetValue(0).ToString();
                    string recName = reader.GetValue(1).ToString();
                    if (recName == String.Empty) recName = "Unknown";
                    receivers.Add(recNumber,recName);
                }
                manager.CloseReader();
                return receivers;
            }
        }

        /// <summary>
        /// Gets the total costs for each call category in the database
        /// e.g. Mobile, local, international
        /// 
        /// This is achieved by matching each phone number to a specific regular expression and retrieving cost and block size information
        /// for the given match that is used to calculate the cost for each phone call (using the duration).
        /// The costs for each category are incremented each time a regular expression match occurs.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns>A dictionary containing key of type string (the cost name/description) and a value of type double (the cost value)</returns>
        /// 
        /*
        public Dictionary<string, double> GetCosts(string query)
        {
            ArrayList categories = new ArrayList();
            categories = GetCallCategories(categories);

            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();
                string searchQuery = "";
                if (_provider == DataProvider.SqlServer)
                {
                    searchQuery = "SELECT CostData.[Duration], CostData.[Dialled Extension] FROM (" + query + ") AS CostData WHERE CostData.[Type] LIKE '%External%' AND SUBSTRING(CostData.[Caller Extension], 1, 1) != 'T' AND CostData.[Duration] IS NOT NULL AND CostData.[Duration] != ''";
                }
                else if (_provider == DataProvider.Sqlite)
                {
                    searchQuery = "SELECT CostData.[Duration], CostData.[Dialled Extension] FROM (" + query + ") AS CostData WHERE CostData.[Type] LIKE '%External%' AND SUBSTR(CostData.[Caller Extension], 1, 1) != 'T' AND CostData.[Duration] IS NOT NULL AND CostData.[Duration] != ''";
                }

                IDataReader costsReader = manager.ExecuteReader(CommandType.Text, searchQuery);

                while (costsReader.Read())
                {
                    string numberToMatch = costsReader.GetValue(1).ToString(); // Called Number

                    for (int i = 0; i < categories.Count; i++)
                    {
                        // Create a temporary RegexHolder
                        CallCategory category = (CallCategory)categories[i];

                        if (category.RegularExpression.IsMatch(numberToMatch))
                        {
                            // Get the duration from the reader
                            string duration = costsReader.GetValue(0).ToString();

                            // Calculate the cost of the call based on the duration, cost per block and the block size
                            double newTotal = calculateCosts(duration, category.Cost, category.BlockSize);
                            if (newTotal != -1)
                            {
                                category.Total += newTotal;
                            }
                            else
                            {
                                throw new Exception("Error occurred when calculating total cost for " + category.Name);
                            }

                            // Add the connection cost
                            category.Total += (category.ConnectionCost / 100); // divide by 100 to give the amount in dollars
                            categories[i] = category;
                            break;
                        }
                    }
                }

                // Add the name / total of each category to a new Dictionary<string, double> object and return the object
                Dictionary<string, double> categoryData = new Dictionary<string, double>();
                foreach (CallCategory c in categories)
                {
                    categoryData.Add(c.Name, c.Total);
                }

                manager.CloseReader();
                WriteCallCostsToDB(categoryData);
                return categoryData;
            }
        }
         * */

        private void WriteCallCostsToDB(Dictionary<string, double> costs)
        {
            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();
                // Clear Temp_Costs table
                manager.ExecuteNonQuery(CommandType.Text, "DELETE FROM Temp_Costs");

                // Insert new values into table
                foreach (string name in costs.Keys)
                {
                    string query = "INSERT INTO Temp_Costs(CallCategory, Cost) VALUES ('" + name + "', " + costs[name] + ")";
                    manager.ExecuteNonQuery(CommandType.Text, query);
                }
            }
        }

        /// <summary>
        /// Sums all the category costs and returns the total value
        /// </summary>
        /// <returns>The total of all the call category costs</returns>
        private double GetTotalCost(string query)
        {
            string searchQuery = "SELECT SUM([Cost]) FROM ("+query+") WHERE [Direction] = 'Outgoing'";

            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();
                
                IDataReader reader = manager.ExecuteReader(CommandType.Text, searchQuery);

                string costSum = "0.0";
                while (reader.Read())
                {
                    if(reader.GetValue(0).ToString() != String.Empty) costSum = reader.GetValue(0).ToString();
                }
                return Convert.ToDouble(costSum);
            }
        }

        /// <summary>
        /// Retrieves a list of call categories (mobile, local, etc) stored in the database
        /// </summary>
        /// <returns>Returns a CallCategory object that contains each of the call categories</returns>
        private ArrayList GetCallCategories(ArrayList categories)
        {
            ArrayList tempCategories = new ArrayList();

            using(IDBManager manager = new DBManager(_provider,_connectionString))
            {
                manager.Open();
                IDataReader categoriesReader = manager.ExecuteReader(CommandType.Text, "SELECT [Regular Expression], [Block Size], [Cost], [Name], [Connection Cost] FROM [CallCategory]");

                while (categoriesReader.Read())
                {
                    CallCategory category = new CallCategory(_connectionString,_provider);
                    string reg = categoriesReader.GetValue(0).ToString();
                    Regex regExp = new Regex(reg);
                    category.RegularExpression = regExp;
                    category.BlockSize = Convert.ToInt32(categoriesReader.GetValue(1));
                    category.Cost = Convert.ToInt32(categoriesReader.GetValue(2));
                    category.Name = categoriesReader.GetValue(3).ToString();
                    category.ConnectionCost = Convert.ToInt32(categoriesReader.GetValue(4));
                    tempCategories.Add(category);
                }
                manager.CloseReader();
            }
            return tempCategories;
        }

        public double GetCallCost(string callDate, string duration, string callerNumber, string receiverNumber)
        {
            // Fix date into database format
            DateTimeFormatInfo dtfo = new CultureInfo(CultureInfo.CurrentCulture.ToString(), true).DateTimeFormat;
            if (callDate != String.Empty)
            {
                DateTime cDate = Convert.ToDateTime(callDate, dtfo);
                callDate = cDate.ToString("yyyy-MM-dd");
            }

            string query =@"
            SELECT
                *
                FROM
                    (
                    SELECT * FROM newSearch
                    ) AS All_Data
            WHERE (julianday(All_Data.[Call Date]) - julianday('" + callDate + @"')) > 0 AND (julianday(All_Data.[Call Date]) - julianday('" + callDate + @"')) < 1 AND
                  All_Data.[Duration] = '" + duration + @"' AND
                  All_Data.[Caller Number] = '" + callerNumber + @"' AND
                  All_Data.[Receiver Number] = '" + receiverNumber + "'";

            ArrayList categories = new ArrayList();
            categories = GetCallCategories(categories);

            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();
                string searchQuery = "";
                if (_provider == DataProvider.SqlServer)
                {
                    searchQuery = "SELECT CostData.[Duration], CostData.[Dialled Extension] FROM (" + query + ") AS CostData WHERE SUBSTRING(CostData.[Caller Extension], 1, 1) != 'T'";
                }
                else if (_provider == DataProvider.Sqlite)
                {
                    searchQuery = "SELECT CostData.[Duration], CostData.[Dialled Extension] FROM (" + query + ") AS CostData WHERE SUBSTR(CostData.[Caller Extension], 1, 1) != 'T'";
                }

                IDataReader costsReader = manager.ExecuteReader(CommandType.Text, searchQuery);

                while (costsReader.Read())
                {
                    string numberToMatch = costsReader.GetValue(1).ToString(); // Called Number

                    for (int i = 0; i < categories.Count; i++)
                    {
                        // Create a temporary RegexHolder
                        CallCategory category = (CallCategory)categories[i];

                        if (category.RegularExpression.IsMatch(numberToMatch))
                        {
                            // Get the duration from the reader
                            string thisduration = costsReader.GetValue(0).ToString();
                            // Calculate the cost of the call based on the duration, cost per block and the block size
                            double newTotal = calculateCosts(thisduration, category.Cost, category.BlockSize);
                            return newTotal;
                        }
                    }
                }
                return 0.0;
            }
        }
        /// <summary>
        /// Calculates the cost for the given duration of phone conversation for the matching category's block size and cost per block
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="cost"></param>
        /// <param name="block"></param>
        /// <returns></returns>
        private double calculateCosts(string duration, double cost, int block)
        {
            string[] split = duration.Split(':');
            try
            {
                int hours = Convert.ToInt32(split[0]);
                int minutes = Convert.ToInt32(split[1]);
                int seconds = Convert.ToInt32(split[2]);

                TimeSpan ts = new TimeSpan(0, hours, minutes, seconds, 0);

                double numblocksAsDouble = ts.TotalSeconds / block;

                int numblocks = (int)(Math.Ceiling(numblocksAsDouble));
                return ((numblocks * cost) / 100); // divide by 100 to give the amount in dollars
            }
            catch (DivideByZeroException)
            {
                // block = 0, which is not allowed
                throw new Exception("The call cost block specified is 0. This is not allowed. Please change the block size on the 'Call Costs' tab");
            }
            catch (Exception)
            {
                //Invalid duration format
                throw new Exception("The format of the duration information in the database does not match the required format by MiSMDR");
            }
        }

        // Get the number of internal calls
        public int GetInternals(string query)
        {
            string searchQuery = "SELECT COUNT(*) FROM (" + query + ") AS Calls WHERE [Direction] = 'Internal'";
            
            using(IDBManager manager = new DBManager(_provider,_connectionString))
            {
                manager.Open();
                return Convert.ToInt32(manager.ExecuteScalar(CommandType.Text, searchQuery));
            }
        }

        // Get the number of Outgoing calls
        public int GetOutgoings(string query)
        {
            string searchQuery = "SELECT COUNT(*) FROM (" + query + ") AS Calls WHERE [Direction] = 'Outgoing'";

            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();
                return Convert.ToInt32(manager.ExecuteScalar(CommandType.Text, searchQuery));
            }
        }

        // Get the number of Incoming calls
        public int GetIncomings(string query)
        {
            string searchQuery = "SELECT COUNT(*) FROM (" + query + ") AS Calls WHERE [Direction] = 'Incoming'";

            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();
                return Convert.ToInt32(manager.ExecuteScalar(CommandType.Text, searchQuery));
            }
        }

        // Get the number of Unanswered calls
        public int GetUnanswered(string query)
        {
            string searchQuery = "SELECT COUNT(*) FROM (" + query + ") AS Calls WHERE Calls.[Time to Answer] = '****'";

            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();
                return Convert.ToInt32(manager.ExecuteScalar(CommandType.Text, searchQuery));
            }
        }

        // Get the number of internal calls
        public int GetExternals(string query)
        {
            string searchQuery = "SELECT COUNT(Externals.[Type]) FROM (" + query + ") AS Externals WHERE Externals.[Type] = 'External'";
            
            using(IDBManager manager = new DBManager(_provider,_connectionString))
            {
                manager.Open();
                return Convert.ToInt32(manager.ExecuteScalar(CommandType.Text, searchQuery));
            }
        }

        // Get the number of internal calls
        public TimeSpan GetTalkTime(string direction)
        {
            string tsearchQuery = "SELECT DurationData.[Duration] FROM (" + searchQuery + ") AS DurationData WHERE [DurationData].[Direction] = '"+direction+"'";

            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();
                IDataReader durationReader = manager.ExecuteReader(CommandType.Text, tsearchQuery);

                //ArrayList durationStrings = new ArrayList();
                TimeSpan total = new TimeSpan();

                if (durationReader != null)
                {
                    while (durationReader.Read())
                    {
                        string s = durationReader.GetValue(0).ToString();
                        if (s.Trim() != String.Empty)
                        {
                            string[] split = s.Split(':');
                            int hours = 0;
                            int minutes = 0;
                            int seconds = 0;

                            hours = Convert.ToInt32(split[0]);
                            minutes = Convert.ToInt32(split[1]);
                            seconds = Convert.ToInt32(split[2]);

                            TimeSpan ts = new TimeSpan(0, hours, minutes, seconds, 0);
                            total += ts;
                        }
                    }
                }
                /*
                ArrayList durations = new ArrayList();
                foreach (string s in durationStrings)
                {
                    if (s.Trim() != String.Empty)
                    {
                        string[] split = s.Split(':');
                        int hours = 0;
                        int minutes = 0;
                        int seconds = 0;


                        hours = Convert.ToInt32(split[0]);
                        minutes = Convert.ToInt32(split[1]);
                        seconds = Convert.ToInt32(split[2]);


                        TimeSpan ts = new TimeSpan(0, hours, minutes, seconds, 0);

                        durations.Add(ts);
                    }
                }
                // Determine the total calls duration
                TimeSpan total = new TimeSpan();
                foreach (TimeSpan t in durations)
                {
                    total += t;
                }*/
                manager.CloseReader();
                return total;
            }
        }

        // Get the total call duration
        public TimeSpan GetTotalDuration(string query)
        {
            string searchQuery = "SELECT DurationData.[Duration] FROM (" + query + ") AS DurationData";

            using(IDBManager manager = new DBManager(_provider,_connectionString))
            {
                manager.Open();
                IDataReader durationReader = manager.ExecuteReader(CommandType.Text, searchQuery);
                TimeSpan total = new TimeSpan();

                if (durationReader != null)
                {
                    while (durationReader.Read())
                    {
                        string s = durationReader.GetValue(0).ToString();
                        if (s.Trim() != String.Empty)
                        {
                            string[] split = s.Split(':');
                            int hours = 0;
                            int minutes = 0;
                            int seconds = 0;

                            hours = Convert.ToInt32(split[0]);
                            minutes = Convert.ToInt32(split[1]);
                            seconds = Convert.ToInt32(split[2]);

                            TimeSpan ts = new TimeSpan(0, hours, minutes, seconds, 0);
                            total += ts;
                        }
                    }
                }

                manager.CloseReader();
                return total;
            }
        }
        //Call Summary methods
        public List<callObject> GetCallList(caller thisCaller)
        {
            List<callObject> callList = new List<callObject>();

            string searchQuery = "SELECT [Call Date],[Duration],[Receiver Name],[Dialled Extension] FROM newSearch AS Calls WHERE [Direction] = 'Outgoing' AND [Caller Number]='"+thisCaller.callerNumber+"'";

            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();
                IDataReader callReader = manager.ExecuteReader(CommandType.Text, searchQuery);
                if (callReader != null)
                {
                    string callerName = thisCaller.callerName;
                    string callerNumber = thisCaller.callerNumber;

                    while (callReader.Read())
                    {
                        string callDate = callReader.GetValue(0).ToString();
                        string duration = callReader.GetValue(1).ToString();
                        string receiverName = callReader.GetValue(2).ToString();
                        if (receiverName == String.Empty) receiverName = "Unknown";
                        string receiverNumber = callReader.GetValue(3).ToString();

                        string cost = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol + GetCallCost(callDate, duration, callerNumber, receiverNumber).ToString();
                        callList.Add(new callObject(callDate,receiverName,receiverNumber,duration,cost));
                    }
                }
            }
            return callList;
        }
        public string GetTotalCallerCost(caller thisCaller)
        {
            string searchQuery = "SELECT SUM([Cost]) FROM newSearch WHERE [Caller Number] = '" + thisCaller.callerNumber + "' AND [Direction] = 'Outgoing'";
            
            using(IDBManager manager = new DBManager(_provider,_connectionString))
            {
                manager.Open();
                IDataReader reader = manager.ExecuteReader(CommandType.Text, searchQuery);

                string costSum = "0.0";
                while (reader.Read())
                {
                    costSum = reader.GetValue(0).ToString();
                }
                return costSum;
            }
        }
        #endregion
    }
    public class caller
    {
        public string callerName;
        public string callerNumber;
        public caller(string IcallerName, string IcallerNumber)
        {
            callerName = IcallerName;
            callerNumber = IcallerNumber;
        }
    }
    public class callObject
    {
        public string date;
        public string receiverName;
        public string receiverNumber;
        public string duration;
        public string cost;

        public callObject(string Idate, string IreceiverName, string IreceiverNumber, string Iduration, string Icost)
        {
            date = Idate;
            receiverName = IreceiverName;
            receiverNumber = IreceiverNumber;
            duration = Iduration;
            cost = Icost;
        }
    }
}
