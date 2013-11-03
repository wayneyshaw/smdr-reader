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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MiSMDR.DataAccessLayer;
using MiSMDR.Logger;
using MiSMDR.DBIntegrity;

namespace MiSMDR.BusinessLogicLayer
{
    public class SavedSearchManager
    {
        private string _connectionString;
        private DataProvider _provider;

        public SavedSearchManager(string connectionString, DataProvider provider)
        {
            _connectionString = connectionString;
            _provider = provider;
            DBControl control = new DBControl(connectionString, provider);
            if (!control.CheckDataAccess()) control.CreateTables();
        }

        // Retrieve all of the saved search data from the database
        public DataSet GetSavedSearchData()
        {
            DBManager manager = new DBManager(_provider, _connectionString);

            try
            {
                manager.Open();
                return manager.ExecuteDataSet(CommandType.Text, "SELECT * FROM [SavedSearches]");
            }
            catch (Exception ex)
            {
                LogManager.Log(LogEntryType.Error, SourceType.MiSMDR, "Could not retrieve Saved Search data:" + ex.ToString().Replace('\'','"'));
                return null;
            }
        }

        public SavedSearch GetSavedSearch(int ID)
        {
            using (DBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();
                SavedSearch prevSavedSearch = new SavedSearch(_connectionString, _provider);
                prevSavedSearch.ID = ID;

                manager.CreateParameters(1);
                manager.AddParameters(0, "@SavedSearchID", ID.ToString());
                DataSet returnedSearch = manager.ExecuteDataSet(CommandType.Text, "SELECT * FROM [SavedSearches] WHERE [ID] = @SavedSearchID");
                foreach (DataRow dr in returnedSearch.Tables[0].Rows)
                {
                    prevSavedSearch.Name = dr[1].ToString();
                    prevSavedSearch.Description = dr[2].ToString();
                }

                using (DBManager manager2 = new DBManager(_provider, _connectionString))
                {
                    manager2.Open();
                    manager2.CreateParameters(1);
                    manager2.AddParameters(0, "@SavedSearchID", ID.ToString());
                    DataSet returnedObjects = manager2.ExecuteDataSet(CommandType.Text, "SELECT * FROM [SavedSearchObjects] WHERE [SavedSearchID] = @SavedSearchID");
                    foreach (DataRow dr in returnedObjects.Tables[0].Rows)
                    {
                        prevSavedSearch.searchObjects.Add(new SearchObject(dr[1].ToString(), dr[2].ToString()));
                    }
                }

                return prevSavedSearch;
            }
        }

        /// <summary>
        /// Add a new saved search or update an existing saved search to the database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="objectList"></param>
        /// <param name="update"></param>
        /// <returns>Any errors that occurred in the user addition</returns>
        public List<ValidationError> ValidateSavedSearch(int ID, string name, string description, List<SearchObject> objectList, bool updating)
        {
            List<ValidationError> validationErrors = new List<ValidationError>();
            try
            {
                SavedSearch search = new SavedSearch(_connectionString, _provider);

                // Perform validation
                if (name != String.Empty)
                {
                    if (description != String.Empty)
                    {
                        if (objectList.Count < 1)
                        {
                            //If everything has been passed then set the saved search object to contain all the features
                            search.Name = name;
                            search.Description = description;
                            search.searchObjects = objectList;
                        }
                        validationErrors.Add(new ValidationError("The search cannot be for nothing"));
                    }
                    else
                    {
                        validationErrors.Add(new ValidationError("Description field cannot be blank"));
                    }
                }
                else
                {
                    validationErrors.Add(new ValidationError("Search Name field cannot be blank"));
                }

                search.ID = ID;

                if (validationErrors.Count == 0)
                {
                    // Saves the user to the database and returns an array of errors (strings) if any occurred
                    search.Save(updating);

                }
            }
            catch(Exception ex)
            {
                validationErrors.Add(new ValidationError("Unexpected Error: " + ex.ToString().Replace('\'', '"')));
            }
            return validationErrors;
        }

        public List<ValidationError> DeleteSavedSearch(int id)
        {
            List<ValidationError> errors = new List<ValidationError>();
            try
            {
                if (id != -1)
                {

                    SavedSearch savedSearchToDelete = new SavedSearch(_connectionString, _provider);
                    savedSearchToDelete.Delete(id);

                }
                else
                {
                    errors.Add(new ValidationError("Could not delete Saved Search. Invalid ID."));
                }
            }
            catch(Exception ex)
            {
                errors.Add(new ValidationError("Unexpected Error: " + ex.ToString().Replace('\'', '"')));
            }
            return errors;
        }
    }
}
