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
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MiSMDR.BusinessLogicLayer
{
    public class Contact
    {
        public Int32 ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        private string _connectionString;
        private DataProvider _provider;

        public Contact(string connectionString, DataProvider provider) 
        {
            _connectionString = connectionString;
            _provider = provider;
        }

        // Save Name / Extension to the User table
        public void Update()
        {
            using(IDBManager manager = new DBManager(_provider,_connectionString))
            {
                manager.Open();

                manager.CreateParameters(4);
                manager.AddParameters(0, "@ID", this.ID.ToString());
                manager.AddParameters(1, "@Name", this.Name);
                manager.AddParameters(2, "@Description", this.Description);
                manager.AddParameters(3, "@Email", this.Email);

                manager.ExecuteNonQuery(CommandType.Text, "UPDATE [People] SET [Name]=@Name, [Description]=@Description, [Email]=@Email WHERE [ID]=@ID");
            }
        }

        public void Create()
        {
            using(IDBManager manager = new DBManager(_provider,_connectionString))
            {
                manager.Open();

                manager.CreateParameters(3);
                manager.AddParameters(0, "@Name", this.Name);
                manager.AddParameters(1, "@Description", this.Description);
                manager.AddParameters(2, "@Email", this.Email);

                manager.ExecuteNonQuery(CommandType.Text, "INSERT INTO [People] ([Name],[Description],[Email]) VALUES (@Name,@Description,@Email)");
            }
        }
        //Return the last ID created in this table
        public string GetLastRowID()
        {
            using(IDBManager manager = new DBManager(_provider,_connectionString))
            {
                string newID = "";
                manager.Open();
                IDataReader myReader = manager.ExecuteReader(CommandType.Text, "SELECT max(ID) from People");
                while (myReader.Read())
                {
                    newID = myReader.GetValue(0).ToString();
                    
                }
                manager.CloseReader();
                if (newID != String.Empty) return newID;
                else return "0";
            }
        }
        //Return the last ID created in this table
        public string idOfContact(string contactName)
        {
            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                string newID = "";
                manager.Open();
                IDataReader myReader = manager.ExecuteReader(CommandType.Text, "SELECT ID from People WHERE Name = '"+contactName+"'");
                while (myReader.Read())
                {
                    newID = myReader.GetValue(0).ToString(); //assigns the last ID matching the name if there are multiple exact names
                }
                manager.CloseReader();
                return newID;
            }
        }

        // Delete the user with the specified id from the database
        public void Delete(int id)
        {
            using(IDBManager manager = new DBManager(_provider,_connectionString))
            {
                manager.Open();

                manager.CreateParameters(1);
                manager.AddParameters(0, "@ID", id);

                // Delete the user from the database
                manager.ExecuteNonQuery(CommandType.Text, "DELETE FROM [InternalExtensions] WHERE [PersonID]=@ID");
                manager.ExecuteNonQuery(CommandType.Text, "DELETE FROM [ExternalNumbers] WHERE [PersonID]=@ID");
                manager.ExecuteNonQuery(CommandType.Text, "DELETE FROM [People] WHERE [ID]=@ID");
            }
        }
    }
}
