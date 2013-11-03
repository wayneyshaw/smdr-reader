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
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.SQLite;

namespace MiSMDR.DataAccessLayer
{
    // sealed = cannot be inherited from
    public sealed class DBManagerFactory
    {
        private DBManagerFactory() { }
        public static IDbConnection GetConnection(DataProvider providerType)
        {
            IDbConnection iDbConnection = null;
            switch (providerType)
            {
                case DataProvider.SqlServer:
                    iDbConnection = new SqlConnection();
                    break;
                case DataProvider.Sqlite:
                    iDbConnection = new SQLiteConnection();
                    break;
                case DataProvider.Odbc:
                    iDbConnection = new OdbcConnection();
                    break;
                case DataProvider.OleDb:
                    iDbConnection = new OleDbConnection();
                    break;
                default:
                    return null;
            }
            return iDbConnection;
        }

        public static IDbCommand GetCommand(DataProvider providerType)
        {
            switch (providerType)
            {
                case DataProvider.SqlServer:
                    return new SqlCommand();
                case DataProvider.Sqlite:
                    return new SQLiteCommand();
                case DataProvider.Odbc:
                    return new OdbcCommand();
                case DataProvider.OleDb:
                    return new OleDbCommand();
                default:
                    return null;
            }
        }

        public static IDbDataAdapter GetDataAdapter(DataProvider providerType)
        {
            switch (providerType)
            {
                case DataProvider.SqlServer:
                    return new SqlDataAdapter();
                case DataProvider.Sqlite:
                    return new SQLiteDataAdapter();
                case DataProvider.Odbc:
                    return new OdbcDataAdapter();
                case DataProvider.OleDb:
                    return new OleDbDataAdapter();
                default:
                    return null;
            }
        }

        public static IDbTransaction GetTransaction(DataProvider providerType)
        {
            IDbConnection iDbConnection = GetConnection(providerType);
            IDbTransaction iDbTransaction = iDbConnection.BeginTransaction();
            return iDbTransaction;
        }

        public static IDataParameter GetParameter(DataProvider providerType)
        {
            IDataParameter iDataParameter = null;
            switch (providerType)
            {
                case DataProvider.SqlServer:
                    iDataParameter = new SqlParameter();
                    break;
                case DataProvider.Sqlite:
                    iDataParameter = new SQLiteParameter();
                    break;
                case DataProvider.Odbc:
                    iDataParameter = new OdbcParameter();
                    break;
                case DataProvider.OleDb:
                    iDataParameter = new OleDbParameter();
                    break;
                default:
                    return null;
            }
            return iDataParameter;
        }

        public static IDbDataParameter[] GetParameters(DataProvider providerType, int paramsCount)
        {
            IDbDataParameter[] idbParams = new IDbDataParameter[paramsCount];

            switch (providerType)
            {
                case DataProvider.SqlServer:
                    for (int i = 0; i < paramsCount; i++)
                    {
                        idbParams[i] = new SqlParameter();
                    }
                    break;
                case DataProvider.Sqlite:
                    for (int i = 0; i < paramsCount; i++)
                    {
                        idbParams[i] = new SQLiteParameter();
                    }
                    break;
                case DataProvider.Odbc:
                    for (int i = 0; i < paramsCount; i++)
                    {
                        idbParams[i] = new OdbcParameter();
                    }
                    break;
                case DataProvider.OleDb:
                    for (int i = 0; i < paramsCount; i++)
                    {
                        idbParams[i] = new OleDbParameter();
                    }
                    break;
                default:
                    return null;
            }

            return idbParams;
        }
    }
}
