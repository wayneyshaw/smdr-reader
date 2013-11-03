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

namespace MiSMDR.SessionTracker
{
    public class SessionManager
    {
        static string _connectionString = String.Empty;
        static DataProvider _provider;

        public static void SetConnectionString(string connString, DataProvider provider)
        {
            _connectionString = connString;
            _provider = provider;
        }

        public static void Track(string sessionid, string pageid, string type)
        {
            if (_connectionString != String.Empty)
            {
                DBManager manager = new DBManager(_provider, _connectionString);

                try
                {
                    manager.Open();

                    string query = "INSERT INTO [SessionPageViews](SessionID, PageID, Type, Time) VALUES('"+sessionid+"', '" + pageid + "', '" + type + "','CONVERT(datetime,'" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "',103)')";

                    manager.ExecuteNonQuery(CommandType.Text, query);
                }
                catch (Exception)
                {
                    
                }
                finally
                {
                    if (manager != null)
                    {
                        manager.Dispose();
                    }
                }
            }
        }
    }
}
