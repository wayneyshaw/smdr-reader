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
using System.IO;
using MiSMDR.DataAccessLayer;
using System.Collections;
using System.Data;

namespace MiSMDR.DBIntegrity
{
    public class DBControl
    {
        private string _connectionString;
        private DataProvider _provider;

        public DBControl(string demoFileLocation)
        {
            ConnStringer stringer = new ConnStringer();
            _connectionString = stringer.buildLiteConnectionString(demoFileLocation, "3", "True", "False", "", "", false);
            _provider = DataProvider.Sqlite;
        }

        public DBControl(string connString, DataProvider provider)
        {
            _connectionString = connString;
            _provider = provider;
        }

        public bool Exists(string DBLocation)
        {
            if (DBLocation != String.Empty)
            {
                if (File.Exists(DBLocation)) return true;
                else return false;
            }
            else return false;
        }

        public void CreateTables()
        {
            DBInstaller installer = new DBInstaller(_connectionString, _provider);
            installer.CreateTables();
        }

        public void CreateDemoData()
        {
            DBInstaller installer = new DBInstaller(_connectionString, _provider);
            installer.InsertDefaultData();
        }

        public bool CheckDataAccess()
        {
            if (_provider == DataProvider.Sqlite)
            {
                ArrayList errors = new ArrayList();
                try
                {
                    using (DBManager manager = new DBManager(_provider, _connectionString))
                    {
                        manager.Open();
                        //run useless command to check that the database is accessible and create it if neccessary
                        string command = @"SELECT * FROM MiSMDRSeparations LIMIT 1";

                        manager.ExecuteDataSet(CommandType.Text, command);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else return false;
        }

        public bool CheckDataAccess(string tableName)
        {
            if (_provider == DataProvider.Sqlite)
            {
                ArrayList errors = new ArrayList();
                try
                {
                    using (DBManager manager = new DBManager(_provider, _connectionString))
                    {
                        manager.Open();
                        //run useless command to check that the database is accessible and create it if neccessary
                        string command = "SELECT * FROM "+tableName+" LIMIT 1";

                        manager.ExecuteDataSet(CommandType.Text, command);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else return false;
        }

        public void CreateInputFormats()
        {
            DBInstaller installer = new DBInstaller(_connectionString, _provider);
            installer.InsertInputFormats();
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }

        public DataProvider GetProvider()
        {
            return _provider;
        }
    }
}
