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
using System.Text.RegularExpressions;
using MiSMDR.DBIntegrity;

namespace MiSMDR.BusinessLogicLayer
{
    public class ContactManager
    {
        private string _connectionString;
        private DataProvider _provider;
        public string _lastid;

        public ContactManager(string connectionString, DataProvider provider)
        {
            _connectionString = connectionString;
            _provider = provider;
            _lastid = "";
            DBControl control = new DBControl(connectionString, provider);
            if (!control.CheckDataAccess()) control.CreateTables();
        }

        // Retrieve all of the user data from the database
        public DataSet GetContactData()
        {
            ArrayList errors = new ArrayList();
            using(DBManager manager = new DBManager(_provider, _connectionString))
            {
                try
                {
                    manager.Open();
                    return manager.ExecuteDataSet(CommandType.Text, "SELECT ID,Name,Description,Email FROM [People] ORDER BY [Name] ASC");
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public DataSet GetContactData(string name, string email, string description)
        {
            using(DBManager manager = new DBManager(_provider, _connectionString))
            {
                try
                {
                    manager.Open();
                    string whereString = " WHERE 1=1 ";
                    if (name != String.Empty) whereString += "AND Name LIKE '%" + name + "%' ";
                    if (email != String.Empty) whereString += "AND Email LIKE '%" + email + "%' ";
                    if (description != String.Empty) whereString += "AND Description LIKE '%" + description + "%' ";
                    return manager.ExecuteDataSet(CommandType.Text, "SELECT ID,Name,Description,Email FROM [People] " + whereString + " ORDER BY Name ASC");
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public DataSet GetContactList()
        {
            using (DBManager manager = new DBManager(_provider, _connectionString))
            {
                try
                {
                    manager.Open();
                    return manager.ExecuteDataSet(CommandType.Text, "SELECT [Name] FROM [People] ORDER BY [Name]");
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Add a new user or update an existing user to the database
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="extension"></param>
        /// <returns>Any errors that occurred in the user addition</returns>
        public List<ValidationError> UpdateContact(string ID, string name, string description, string email)
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            Contact contact = new Contact(_connectionString, _provider);

            // Perform validation
            try
            {
                if (ID != String.Empty)
                {
                    if (name != String.Empty)
                    {
                        contact.ID = Convert.ToInt32(ID);
                        contact.Name = name;
                        contact.Description = description;
                        contact.Email = email;
                    }
                    else
                    {
                        validationErrors.Add(new ValidationError("Contact Name field cannot be blank"));
                    }
                }
                else
                {
                    validationErrors.Add(new ValidationError("ID cannot be blank"));
                }

                if (validationErrors.Count == 0)
                {
                    // Saves the user to the database and returns an array of errors (strings) if any occurred
                    contact.Update();
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(new ValidationError("Unexpected Error: "+ex.ToString()));
            }
            return validationErrors;
        }
        /// <summary>
        /// Add a new user or update an existing user to the database
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="extension"></param>
        /// <returns>Any errors that occurred in the user addition</returns>
        public List<ValidationError> AddContact(string name, string description, string email)
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            Contact contact = new Contact(_connectionString,_provider);

            // Perform validation
            try
            {
                if (name != String.Empty)
                {
                    contact.Name = name;
                    contact.Description = description;
                    contact.Email = email;
                }
                else
                {
                    validationErrors.Add(new ValidationError("Contact Name field cannot be blank"));
                }


                if (validationErrors.Count == 0)
                {
                    // Saves the user to the database and sets the ID of the contact created
                    contact.Create();
                    _lastid = contact.GetLastRowID();
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(new ValidationError("Unexpected Error: " + ex.ToString().Replace('\'', '"')));
            }
            return validationErrors;
        }

        public List<ValidationError> DeleteContact(int id)
        {
            List<ValidationError> validationErrors = new List<ValidationError>();
            try
            {
                if (id != -1)
                {
                    Contact contactToDelete = new Contact(_connectionString, _provider);
                }
                else
                {
                    validationErrors.Add(new ValidationError("Contact ID specified for deletion is not valid."));
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(new ValidationError("Unexpected Error: " + ex.ToString().Replace('\'', '"')));
            }
            return validationErrors;
        }
    }
}
