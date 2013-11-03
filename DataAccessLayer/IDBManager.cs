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
    public interface IDBManager : IDisposable
    {
        DataProvider ProviderType
        {
            get;
            set;
        }

        string ConnectionString
        {
            get;
            set;
        }

        IDbConnection Connection
        {
            get;
        }
        IDbTransaction Transaction
        {
            get;
        }
        IDataReader DataReader
        {
            get;
            set;
        }
        IDbCommand Command
        {
            get;
        }
        IDbDataParameter[] parameters
        {
            get;
        }

        void Open();
        void BeginTransaction();
        void CommitTransaction();
        void CreateParameters(int paramsCount);
        void AddParameters(int index, string paramName, object objValue);
        void AddParameters(int index, string paramName, object objValue, ParameterDirection direction, int size);
        IDataReader ExecuteReader(CommandType commandType, string commandText);
        DataSet ExecuteDataSet(CommandType commandType, string commandText);
        object ExecuteScalar(CommandType commandType, string commandText);
        int ExecuteNonQuery(CommandType commandType, string commandText);
        void CloseReader();
        void Close();
        //void Dispose();
    }
}
