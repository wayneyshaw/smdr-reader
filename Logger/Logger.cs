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
using System.Data;
using System.Text;
using MiSMDR.DataAccessLayer;

namespace MiSMDR.Logger
{
    public class LogManager
    {
        static string _connectionString = String.Empty;
        static DataProvider _provider;

        public static void SetConnectionString(string connString, DataProvider provider)
        {
            _connectionString = connString;
            _provider = provider;
        }

        public static DataSet GetLogData()
        {
            DBManager manager = new DBManager(_provider, _connectionString);

            try
            {
                manager.Open();
                return manager.ExecuteDataSet(CommandType.Text, "SELECT [LogDate],[Source],[Message],[LogEntryType] FROM [Logs] ORDER BY [LogDate] DESC LIMIT 1000");
            }
            catch (Exception ex)
            {
                LogManager.Log(LogEntryType.Error, SourceType.MiSMDR, "Could not retrieve Log data:" + ex.ToString());
                return null;
            }
        }
        public static void Log(LogEntryType errorType, SourceType sourceType, string message)
        {
            if (_connectionString != String.Empty)
            {
                using (DBManager manager = new DBManager(_provider, _connectionString))
                {
                    string query = "";
                    manager.Open();
                    if (_provider == DataProvider.SqlServer)
                    {
                        query = "INSERT INTO [Logs](LogDate, Source, Message, LogEntryType) VALUES(CONVERT(datetime,'" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "',103), '" + sourceType.ToString() + "', '" + message + "','" + errorType.ToString() + "')";
                    }
                    else if (_provider == DataProvider.Sqlite)
                    {
                        query = "INSERT INTO [Logs](LogDate, Source, Message, LogEntryType) VALUES(current_timestamp, '" + sourceType.ToString() + "', '" + message + "','" + errorType.ToString() + "')";
                    }
                    manager.ExecuteNonQuery(CommandType.Text, query);
                }
            }
        }
    }
}
