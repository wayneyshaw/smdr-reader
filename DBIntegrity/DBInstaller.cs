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
using System.Text;
using MiSMDR.DataAccessLayer;
using MiSMDR.Logger;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Threading;

namespace MiSMDR.DBIntegrity
{
    public class DBInstaller
    {
        private string _connectionString;
        private DataProvider _provider;
        IList<externalNumber> externalNumberPrefix = new List<externalNumber>();
        string internalNumberPrefix = "";

        public DBInstaller(string connectionString, DataProvider provider)
        {
            _connectionString = connectionString;
            _provider = provider;

            #region Number Prefixes

            if (CultureInfo.CurrentCulture.Name == "pt-PT")
            {
                internalNumberPrefix = "30";

                externalNumberPrefix.Add(new externalNumber("6141","Vodafone Mobile"));
                externalNumberPrefix.Add(new externalNumber("6129","NSW Landline"));
                externalNumberPrefix.Add(new externalNumber("042","Optus Mobile"));
                externalNumberPrefix.Add(new externalNumber("039","Victoria Landline"));
                externalNumberPrefix.Add(new externalNumber("6142","Optus Mobile"));
                externalNumberPrefix.Add(new externalNumber("041","Vodafone Mobile"));
                externalNumberPrefix.Add(new externalNumber("029","Sydney Landline"));
                externalNumberPrefix.Add(new externalNumber("040","Telstra Mobile"));
                externalNumberPrefix.Add(new externalNumber("036","Tasmania Landline"));
                externalNumberPrefix.Add(new externalNumber("6140","Telstra Mobile"));
            }
            else
            {
                internalNumberPrefix = "10";

                externalNumberPrefix.Add(new externalNumber("212","New York"));
                externalNumberPrefix.Add(new externalNumber("1213","California"));
                externalNumberPrefix.Add(new externalNumber("253","Washington"));
                externalNumberPrefix.Add(new externalNumber("415","California"));
                externalNumberPrefix.Add(new externalNumber("1800","Toll free numbers"));
                externalNumberPrefix.Add(new externalNumber("1900","Custom charge numbers"));
                externalNumberPrefix.Add(new externalNumber("818","California"));
                externalNumberPrefix.Add(new externalNumber("747","California"));
                externalNumberPrefix.Add(new externalNumber("914","New York"));
                externalNumberPrefix.Add(new externalNumber("203","Connecticut"));
            }
            #endregion
        }

        public string CreateDatabase()
        {
            if (_provider == DataProvider.SqlServer)
            {
                ArrayList errors = new ArrayList();
                DBManager manager = new DBManager(_provider, _connectionString);

                try
                {
                    manager.Open();
                    string sqlCommand = @"
                    --no sqlserver database code to create               
                    ";
                    Regex regex = new Regex("GO", RegexOptions.None);
                    string[] sqlCommands = regex.Split(sqlCommand);

                    foreach (string command in sqlCommands)
                    {
                        manager.ExecuteNonQuery(CommandType.Text, command);
                    }
                }
                catch (Exception ex)
                {
                    LogManager.Log(LogEntryType.Error, SourceType.DBIntegrity, "Could not install DB: " + ex.Message);
                    return ex.ToString(); // return error
                }
                manager.Dispose();
                return "SqlServer install worked";
            }
            else if (_provider == DataProvider.Sqlite)
            {
                ArrayList errors = new ArrayList();
                DBManager manager = new DBManager(_provider, _connectionString);

                try
                {
                    manager.Open();
                    //run useless command to check that the database is accessible and create it if neccessary
                    string sqlCommand = @"SELECT 1";
                    Regex regex = new Regex("GO", RegexOptions.None);
                    string[] sqlCommands = regex.Split(sqlCommand);

                    foreach (string command in sqlCommands)
                    {
                        manager.ExecuteNonQuery(CommandType.Text, command);
                    }
                }
                catch (Exception ex)
                {
                    return "Sqlite install failed.";
                }
                return "Sqlite Install worked";
            }
            return "DB Type not supported";
        }
        public string CreateTables()
        {
            //create the tables
            if (_provider == DataProvider.Sqlite)
            {
                ArrayList errors = new ArrayList();
                DBManager manager = new DBManager(_provider, _connectionString);

                try
                {
                    manager.Open();

                    string sqlCommand = @"
                    DROP TABLE IF EXISTS [Versions];
                    DROP TABLE IF EXISTS [CallCategory];
                    DROP TABLE IF EXISTS [Calls];
                    DROP TABLE IF EXISTS [Numbers];
                    DROP TABLE IF EXISTS [Logs];
                    DROP TABLE IF EXISTS [MitelInformation];
                    DROP TABLE IF EXISTS [People];
                    DROP TABLE IF EXISTS [SavedSearchObjects];
                    DROP TABLE IF EXISTS [SavedSearches];
                    DROP TABLE IF EXISTS [Temp_Costs];

                    DROP VIEW IF EXISTS [Contacts];
                    DROP VIEW IF EXISTS [allNumbers];
                    DROP VIEW IF EXISTS [CallsAndCosts];
                    DROP VIEW IF EXISTS [newSearch];

                    CREATE TABLE [Versions] (
                    [Part]	varchar(150) COLLATE NOCASE,
                    [Version] varchar(20) COLLATE NOCASE
                    );

                    CREATE TABLE [CallCategory] (
                    [ID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [Regular Expression]	varchar(150) COLLATE NOCASE,
                    [Name]	varchar(50) COLLATE NOCASE,
                    [Connection Cost]	numeric,
                    [Block Size]	integer,
                    [Cost]	varchar(50) COLLATE NOCASE,
                    [Type] varchar(20) COLLATE NOCASE,
                    [Priority] char(2) COLLATE NOCASE,
                    [Charge Unfinished] char(1) COLLATE NOCASE
                    );
                    CREATE  INDEX [regeg] ON [CallCategory] ([Regular Expression] ASC);

                    CREATE TABLE [Calls] (
                    [ID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [CallDate]	datetime,
                    [Duration]	nvarchar(50) COLLATE NOCASE,
                    [CallerExtension]	nvarchar(50) COLLATE NOCASE,
                    [TimeToAnswer]	nvarchar(50) COLLATE NOCASE,
                    [DialledExtension]	nvarchar(50) COLLATE NOCASE,
                    [Type]	char(10) COLLATE NOCASE,
                    [ReceiverExtension]	nvarchar(50) COLLATE NOCASE,
                    [CallerExternal]	nvarchar(50) COLLATE NOCASE,
                    [Direction]	nvarchar(50) COLLATE NOCASE,
                    [RawData]	nvarchar COLLATE NOCASE,
                    [RawType]	char(1) COLLATE NOCASE,
                    [Source]    nvarchar(50) COLLATE NOCASE
                    );
                    CREATE INDEX [idx_direction] ON [Calls] ([Direction] ASC);
                    CREATE INDEX [idx_caller] ON [Calls] ([CallerExtension] ASC, [CallerExternal] ASC);
                    CREATE INDEX [idx_receiver] ON [Calls] ([DialledExtension] ASC, [ReceiverExtension] ASC);
                    CREATE UNIQUE INDEX [idx_callcluster] ON [Calls] ([CallDate] DESC,[CallerExtension] ASC,[DialledExtension] ASC,[ReceiverExtension] ASC,[CallerExternal] ASC,[Duration] ASC);


                    CREATE TABLE [Logs] (
                    [LogDate]	datetime,
                    [Source]	nvarchar(50) COLLATE NOCASE,
                    [Message]	nvarchar COLLATE NOCASE,
                    [LogEntryType]	nvarchar(50) COLLATE NOCASE
                    );

                    CREATE TABLE [MitelInformation] (
                    [LastConnected]	nvarchar(50) COLLATE NOCASE
                    );

                    CREATE TABLE [People] (
                    [ID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [Name]	varchar(100) COLLATE NOCASE,
                    [Description]	varchar(100) COLLATE NOCASE,
                    [Email]	varchar(100) COLLATE NOCASE
                    );

                    CREATE  INDEX [peoplename] ON [People] ([Name] ASC);

                    CREATE TABLE [SavedSearchObjects] (
                    [SavedSearchID]	INTEGER NOT NULL,
                    [Name]	varchar(50) NOT NULL COLLATE NOCASE,
                    [Value]	varchar(100) COLLATE NOCASE,
                    PRIMARY KEY ([SavedSearchID], [Name])
                    ,
                    FOREIGN KEY ([SavedSearchID])
                    REFERENCES [SavedSearches]([ID])
                    );
                    CREATE  INDEX [ssoSearch] ON [SavedSearchObjects] ([SavedSearchID] ASC);

                    CREATE TABLE [SavedSearches] (
                    [ID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [Name]	varchar(30) COLLATE NOCASE,
                    [Description]	varchar(100) COLLATE NOCASE,
                    [Time]	datetime
                    );

                    CREATE TABLE [Temp_Costs] (
                    [CallCategory]	nvarchar(50) COLLATE NOCASE,
                    [Cost]	numeric
                    );

                    CREATE  TABLE [Numbers] (
                    [ID] INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL ,
                    [PersonID] INTEGER NOT NULL ,
                    [Number] VARCHAR NOT NULL ,
                    [Type] VARCHAR NOT NULL ,
                    [Description] VARCHAR,
                    FOREIGN KEY ([PersonID])
                    REFERENCES [People]([ID])
                    );

                    CREATE  INDEX [numberspeopleid] ON [Numbers] ([PersonID] ASC);
                    CREATE  INDEX [numbersnum] ON [Numbers] ([Number] ASC);
                    CREATE  INDEX [numsclustered] ON [Numbers] ([PersonID] ASC, [Number] ASC);

                    CREATE VIEW [Contacts]
                    AS
                    SELECT     People.*
                    FROM         People;

                    CREATE VIEW [allNumbers]
                    AS
                    SELECT     P.ID AS PersonID, P.Name, P.Description AS [PersonDesc], N.Number, N.Description, N.Type, P.Email, N.ID AS NumberID
                    FROM         Numbers AS N LEFT OUTER JOIN
                    People AS P ON N.PersonID = P.ID;


                    CREATE  VIEW [CallsAndCosts] AS
                        SELECT
                        NS.[ID]
                        ,NS.[CallDate]
                        ,NS.[CallerExtension]
                        , NS.[DialledExtension]
                        
                        ,CASE NS.[DialledExtension]
                            WHEN
                            (SELECT
                                NS.[DialledExtension]
                            FROM CallCategory CC
                                WHERE NS.[DialledExtension] REGEXP CC.[Regular Expression]
                            ORDER BY [Priority] DESC LIMIT 1
                            )
                            THEN
                            (SELECT
                                CC.[Name]
                            FROM CallCategory CC
                                WHERE NS.[DialledExtension] REGEXP CC.[Regular Expression]
                            ORDER BY [Priority] DESC LIMIT 1
                            )
                        END AS [Cost Name]

                        ,CASE NS.[DialledExtension]
                            WHEN
                            (SELECT
                                NS.[DialledExtension]
                            FROM CallCategory CC
                                WHERE NS.[DialledExtension] REGEXP CC.[Regular Expression]
                            ORDER BY [Priority] DESC LIMIT 1
                            )
                            THEN
                            (SELECT
                                CC.[Cost]
                            FROM CallCategory CC
                                WHERE NS.[DialledExtension] REGEXP CC.[Regular Expression]
                            ORDER BY [Priority] DESC LIMIT 1
                            )
                        END AS [Call Cost]

                        ,CASE NS.[DialledExtension]
                            WHEN
                            (SELECT
                                NS.[DialledExtension]
                            FROM CallCategory CC
                                WHERE NS.[DialledExtension] REGEXP CC.[Regular Expression]
                            ORDER BY [Priority] DESC LIMIT 1
                            )
                            THEN
                            (SELECT
                                CC.[Connection Cost]
                            FROM CallCategory CC
                                WHERE NS.[DialledExtension] REGEXP CC.[Regular Expression]
                            ORDER BY [Priority] DESC LIMIT 1
                            )
                        END AS [Connection Cost]

                        ,CASE NS.[DialledExtension]
                            WHEN
                            (SELECT
                                NS.[DialledExtension]
                            FROM CallCategory CC
                                WHERE NS.[DialledExtension] REGEXP CC.[Regular Expression]
                            ORDER BY [Priority] DESC LIMIT 1
                            )
                            THEN
                            (SELECT
                                CC.[Block Size]
                            FROM CallCategory CC
                                WHERE NS.[DialledExtension] REGEXP CC.[Regular Expression]
                            ORDER BY [Priority] DESC LIMIT 1
                            )
                        END AS [Block Size]

                        ,CASE NS.[DialledExtension]
                            WHEN
                            (SELECT
                                NS.[DialledExtension]
                            FROM CallCategory CC
                                WHERE NS.[DialledExtension] REGEXP CC.[Regular Expression]
                            ORDER BY [Priority] DESC LIMIT 1
                            )
                            THEN
                            (SELECT
                                CC.[Charge Unfinished]
                            FROM CallCategory CC
                                WHERE NS.[DialledExtension] REGEXP CC.[Regular Expression]
                            ORDER BY [Priority] DESC LIMIT 1
                            )
                        END AS [Charge Unfinished]

                        ,CASE
                        WHEN NS.[Direction]='Outgoing' THEN
                        (SUBSTR(NS.[Duration],9))+(SUBSTR(NS.[Duration],6,2)*60)+(SUBSTR(NS.[Duration],1,4)*3600)
                        ELSE NULL
                        END
                        AS [TotalSeconds]

                        FROM Calls AS NS;


                    CREATE VIEW [newSearch]
                    AS
                    
                     SELECT
                    Calls.[CallDate] AS [Call Date]
                    ,SUBSTR(Calls.[Duration],LENGTH(Calls.[Duration])-7) AS [Duration]
                    ,Calls.[TimeToAnswer] AS [Time to Answer]
                    ,Calls.[Type] AS [Type]
                    ,Calls.[Direction] AS [Direction]

                    ,CASE Calls.[Direction]
                        WHEN 'Incoming' THEN ExternalCallers.[Name]
                        ELSE InternalCallers.[Name]
                    END AS [Caller Name]

                    ,CASE Calls.[Direction]
                        WHEN 'Incoming' THEN Calls.[CallerExternal]
                        ELSE Calls.[CallerExtension]
                    END AS [Caller Number]

                    ,Calls.[CallerExtension] AS [Caller Extension]
                    ,Calls.[DialledExtension] AS [Dialled Extension]

                    ,CASE Calls.[Direction]
                        WHEN 'Outgoing' THEN ExternalReceivers.[Name]
                        ELSE InternalReceivers.[Name]
                    END AS [Receiver Name]

                    ,CASE Calls.[Direction]
                        WHEN 'Outgoing' THEN Calls.[DialledExtension]
                        ELSE Calls.[ReceiverExtension]
                    END AS [Receiver Number]

                    ,Calls.[ReceiverExtension] AS [Receiver Extension]

                    ,CASE
                        WHEN Calls.[Direction] = 'Outgoing' AND Costs.[Cost Name] IS NULL THEN 'NO MATCH'
                        WHEN Calls.[Direction] = 'Outgoing' AND Costs.[Cost Name] IS NOT NULL THEN Costs.[Cost Name]
                        ELSE NULL
                    END AS [Filter Name]

                    ,CASE
                        WHEN Calls.[Direction] = 'Outgoing' AND Costs.[Cost Name] IS NULL THEN NULL
                        WHEN Calls.[Direction] = 'Outgoing' AND Costs.[Cost Name] IS NOT NULL AND [Charge Unfinished] = '0' THEN      
                            TRUNCATE( (  TRUNCATE( (( Costs.[TotalSeconds] + '0.0' ) / Costs.[Block Size]) )  *  Costs.[Call Cost]  +   Costs.[Connection Cost]   ) / 100   ,2)
                        WHEN Calls.[Direction] = 'Outgoing' AND Costs.[Cost Name] IS NOT NULL AND [Charge Unfinished] = '1' THEN
                            TRUNCATE( (  ( TRUNCATE( (( Costs.[TotalSeconds] + '0.0' ) / Costs.[Block Size]) ) +1)  *  Costs.[Call Cost]  +   Costs.[Connection Cost]   ) / 100   ,2)
                        ELSE NULL
                    END AS [Cost]

                    FROM
                    [Calls]
                    LEFT JOIN
                        [allNumbers] AS InternalCallers
                    ON Calls.[CallerExtension] = InternalCallers.[Number]
                    LEFT JOIN
                        [allNumbers] AS InternalReceivers
                    ON Calls.[ReceiverExtension] = InternalReceivers.[Number]
                    LEFT JOIN
                        [allNumbers] AS ExternalCallers
                    ON Calls.[CallerExternal] = ExternalCallers.[Number]
                    LEFT JOIN
                        [allNumbers] AS ExternalReceivers
                    ON Calls.[DialledExtension] = ExternalReceivers.[Number]
                    INNER JOIN
                    [CallsAndCosts] AS Costs
                    ON Calls.[ID] = Costs.[ID]
                    ";

                    Regex regex = new Regex(";", RegexOptions.None);
                    string[] sqlCommands = regex.Split(sqlCommand);

                    foreach (string command in sqlCommands)
                    {
                        manager.ExecuteNonQuery(CommandType.Text, command);
                    }
                }
                catch (Exception ex)
                {
                    LogManager.Log(LogEntryType.Error, SourceType.DBIntegrity, "Could not create Sqlite DB tables: " + ex.Message);
                    return ex.ToString();
                }
                manager.Dispose();
                return "Created Sqlite tables successfully";
            }
            else
            {
                //No other databases supported yet
                return "Database type not supported yet";
            }
        }

        //Create Data functions
        public string InsertDefaultData()
        {
            //put dummy data in the database
            //create the tables
            if (_provider == DataProvider.Sqlite)
            {
                string todaysDate = DateTime.Now.ToString("yyyy-MM-dd");
                string yesterdaysDate = DateTime.Now.ToString("yyyy-MM-");
                yesterdaysDate += (Convert.ToInt32(DateTime.Now.ToString("dd"))-1).ToString();

                ArrayList errors = new ArrayList();
                DBManager manager = new DBManager(_provider, _connectionString);

                try
                {
                    manager.Open();

                    string sqlCommand = @"
                    DELETE FROM [Versions];
                    DELETE FROM [CallCategory];
                    DELETE FROM [Calls];
                    DELETE FROM [Numbers];
                    DELETE FROM [Logs];
                    DELETE FROM [People];
                    DELETE FROM [SavedSearchObjects];
                    DELETE FROM [SavedSearches];
                    DELETE FROM [Temp_Costs];
                   
                    INSERT INTO [Versions] VALUES('MiSMDR','2.1');
                    INSERT INTO [Versions] VALUES('database','2.2');

                    INSERT INTO [SavedSearches] VALUES(1,'" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month) + @" - All Calls','','" + DateTime.Now.ToString("yyyy-MM-dd") + @" 13:41:38');

                    INSERT INTO [SavedSearchObjects] VALUES(1,'rbAllDates','False');
                    INSERT INTO [SavedSearchObjects] VALUES(1,'rbSingleDate','False');
                    INSERT INTO [SavedSearchObjects] VALUES(1,'rbDateRange','True');
                    INSERT INTO [SavedSearchObjects] VALUES(1,'DayFilter','7');
                    INSERT INTO [SavedSearchObjects] VALUES(1,'StartDateFilter1','" + DateTime.Today.AddDays(-(DateTime.Today.Day - 1)).ToString("yyyy-MM-dd") + @"');
                    INSERT INTO [SavedSearchObjects] VALUES(1,'EndDateFilter1','" + DateTime.Today.AddDays(-(DateTime.Today.Day + 1)).AddMonths(1).ToString("yyyy-MM-dd") + @"');
                    INSERT INTO [SavedSearchObjects] VALUES(1,'cbAnswerTime','0');
                    INSERT INTO [SavedSearchObjects] VALUES(1,'cbDuration','0');
                    INSERT INTO [SavedSearchObjects] VALUES(1,'tbAnswerTime','');
                    INSERT INTO [SavedSearchObjects] VALUES(1,'tbDuration','');
                    INSERT INTO [SavedSearchObjects] VALUES(1,'tbFrom','');
                    INSERT INTO [SavedSearchObjects] VALUES(1,'tbTo','');
                    INSERT INTO [SavedSearchObjects] VALUES(1,'toExactMatch','False');
                    INSERT INTO [SavedSearchObjects] VALUES(1,'fromExactMatch','False');
                    INSERT INTO [SavedSearchObjects] VALUES(1,'cbCallCategory','0');
                    ";

                    Regex regex = new Regex("GO", RegexOptions.None);
                    string[] sqlCommands = regex.Split(sqlCommand);

                    foreach (string command in sqlCommands)
                    {
                        manager.ExecuteNonQuery(CommandType.Text, command);
                    }
                }
                catch (Exception ex)
                {
                    LogManager.Log(LogEntryType.Error, SourceType.DBIntegrity, "Could not create DB tables: " + ex.Message);
                    return ex.ToString();
                }
                manager.Dispose();

                //Create a new thread inserting 100 calls
                Thread miThread = new Thread(new ThreadStart(Insert100Calls));
                miThread.SetApartmentState(ApartmentState.MTA);
                miThread.Start();

                /*
                Thread miThread2 = new Thread(new ThreadStart(Insert10Extensions));
                miThread2.SetApartmentState(ApartmentState.MTA);
                miThread2.Start();
                */
                InsertExtensions(23);
                InsertCallCosts();
                return "Sqlite Data created successfully";
            }
            else
            {
                //No other databases supported yet
                return "Database type not supported yet";
            }
        }
        private void InsertCallCosts()
        {
            

            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();
                //insert the callcost

                foreach (externalNumber prefix in externalNumberPrefix)
                {
                    int connCost=0, blockSize=0, blockRate=0;
                    Random n = new Random();
                    connCost = n.Next(1, 4) * 10;

                    if ((prefix.Prefix != "1800") && (prefix.Prefix != "1900") && (prefix.Prefix != "13"))
                    {
                        blockSize = 60;
                        blockRate = n.Next(1, 4) * 5; //5 , 10, 15
                    }
                    else if (prefix.Prefix == "1900")
                    {
                        blockSize = 60;
                        blockRate = n.Next(5, 12) * 5;
                    }
                    manager.ExecuteNonQuery(CommandType.Text, "INSERT INTO [CallCategory] ([Regular Expression],[Type],[Priority],[Name],[Connection Cost],[Block Size],[Cost],[Charge Unfinished]) VALUES('^" + prefix.Prefix + "\\d*','starts','0','" + prefix.Description + "','"+connCost.ToString()+"','"+blockSize.ToString()+"','"+blockRate.ToString()+"','"+n.Next(0,2).ToString()+"');");
                }
            }
        }
        private void InsertExtensions(int max)
        {
            for (int i = 0; i < max; i++)
            {
                this.InsertPersonWithNumber(i, max);
            }
        }
        public void InsertPersonWithNumber(int seed, int max)
        {
            try
            {
                if (_provider == DataProvider.Sqlite)
                {
                    Random random = new Random(seed);
                    int n;

                    #region Name
                    string name;

                    string[] firstNameList = { "Nick", "Jed", "Ian", "Simon", "Guy", "Thomas", "Anita", "Sam", "Samuel", "Oliver", "Claudia", "Bernard", "Jill", "Duncan", "Daniel", "Danial", "Jay", "David", "Niko", "Russell", "Scott", "Michael", "Mike", "Jared", "John", "Steve", "Paul", "Bryce", "Vince", "Brad", "Dave", "Teresa", "Julie", "Ingrid", "Rob", "Megan", "Jeff", "Ben", "Leigh", "Lee", "Missy", "Tegan", "Sara", "Bob", "Elliot", "Josh", "Camille", "Matthew", "Sarah", "Peter", "Bjorn", "Johan", "Regina", "Angus", "Julia", "Miguel", "Margarida", "Charlotte", "Mariana", "Jorge", "George", "Luis", "Sergio", "Manuel", "Basel" };
                    string[] lastNameList = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson", "Thomas", "Jackson", "White", "Black", "Harris", "Martin", "Thompson", "Garcia", "Martinez", "Robinson", "Clark", "Rodriguez", "Lewis", "Lee", "Walker", "Hall", "Allen", "Young", "Hernandez", "King", "Wright", "Lopez", "Hill", "Scott", "Green", "Adams", "Baker", "Gonzalez", "Nelson", "Carter", "Mitchell", "Perez", "Roberts", "Turner", "Philips", "Campbell", "Parker", "Evans", "Edwards", "Collins", "Stewart", "Sanchez", "Morris", "Rogers", "Reed", "Cook", "Morgan", "Bell" };
                    n = random.Next(0, firstNameList.Length);
                    string firstName = firstNameList[n];
                    n = random.Next(0, lastNameList.Length);
                    string lastName = lastNameList[n];

                    name = firstName + " " + lastName;
                    #endregion

                    #region Number Type and Suffix

                    string numberType;
                    string nameSuffix;
                    n = random.Next(0, 4);
                    if (n == 0) // 1/4 chance
                    {
                        numberType = "External";
                        n = random.Next(0, 5);
                        if (n == 0) nameSuffix = "Home";
                        else if (n == 1) nameSuffix = "Mobile";
                        else nameSuffix = "";
                    }
                    else // 3/4 chance
                    {
                        numberType = "Internal";
                        n = random.Next(0, 3);
                        if (n == 0) nameSuffix = "Office"; // 1/3 add the office suffix
                        else nameSuffix = "";
                    }
                    if (nameSuffix != String.Empty) name = name + " - " + nameSuffix;
                    #endregion

                    #region Number
                    string number;
                    if (numberType == "Internal")
                    {
                        //n = random.Next(0, 100);

                        //changed from random to number based on the number
                        int num = Convert.ToInt32(internalNumberPrefix)*100 + Convert.ToInt32(seed*(100/max));
                        number = num.ToString();
                    }
                    else
                    {
                        //get the ext. prefix
                        n = random.Next(0, externalNumberPrefix.Count);
                        string numberPrefix = externalNumberPrefix[n].Prefix;
                        //add on 7 more digits to the prefix
                        n = random.Next(0, 10000000);
                        number = numberPrefix + n.ToString().PadLeft(7, '0');
                    }
                    #endregion


                    // Insert the new person and Get the ID of the Person just entered
                    using (IDBManager manager = new DBManager(_provider, _connectionString))
                    {
                        string newID = "";
                        manager.Open();
                        //insert the person
                        manager.ExecuteNonQuery(CommandType.Text, "INSERT INTO [People] ([Name], [Description], [Email]) VALUES('" + name + "','','');");

                        //now get the ID
                        IDataReader myReader = manager.ExecuteReader(CommandType.Text, "SELECT max(ID) from People");
                        while (myReader.Read())
                        {
                            newID = myReader.GetValue(0).ToString();
                        }
                        manager.CloseReader();

                        //Now insert the number
                        manager.ExecuteNonQuery(CommandType.Text, "INSERT INTO [Numbers] ([PersonID],[Number],[Type]) VALUES('" + newID + "','" + number + "','" + numberType + "');");
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void Insert100Calls()
        {
            for (int i = 0; i < 100; i++)
            {
                this.InsertCall();
            }
        }
        public void InsertCall()
        {
            if (_provider == DataProvider.Sqlite)
            {
                Random random = new Random();

                #region datesandtimes
                int thisYear = Convert.ToInt32(DateTime.Now.ToString("yyyy")); //the year
                int thisDay = Convert.ToInt32(DateTime.Now.ToString("dd"));
                int thisMonth = Convert.ToInt32(DateTime.Now.ToString("MM"));
                
                int prevMonth;
                int prevYear = thisYear;

                if (thisMonth > 1) prevMonth = thisMonth - 1;
                else
                {
                    prevMonth = 12;
                    prevYear = thisYear - 1;
                }

                string callDate;

                int n;
                n = random.Next(0, 23);

                if ((thisDay - n) > 0) callDate = thisYear.ToString() + "-" + thisMonth.ToString().PadLeft(2, '0') + "-" + (thisDay - n).ToString().PadLeft(2, '0');
                else if ((thisDay - n) < 0) callDate = prevYear.ToString() + "-" + prevMonth.ToString().PadLeft(2, '0') + "-" + n.ToString().PadLeft(2, '0');
                else callDate = thisYear.ToString() + "-" + thisMonth.ToString().PadLeft(2, '0') + "-" + thisDay.ToString().PadLeft(2, '0');

                string time = n.ToString().PadLeft(2, '0') + ":33:00";
                #endregion

                #region directiontype
                string direction;
                string callType;
                n = random.Next(0, 10);
                if (n >= 5) // 5/10 chance
                {
                    direction = "Outgoing";
                    callType = "External";
                }
                else if (n >= 1) // 4/10 chance
                {
                    direction = "Incoming";
                    callType = "External";
                }
                else //n==0  1/10 chance
                {
                    direction = "Internal";
                    callType = "Internal";
                }
                #endregion

                #region durationandanswer
                string duration;
                string timeToAnswer;

                duration = "0000:";
                n = random.Next(0, 11);
                duration += n.ToString().PadLeft(2, '0') + ":";
                n = random.Next(0, 59);
                duration += n.ToString().PadLeft(2, '0');

                if (direction == "Incoming")
                {
                    n = random.Next(0, 12);
                    if (n > 4)
                    {
                        timeToAnswer = "00:";
                        n = random.Next(0, 2);
                        timeToAnswer += n.ToString().PadLeft(2, '0') + ":";
                        n = random.Next(0, 59);
                        timeToAnswer += n.ToString().PadLeft(2, '0');
                    }
                    else timeToAnswer = "****";
                }
                else // (direction == "Outgoing")
                {
                    timeToAnswer = "";
                }
                #endregion

                #region caller
                string callerInternal;
                string callerExternal;
                if ((direction == "Outgoing") || (direction == "Internal"))
                {
                    n = random.Next(0, 100);
                    callerInternal = internalNumberPrefix + n.ToString().PadLeft(2, '0');
                    callerExternal = "93090";
                }
                else // (direction == "Incoming")
                {
                    n = random.Next(0, 10000000);
                    int p = random.Next(0, externalNumberPrefix.Count);
                    callerExternal = externalNumberPrefix[p].Prefix + n.ToString().PadLeft(7, '0');
                    callerInternal = "T7010";
                }
                #endregion

                #region receiver
                string dialledNumber;
                string receiverInternal;
                if ((direction == "Incoming") || (direction == "Internal"))
                {
                    n = random.Next(0, 100);
                    receiverInternal = internalNumberPrefix + n.ToString().PadLeft(2, '0');
                    dialledNumber = receiverInternal;
                }
                else // (direction == "Outgoing")
                {
                    n = random.Next(0, 10000000);
                    int p = random.Next(0, externalNumberPrefix.Count);
                    dialledNumber = externalNumberPrefix[p].Prefix + n.ToString().PadLeft(7, '0');
                    receiverInternal = "";
                }
                #endregion

                #region other
                string rawData = "009";

                string rawType;
                if (direction == "Outgoing") rawType = "A";
                else if (direction == "Internal") rawType = "I";
                else rawType = " ";

                string source = "MiSMDRDemo";
                #endregion

                using (DBManager manager = new DBManager(_provider, _connectionString))
                {
                    try
                    {
                        manager.Open();

                        string command = "INSERT INTO [Calls] ([CallDate], [Duration], [CallerExtension], [TimeToAnswer], [DialledExtension], [Type], [ReceiverExtension], [CallerExternal], [Direction], [RawData], [RawType], [Source]) VALUES('" + callDate + " " + time + "','" + duration + "','" + callerInternal + "','" + timeToAnswer + "','" + dialledNumber + "','" + callType + "','" + receiverInternal + "','" + callerExternal + "','" + direction + "','" + rawData + "','" + rawType + "','" + source + "');";
                        manager.ExecuteNonQuery(CommandType.Text, command);
                    }
                    catch (Exception ex)
                    {
                        LogManager.Log(LogEntryType.Error, SourceType.DBIntegrity, "Could not create Demo Data: " + ex.Message);
                    }
                }
            }
        }
        public string InsertInputFormats()
        {
            //create the tables
            if (_provider == DataProvider.Sqlite)
            {
                ArrayList errors = new ArrayList();
                DBManager manager = new DBManager(_provider, _connectionString);

                try
                {
                    manager.Open();

                    string sqlCommand = @"
                    DROP TABLE IF EXISTS [MiSMDRFields];
                    DROP TABLE IF EXISTS [MiSMDRHardware];
                    DROP TABLE IF EXISTS [MiSMDRSeparations];
                    DROP TABLE IF EXISTS [MiSMDRTypes];
                    DROP TABLE IF EXISTS [MiSMDRTypeRegex];
                    DROP TABLE IF EXISTS [MiSMDRDelimiters];

                    CREATE TABLE [MiSMDRHardware] (
                      [ID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                      [Name] varchar(30) COLLATE NOCASE,
                      [Version] varchar(20) COLLATE NOCASE,
                      [DefiningRegex] varchar(50) COLLATE NOCASE,
                      [StartPosition] INTEGER  NOT NULL,
                      [EndPosition] INTEGER  NOT NULL,
                      [FieldPositioning] varchar(15) NOT NULL -- 'fixed' or 'delimited' (more if we want)
                    );

                    CREATE TABLE [MiSMDRTypes] (
                      [ID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                      [Name] varchar(30) COLLATE NOCASE
                    );

                    CREATE TABLE [MiSMDRTypeRegex] (
                      [HardwareID] INTEGER  NOT NULL,
                      [TypeID] INTEGER  NOT NULL,
                      [Regex] varchar(50) COLLATE NOCASE,
                      PRIMARY KEY  ([HardwareID],[TypeID])
                    );
                    
                    
                    CREATE TABLE [MiSMDRFields] (
                      [ID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                      [Name] varchar(20) COLLATE NOCASE
                    );

                    CREATE TABLE [MiSMDRSeparations] (
                      [HardwareID] INTEGER  NOT NULL,
                      [FieldID] INTEGER  NOT NULL,
                      [StartPosition] INTEGER  NOT NULL,
                      [EndPosition] INTEGER  NOT NULL,
                      PRIMARY KEY  ([HardwareID],[FieldID])
                    );

                    CREATE TABLE [MiSMDRDelimiters] (
                      [HardwareID] INTEGER  NOT NULL,
                      [FieldID] INTEGER  NOT NULL,
                      [Delimiter] varchar(10)  NOT NULL,
                      [Position] INTEGER  NOT NULL,
                      PRIMARY KEY  ([HardwareID],[FieldID])
                    );


                    --Different Hardware Versions
                    INSERT INTO [MiSMDRHardware] ([ID], [Name], [Version],[DefiningRegex],[StartPosition],[EndPosition],[FieldPositioning]) VALUES(1, 'Mitel 3300 ICP - 1', 'Level 1 Extended Format','^(.){14}\d{4}:\d{2}:\d{2}(.){80}\d{3}\s{3}',0,111,'fixed');
                    INSERT INTO [MiSMDRHardware] ([ID], [Name], [Version],[DefiningRegex],[StartPosition],[EndPosition],[FieldPositioning]) VALUES(2, 'Mitel 3300 ICP - 2', 'Standard Format','^(.){14}\d{2}:\d{2}:\d{2}(.){63}\d{3}',0,89,'fixed');
                    INSERT INTO [MiSMDRHardware] ([ID], [Name], [Version],[DefiningRegex],[StartPosition],[EndPosition],[FieldPositioning]) VALUES(3, 'Mitel 3300 ICP - 3', 'Extended Format','^(.){14}\d{4}:\d{2}:\d{2}(.){72}\d{3}\s{3}',0,102,'fixed');
                    INSERT INTO [MiSMDRHardware] ([ID], [Name], [Version],[DefiningRegex],[StartPosition],[EndPosition],[FieldPositioning]) VALUES(4, 'Mitel 3300 ICP - 4', 'Level 2 Extended Format','^(.){17}\d{4}:\d{2}:\d{2}(.){80}\d{3}\s{3}',0,114,'fixed');

                    --Different Types of calls
                    INSERT INTO [MiSMDRTypes] ([ID], [Name]) VALUES(1, 'Incoming');
                    INSERT INTO [MiSMDRTypes] ([ID], [Name]) VALUES(2, 'Outgoing');
                    INSERT INTO [MiSMDRTypes] ([ID], [Name]) VALUES(3, 'Internal');
                    INSERT INTO [MiSMDRTypes] ([ID], [Name]) VALUES(4, 'Tandem');

                    --Level 1 Extended Format Type Regexes
                    INSERT INTO [MiSMDRTypeRegex] ([HardwareID], [TypeID], [Regex]) VALUES(1,1,'^(.){25}(X|T)(.){40}[^X^T]');
                    INSERT INTO [MiSMDRTypeRegex] ([HardwareID], [TypeID], [Regex]) VALUES(1,2,'^(.){25}[^X^T](.){40}(X|T| )');
                    INSERT INTO [MiSMDRTypeRegex] ([HardwareID], [TypeID], [Regex]) VALUES(1,3,'^(.){64}(I)');
                    INSERT INTO [MiSMDRTypeRegex] ([HardwareID], [TypeID], [Regex]) VALUES(1,4,'^(.){25}(X|T)(.){40}(X|T| )');

                    --Standard Format Type Regexes
                    INSERT INTO [MiSMDRTypeRegex] ([HardwareID], [TypeID], [Regex]) VALUES(2,1,'^(.){23}(X|T)(.){37}[^X^T]');
                    INSERT INTO [MiSMDRTypeRegex] ([HardwareID], [TypeID], [Regex]) VALUES(2,2,'^(.){23}[^X^T](.){37}(X|T| )');
                    INSERT INTO [MiSMDRTypeRegex] ([HardwareID], [TypeID], [Regex]) VALUES(2,3,'^(.){59}(I)');
                    INSERT INTO [MiSMDRTypeRegex] ([HardwareID], [TypeID], [Regex]) VALUES(2,4,'^(.){23}(X|T)(.){37}(X|T| )');

                    --Extended Format Type Regexes
                    INSERT INTO [MiSMDRTypeRegex] ([HardwareID], [TypeID], [Regex]) VALUES(3,1,'^(.){25}(X|T)(.){40}[^X^T]');
                    INSERT INTO [MiSMDRTypeRegex] ([HardwareID], [TypeID], [Regex]) VALUES(3,2,'^(.){25}[^X^T](.){40}(X|T| )');
                    INSERT INTO [MiSMDRTypeRegex] ([HardwareID], [TypeID], [Regex]) VALUES(3,3,'^(.){64}(I)');
                    INSERT INTO [MiSMDRTypeRegex] ([HardwareID], [TypeID], [Regex]) VALUES(3,4,'^(.){25}(X|T)(.){40}(X|T| )');

                    --Level 2 Extended Format Type Regexes
                    INSERT INTO [MiSMDRTypeRegex] ([HardwareID], [TypeID], [Regex]) VALUES(4,1,'^(.){28}(X|T)(.){40}[^X^T]');
                    INSERT INTO [MiSMDRTypeRegex] ([HardwareID], [TypeID], [Regex]) VALUES(4,2,'^(.){28}[^X^T](.){40}(X|T| )');
                    INSERT INTO [MiSMDRTypeRegex] ([HardwareID], [TypeID], [Regex]) VALUES(4,3,'^(.){67}(I)');
                    INSERT INTO [MiSMDRTypeRegex] ([HardwareID], [TypeID], [Regex]) VALUES(4,4,'^(.){28}(X|T)(.){40}(X|T| )');

                    -- Different fields of data that MiSMDR needs to function (direction and type will be got with the TypeRegexes)
                    INSERT INTO [MiSMDRFields] ([ID], [Name]) VALUES(1, 'CallDate');
                    INSERT INTO [MiSMDRFields] ([ID], [Name]) VALUES(2, 'Duration');
                    INSERT INTO [MiSMDRFields] ([ID], [Name]) VALUES(3, 'Caller Extension');
                    INSERT INTO [MiSMDRFields] ([ID], [Name]) VALUES(4, 'Answer Time');
                    INSERT INTO [MiSMDRFields] ([ID], [Name]) VALUES(5, 'Digits Dialled');
                    INSERT INTO [MiSMDRFields] ([ID], [Name]) VALUES(6, 'Receiver Extension');
                    INSERT INTO [MiSMDRFields] ([ID], [Name]) VALUES(7, 'External Caller');
                    
                    --Level 1 Extended Digit Format
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(1, 1, 1, 12); --CallDate
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(1, 2, 14, 23); --Duration
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(1, 3, 25, 31); --CallerExtension
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(1, 4, 33, 36); --AnswerTime
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(1, 5, 38, 63); --DigitsDialled
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(1, 6, 66, 72); --ReceiverExtension
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(1, 7, 109, 129); --ExternalCaller

                    --Standard Format
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(2, 1, 1, 12); --CallDate
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(2, 2, 14, 21); --Duration
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(2, 3, 23, 26); --CallerExtension
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(2, 4, 28, 31); --AnswerTime
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(2, 5, 33, 58); --DigitsDialled
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(2, 6, 61, 64); --ReceiverExtension (aka. Called Party)
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(2, 7, 91, 100); --ExternalCaller

                    --Normal Extended Digit Format
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(3, 1, 1, 12); --CallDate
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(3, 2, 14, 23); --Duration
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(3, 3, 25, 31); --CallerExtension
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(3, 4, 33, 36); --AnswerTime
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(3, 5, 38, 63); --DigitsDialled
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(3, 6, 66, 72); --ReceiverExtension
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(3, 7, 102, 112); --ExternalCaller
                    
                    --Level 2 Extended Digit Format
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(4, 1, 1, 15); --CallDate
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(4, 2, 17, 26); --Duration
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(4, 3, 28, 34); --CallerExtension
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(4, 4, 36, 39); --AnswerTime
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(4, 5, 41, 66); --DigitsDialled
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(4, 6, 69, 75); --ReceiverExtension
                    INSERT INTO [MiSMDRSeparations] ([HardwareID], [FieldID], [StartPosition], [EndPosition]) VALUES(4, 7, 113, 132); --ExternalCaller
                    ";

                    Regex regex = new Regex(";", RegexOptions.None);
                    string[] sqlCommands = regex.Split(sqlCommand);

                    foreach (string command in sqlCommands)
                    {
                        manager.ExecuteNonQuery(CommandType.Text, command);
                    }
                }
                catch (Exception ex)
                {
                    LogManager.Log(LogEntryType.Error, SourceType.DBIntegrity, "Could not create Input Format tables and data: " + ex.Message);
                    return ex.ToString();
                }
                manager.Dispose();
                return "Created Sqlite Input format tables and data successfully";
            }
            else
            {
                //No other databases supported yet
                return "Database type not supported yet";
            }
        }

        //Delete functions
        public string EmptyCallData()
        {
            if (_provider == DataProvider.Sqlite)
            {
                ArrayList errors = new ArrayList();
                DBManager manager = new DBManager(_provider, _connectionString);

                try
                {
                    manager.Open();

                    string sqlCommand = @"
                    DELETE FROM [Calls];
                    ";

                    Regex regex = new Regex("GO", RegexOptions.None);
                    string[] sqlCommands = regex.Split(sqlCommand);

                    foreach (string command in sqlCommands)
                    {
                        manager.ExecuteNonQuery(CommandType.Text, command);
                    }
                }
                catch (Exception ex)
                {
                    LogManager.Log(LogEntryType.Error, SourceType.DBIntegrity, "Could not empty Sqlite DB tables: " + ex.Message);
                    return ex.ToString();
                }
                manager.Dispose();
                return "Sqlite Data deleted successfully";
            }
            else
            {
                return "Database type not supported";
            }
        }
    }
    public class externalNumber
    {
        public string Prefix;
        public string Description;
        public externalNumber(string pref, string desc)
        {
            Prefix = pref;
            Description = desc;
        }
    }
}
