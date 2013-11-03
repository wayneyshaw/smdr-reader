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
using MiSMDR.DataAccessLayer;
using MiSMDR.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MiSMDR.BusinessLogicLayer
{
    public class PhoneNumber
    {
        public Int32 ContactID { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        private string _connectionString;
        private DataProvider _provider;

        public PhoneNumber(string connectionString, DataProvider provider) 
        {
            _connectionString = connectionString;
            _provider = provider;
        }

        // Save Phone Number to the appropriate table
        public void Update(string oldnumber)
        {
            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();

                manager.CreateParameters(5);
                manager.AddParameters(0, "@ContactID", this.ContactID.ToString());
                manager.AddParameters(1, "@OldNumber", oldnumber);
                manager.AddParameters(2, "@NewNumber", this.Number);
                manager.AddParameters(3, "@Type", this.Type);
                manager.AddParameters(4, "@Description", this.Description);

                manager.ExecuteNonQuery(CommandType.Text, "UPDATE [Numbers] SET [PersonID]=@ContactID, [Number]=@NewNumber, [Type]=@Type, [Description]=@Description WHERE [PersonID]=@ContactID AND [Number]=@OldNumber");
            }
        }
        // Save Phone Number to the appropriate table
        public void Update(int ID)
        {
            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();

                manager.CreateParameters(5);
                manager.AddParameters(0, "@ContactID", this.ContactID.ToString());
                manager.AddParameters(1, "@ID", ID);
                manager.AddParameters(2, "@NewNumber", this.Number);
                manager.AddParameters(3, "@Type", this.Type);
                manager.AddParameters(4, "@Description", this.Description);

                manager.ExecuteNonQuery(CommandType.Text, "UPDATE [Numbers] SET [PersonID]=@ContactID, [Number]=@NewNumber, [Type]=@Type, [Description]=@Description WHERE [ID]=@ID");
            }
        }
        // Save Phone Number to the appropriate table
        public void Create()
        {
            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();

                manager.CreateParameters(4);
                manager.AddParameters(0, "@ContactID", this.ContactID.ToString());
                manager.AddParameters(1, "@NewNumber", this.Number);
                manager.AddParameters(2, "@Type", this.Type);
                manager.AddParameters(3, "@Description", this.Description);
                manager.ExecuteNonQuery(CommandType.Text, "INSERT INTO [Numbers] ([PersonID],[Number],[Type],[Description]) VALUES (@ContactID,@NewNumber,@Type,@Description)");
            }
        }
        // Delete the user with the specified id from the database
        public void Delete(int contactID, string phoneNumber, string type)
        {
            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();

                manager.CreateParameters(2);
                manager.AddParameters(0, "@ContactID", contactID);
                manager.AddParameters(1, "@PhoneNumber", phoneNumber);

                // Delete the user from the database
                manager.ExecuteNonQuery(CommandType.Text, "DELETE FROM [Numbers] WHERE [PersonID]=@ContactID AND [Number]=@PhoneNumber");

            }
        }
        // Delete the user with the specified id from the database
        public void Delete(int ID)
        {
            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();

                manager.CreateParameters(1);
                manager.AddParameters(0, "@ID", ID);

                // Delete the user from the database
                manager.ExecuteNonQuery(CommandType.Text, "DELETE FROM [Numbers] WHERE [ID]=@ID");
            }
        }
    }
}
