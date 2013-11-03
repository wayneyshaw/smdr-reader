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
using MiSMDR.DataAccessLayer;
using MiSMDR.Logger;
using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace MiSMDR.BusinessLogicLayer
{
    public sealed class CallCategory
    {
        private int _ID;
        private Regex _reg;
        private string _type;
        private string _name;
        private int _cost;
        private int _blockSize;
        private int _connectionCost;
        private int _priority;
        private int _chargeUnfinished;

        private string _connectionString;
        private DataProvider _provider;

        // Setup the class by setting the local connection string variable and the LogManager
        // connection string
        public CallCategory(string connectionString, DataProvider provider) 
        {
            _connectionString = connectionString;
            _provider = provider;

            LogManager.SetConnectionString(connectionString,_provider);
        }

        // Initiate all of the class local variables
        public CallCategory(int ID, Regex regex, string type, string name, int cost, int blockSize, int connectionCost, int priority, int chargeUnfinished, string connectionString, DataProvider provider)
        {
            _ID = ID;
            _reg = regex;
            _type = type;
            _blockSize = blockSize;
            _cost = cost;
            _name = name;
            _connectionCost = connectionCost;
            _priority = priority;
            _chargeUnfinished = chargeUnfinished;

            _connectionString = connectionString;
            _provider = provider;

            LogManager.SetConnectionString(connectionString,_provider);
        }

        // Save/update the CallCategory to the database
        public void Save(bool updating)
        {
            //string[] errors = null;

            using(IDBManager dbManager = new DBManager(_provider,_connectionString))
            {
                dbManager.Open();

                dbManager.CreateParameters(9);
                dbManager.AddParameters(0, "@ID", this.ID.ToString());
                dbManager.AddParameters(1, "@RegularExpression", this.RegularExpression.ToString());
                dbManager.AddParameters(2, "@Type", this.Type);
                dbManager.AddParameters(3, "@BlockSize", this.BlockSize);
                dbManager.AddParameters(4, "@Cost", this.Cost);
                dbManager.AddParameters(5, "@Name", this.Name);
                dbManager.AddParameters(6, "@ConnectionCost", this.ConnectionCost);
                dbManager.AddParameters(7, "@Priority", this.Priority);
                dbManager.AddParameters(8, "@ChargeUnfinished", this.ChargeUnfinished);

                if (updating)
                {
                    // Update the call category
                    if (_provider == DataProvider.SqlServer)
                    {
                        dbManager.ExecuteNonQuery(CommandType.Text, "UPDATE [CallCategory] SET [Regular Expression]=@RegularExpression, [Type]=@Type, [Block Size]=@BlockSize, [Cost]=@Cost, [Name]=@Name, [Connection Cost]=@ConnectionCost, [Priority]=@Priority, [Charge Unfinished]=@ChargeUnfinished WHERE [ID]=@ID");
                    }
                    else if (_provider == DataProvider.Sqlite)
                    {
                        dbManager.ExecuteNonQuery(CommandType.Text, "UPDATE [CallCategory] SET [Regular Expression]=@RegularExpression, [Type]=@Type, [Block Size]=@BlockSize, [Cost]=@Cost, [Name]=@Name, [Connection Cost]=@ConnectionCost, [Priority]=@Priority, [Charge Unfinished]=@ChargeUnfinished WHERE [ID]=@ID");
                    }
                }

                else
                {
                    // Save the new call category
                    if (_provider == DataProvider.SqlServer)
                    {
                        dbManager.ExecuteNonQuery(CommandType.Text, "INSERT INTO [CallCategory]([Regular Expression],[Type],[Block Size],[Cost],[Name],[Connection Cost],[Priority],[Charge Unfinished]) VALUES (@RegularExpression,@Type,@BlockSize,@Cost,@Name,@ConnectionCost,@Priority,@ChargeUnfinished)");
                    }
                    else if (_provider == DataProvider.Sqlite)
                    {
                        dbManager.ExecuteNonQuery(CommandType.Text, "INSERT INTO [CallCategory]([Regular Expression],[Type],[Block Size],[Cost],[Name],[Connection Cost],[Priority],[Charge Unfinished]) VALUES (@RegularExpression,@Type,@BlockSize,@Cost,@Name,@ConnectionCost,@Priority,@ChargeUnfinished)");
                    }
                }
            }
        }

        //Return the last ID created in this table
        public string GetLastRowID()
        {
            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                string newID = "";
                manager.Open();
                IDataReader myReader = manager.ExecuteReader(CommandType.Text, "SELECT max(ID) from [CallCategory]");
                while (myReader.Read())
                {
                    newID = myReader.GetValue(0).ToString();
                }
                manager.CloseReader();
                if (newID != String.Empty) return newID;
                else return "0";
            }
        }

        // Delete the call category at the specified ID
        public void Delete(int id)
        {
            //string[] errors = null;

            using(IDBManager dbManager = new DBManager(_provider,_connectionString))
            {
                dbManager.Open();

                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@ID", id);

                dbManager.ExecuteNonQuery(CommandType.Text, "DELETE FROM [CallCategory] WHERE [ID]=@ID");
               
            }
        }

        // Public structs
        # region Structs
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public int BlockSize
        {
            get { return _blockSize; }
            set { _blockSize = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        public Regex RegularExpression
        {
            get { return _reg; }
            set { _reg = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int ConnectionCost
        {
            get { return _connectionCost; }
            set { _connectionCost = value; }
        }
        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        public int ChargeUnfinished
        {
            get { return _chargeUnfinished; }
            set { _chargeUnfinished = value; }
        }
        #endregion
    }
}
