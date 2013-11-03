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
using System.Collections;

namespace MiSMDR.BusinessLogicLayer
{
    public class SavedSearch
    {
        public Int32 ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<SearchObject> searchObjects { get; set; }
        private string _connectionString;
        private DataProvider _provider;

        public SavedSearch(string connectionString, DataProvider provider) 
        {
            _connectionString = connectionString;
            _provider = provider;
            searchObjects = new List<SearchObject>();
        }

        // Save Search to the SavedSearches table
        public void Save(bool updating)
        {
            using(IDBManager manager = new DBManager(_provider,_connectionString))
            {
                manager.Open();

                // If the user already exists then update/overwrite the existing data,
                // Otherwise, add the new user to the database
                if (updating)
                {
                    manager.CreateParameters(3);
                    manager.AddParameters(0, "@ID", this.ID.ToString());
                    manager.AddParameters(1, "@Name", this.Name);
                    manager.AddParameters(2, "@Description", this.Description);
                    //Update the SavedSearches table
                    manager.ExecuteNonQuery(CommandType.Text, "UPDATE [SavedSearches] SET [Name]=@Name, [Description]=@Description WHERE [ID]=@ID");

                    //Update the SavedSearchObjects table
                    foreach (SearchObject currentObject in searchObjects)
                    {
                        using (IDBManager manager2 = new DBManager(_provider,_connectionString))
                        {
                            manager2.Open();
                            manager2.CreateParameters(3);
                            manager2.AddParameters(0, "@SavedSearchID", this.ID.ToString());
                            manager2.AddParameters(1, "@Name", currentObject.objectName);
                            manager2.AddParameters(2, "@Value", currentObject.objectValue);
                            manager2.ExecuteNonQuery(CommandType.Text, "UPDATE [SavedSearchObjects] SET [Value]=@Value WHERE [SavedSearchID]=@SavedSearchID AND [Name]=@Name");
                        }
                    }
                }
                else
                {
                    //Insert into the SavedSearches table
                    string newID = "-1";
                    manager.CreateParameters(3);
                    manager.AddParameters(0, "@Name", this.Name);
                    manager.AddParameters(1, "@Description", this.Description);
                    if (_provider == DataProvider.SqlServer)
                    {
                        manager.AddParameters(2, "@ResultID", newID, ParameterDirection.Output, 3);
                        manager.ExecuteNonQuery(CommandType.Text, "INSERT INTO [SavedSearches] ([Name],[Description],[Time]) VALUES (@Name,@Description,GETDATE()) SET @ResultID = SCOPE_IDENTITY()");
                        newID = manager.parameters[2].Value.ToString();
                    }
                    else if (_provider == DataProvider.Sqlite)
                    {
                        manager.ExecuteNonQuery(CommandType.Text, "INSERT INTO [SavedSearches] ([Name],[Description],[Time]) VALUES (@Name,@Description,current_timestamp)");
                        IDataReader myReader = manager.ExecuteReader(CommandType.Text, "SELECT max(ID) from SavedSearches");
                        while (myReader.Read())
                        {
                            newID = myReader.GetValue(0).ToString();
                        }
                        manager.CloseReader();
                    }

                    //Update the SavedSearchObjects table
                    foreach (SearchObject currentObject in searchObjects)
                    {
                        using (IDBManager manager2 = new DBManager(_provider,_connectionString))
                        {
                            manager2.Open();
                            manager2.CreateParameters(3);
                            manager2.AddParameters(0, "@SavedSearchID", newID.ToString());
                            manager2.AddParameters(1, "@Name", currentObject.objectName);
                            manager2.AddParameters(2, "@Value", currentObject.objectValue);

                            manager2.ExecuteNonQuery(CommandType.Text, "INSERT INTO [SavedSearchObjects] ([SavedSearchID],[Name],[Value]) VALUES (@SavedSearchID,@Name,@Value)");
                        }
                    }
                }                
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

                // Delete the Saved Search from the SavedSearchObjects table
                manager.ExecuteNonQuery(CommandType.Text, "DELETE FROM [SavedSearchObjects] WHERE [SavedSearchID]=@ID");
                // Delete the Saved Search from the SavedSearches table
                manager.ExecuteNonQuery(CommandType.Text, "DELETE FROM [SavedSearches] WHERE [ID]=@ID");
            }
        }
    }
}
