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
    //Code from Robert Simpson http://sqlite.phxsoftware.com/forums/p/348/1410.aspx
    //Based on code from aspalliance.com/837 by Joydip Kanjilal
    [SQLiteFunction(Name = "REGEXP", Arguments = 2, FuncType = FunctionType.Scalar)]
    class MyRegEx : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(Convert.ToString(args[1]), Convert.ToString(args[0]));
        }
    }
    
    //Code written by Niko Roberts 12-Jan-2010
    [SQLiteFunction(Name = "TRUNCATE", Arguments = 1, FuncType = FunctionType.Scalar)]
    class MyTruncate : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            try
            {
                return Math.Truncate(Convert.ToDouble(args[0]));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
    //Code written by Niko Roberts 20-Jan-2010
    [SQLiteFunction(Name = "TRUNCATE", Arguments = 2, FuncType = FunctionType.Scalar)]
    class MyTruncate2 : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            try
            {
                double returnVal;
                if (Convert.ToDouble(args[1]) > 0)
                {
                    double convertedArg1 = Math.Pow(10, Convert.ToDouble(args[1]));
                    double convertedArg0 = Convert.ToDouble(args[0]) * convertedArg1;
                    returnVal = Math.Truncate(convertedArg0) / convertedArg1;
                }
                else returnVal = Math.Truncate(Convert.ToDouble(args[0]));
                return returnVal;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }

    public sealed class DBManager : IDBManager, IDisposable
    {
        private IDbConnection idbConnection;
        private IDataReader iDataReader;
        private IDbCommand idbCommand;
        private DataProvider providerType;
        private IDbTransaction idbTransaction = null;
        private IDbDataParameter[] idbParameters = null;
        private string strConnection;

        public DBManager() { }
        public DBManager(DataProvider providerType)
        {
            this.providerType = providerType;
        }
        public DBManager(DataProvider providerType, string connectionString)
        {
            this.providerType = providerType;
            this.strConnection = connectionString;
        }

        public DataProvider ProviderType
        {
            get
            {
                return providerType;
            }
            set
            {
                providerType = value;
            }
        }

        public string ConnectionString
        {
            get
            {
                return strConnection;
            }
            set
            {
                strConnection = value;
            }
        }

        public IDbConnection Connection
        {
            get
            {
                return idbConnection;
            }
        }

        public IDbTransaction Transaction
        {
            get
            {
                return idbTransaction;
            }
        }

        public IDataReader DataReader
        {
            get
            {
                return iDataReader;
            }
            set
            {
                iDataReader = value;
            }
        }

        public IDbCommand Command
        {
            get
            {
                return idbCommand;
            }
        }

        public IDbDataParameter[] parameters
        {
            get
            { 
                return idbParameters;
            }
        }

        public void Open()
        {
            idbConnection = DBManagerFactory.GetConnection(this.providerType);
            idbConnection.ConnectionString = this.ConnectionString;
            if (idbConnection.State != ConnectionState.Open)
            {
                idbConnection.Open();
            }
            this.idbCommand = DBManagerFactory.GetCommand(this.providerType);
        }

        public void BeginTransaction()
        {
            if (this.idbTransaction == null)
                idbTransaction = DBManagerFactory.GetTransaction(this.providerType);
            this.idbCommand.Transaction = idbTransaction;
        }

        public void CommitTransaction()
        {
            if (this.idbTransaction != null)
                this.idbTransaction.Commit();
            idbTransaction = null;
        }

        public void CreateParameters(int paramsCount)
        {
            idbParameters = new IDbDataParameter[paramsCount];
            idbParameters = DBManagerFactory.GetParameters(this.providerType, paramsCount);
        }

        public void AddParameters(int index, string paramName, object objValue)
        {
            if (index < idbParameters.Length)
            {
                idbParameters[index].ParameterName = paramName;
                idbParameters[index].Value = objValue;
                idbParameters[index].Direction = ParameterDirection.Input;
            }
        }
        public void AddParameters(int index, string paramName, object objValue, ParameterDirection direction, int size)
        {
            if (index < idbParameters.Length)
            {
                idbParameters[index].ParameterName = paramName;
                idbParameters[index].Value = objValue;
                idbParameters[index].Direction = direction;
                idbParameters[index].Size = size;
            }
        }

        public IDataReader ExecuteReader(System.Data.CommandType commandType, string commandText)
        {
            this.idbCommand = DBManagerFactory.GetCommand(providerType);
            idbCommand.Connection = this.Connection;
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.parameters);
            this.DataReader = idbCommand.ExecuteReader();
            idbCommand.Parameters.Clear();
            return this.DataReader;
        }

        private void AttachParameters(IDbCommand command, IDbDataParameter[] commandParameters)
        {
            foreach (IDbDataParameter idbParameter in commandParameters)
            {
                if ((idbParameter.Direction == ParameterDirection.InputOutput) && (idbParameter.Value == null))
                {
                    idbParameter.Value = DBNull.Value;
                }
                command.Parameters.Add(idbParameter);
            }
        }


        private void PrepareCommand(IDbCommand command, IDbConnection connection, IDbTransaction transaction, CommandType commandType, string commandText, IDbDataParameter[] commandParameters)
        {
            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (transaction != null)
            {
                command.Transaction = transaction;
            }

            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
        }

        public DataSet ExecuteDataSet(CommandType commandType, string commandText)
        {
            this.idbCommand = DBManagerFactory.GetCommand(this.providerType);
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.parameters);
            IDbDataAdapter dataAdapter = DBManagerFactory.GetDataAdapter(this.providerType);
            dataAdapter.SelectCommand = idbCommand;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            idbCommand.Parameters.Clear();
            return dataSet;
        }

        public object ExecuteScalar(CommandType commandType, string commandText)
        {
            this.idbCommand = DBManagerFactory.GetCommand(this.providerType);
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.parameters);
            object returnValue = idbCommand.ExecuteScalar();
            idbCommand.Parameters.Clear();
            return returnValue;
        }

        public int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            this.idbCommand = DBManagerFactory.GetCommand(this.providerType);
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.parameters);
            int returnValue = idbCommand.ExecuteNonQuery();
            idbCommand.Parameters.Clear();
            return returnValue;
        }

        public void CloseReader()
        {
            if (this.DataReader != null)
            {
                if (!this.DataReader.IsClosed)
                {
                    this.DataReader.Close();
                }
            }
        }

        public void Close()
        {
            try
            {
                if (idbConnection.State != ConnectionState.Closed)
                {
                    idbConnection.Close();
                }
            }
            catch (Exception)
            {

            }
        }

       public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Close();
            this.idbCommand = null;
            this.idbTransaction = null;
            this.idbConnection = null;
        }
    }
}
