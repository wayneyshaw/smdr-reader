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
    public class PhoneNumberManager
    {
        private string _connectionString;
        private DataProvider _provider;

        public PhoneNumberManager(string connectionString, DataProvider provider)
        {
            _connectionString = connectionString;
            _provider = provider;
            DBControl control = new DBControl(connectionString, provider);
            if (!control.CheckDataAccess()) control.CreateTables();
        }

        // Retrieve all of the user data from the database
        public DataSet GetPhoneNumberData()
        {
            using(IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();
                return manager.ExecuteDataSet(CommandType.Text, "SELECT Name,Number,Description,Type,PersonID,Email,PersonDesc,NumberID FROM allNumbers");
            }
        }

        public DataSet GetPhoneNumberData(int contactID, string number, string description)
        {
            string idString = "";

            if (contactID != -1) idString = "AND PersonID = '" + contactID + "' ";

            string whereString = idString;
            if (number != String.Empty) whereString += " AND Number LIKE '%" + number + "%' ";
            if (description != String.Empty) whereString += "AND Description LIKE '%" + description + "%' ";

            using(IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();
                string sqlCommand = "SELECT Name,Number,Description,Type,PersonID,Email,PersonDesc,NumberID FROM allNumbers WHERE 1=1 " + whereString;
                return manager.ExecuteDataSet(CommandType.Text, sqlCommand);
            }
        }

        public DataSet GetPhoneNumberData(int contactID, string number, string description, string type)
        {
            string whereString = "";

            // Create Where conditions
            if (contactID != -1) whereString += "AND PersonID = '" + contactID.ToString() + "' ";
            if (number != String.Empty) whereString += " AND Number LIKE '%" + number + "%' ";
            if (description != String.Empty) whereString += "AND Description LIKE '%" + description + "%' ";

            using(IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();
                string sqlCommand = "SELECT Name,Number,Description,Type,PersonID,Email,PersonDesc,NumberID FROM allNumbers WHERE 1=1 " + whereString;
                return manager.ExecuteDataSet(CommandType.Text, sqlCommand);
            }
        }

        /// <summary>
        /// Add a new phone number
        /// </summary>
        /// <param name="contactID"></param>
        /// <param name="newnumber"></param>
        /// <param name="description"></param>
        /// <param name="type"></param>
        /// <returns>Any errors that occurred in the phone number addition</returns>
        public List<ValidationError> AddPhoneNumber(string contactID, string newnumber, string description, string type)
        {
            List<ValidationError> validationErrors = new List<ValidationError>();
            PhoneNumber phoneNumber = new PhoneNumber(_connectionString,_provider);
            int convertedID = -1;

            try
            {                
                if (contactID != String.Empty)
                {
                    try
                    {
                        convertedID = Convert.ToInt32(contactID);
                    }
                    catch (Exception)
                    {
                        validationErrors.Add(new ValidationError("The Contact ID should be a number"));
                    }

                    if (newnumber != String.Empty)
                    {
                        if (Regex.Match(newnumber, @"^[+]?([0-9]*[\.\s\-\(\)]|[0-9]+){3,24}$").Success)
                        {
                            if ((type == "Internal") || (type == "External"))
                            {
                                phoneNumber.Number = newnumber;
                                phoneNumber.Description = description;
                                phoneNumber.Type = type;
                                phoneNumber.ContactID = convertedID;
                            }
                            else
                            {
                                validationErrors.Add(new ValidationError("Invalid Type specified."));
                            }
                        }
                        else
                        {
                            validationErrors.Add(new ValidationError("Entered number is not a valid phone number"));
                        }
                    }
                    else
                    {
                        validationErrors.Add(new ValidationError("Phone Number field cannot be blank"));
                    }
                }
                else
                {
                    validationErrors.Add(new ValidationError("Contact ID must be a valid number"));
                }

                if (validationErrors.Count == 0)
                {
                    // Saves the user to the database and returns an array of errors (strings) if any occurred
                    phoneNumber.Create();
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(new ValidationError("Unexpected Error: "+ex.ToString()));
            }
            return validationErrors;
        }

        /// Add a new phone number
        /// </summary>
        /// <param name="contactID"></param>
        /// <param name="newnumber"></param>
        /// <param name="description"></param>
        /// <param name="type"></param>
        /// <returns>Any errors that occurred in the phone number addition</returns>
        public List<ValidationError> AddPhoneNumber(string contactName, string newnumber, string type)
        {
            List<ValidationError> validationErrors = new List<ValidationError>();
            PhoneNumber phoneNumber = new PhoneNumber(_connectionString, _provider);
            int contactID = -1;

            try
            {
                if (contactName != String.Empty)
                {
                    try
                    {
                        contactID = GetContactID(contactName);
                    }
                    catch (Exception ex)
                    {
                        validationErrors.Add(new ValidationError("There was an unexpected error finding the contact. "+ex.ToString()));
                    }

                    if (newnumber != String.Empty)
                    {
                        if (Regex.Match(newnumber, @"^[+]?([0-9]*[\.\s\-\(\)]|[0-9]+){3,24}$").Success)
                        {
                            if ((type == "Internal") || (type == "External"))
                            {
                                phoneNumber.Number = newnumber;
                                phoneNumber.Description = "";
                                phoneNumber.Type = type;
                                phoneNumber.ContactID = contactID;
                                phoneNumber.Create();
                            }
                            else
                            {
                                validationErrors.Add(new ValidationError("Invalid Type specified."));
                            }
                        }
                        else
                        {
                            validationErrors.Add(new ValidationError("Entered number is not a valid phone number"));
                        }
                    }
                    else
                    {
                        validationErrors.Add(new ValidationError("Phone Number field cannot be blank"));
                    }
                }
                else
                {
                    validationErrors.Add(new ValidationError("The Contact name is not valid"));
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(new ValidationError("Unexpected Error: " + ex.ToString()));
            }
            return validationErrors;
        }

        //test method to see if a contact exists
        public int GetContactID(string contactName)
        {
            Contact contact = new Contact(_connectionString, _provider);

            //disabled for now - so it will always be a new contact ... Fred - Mobile
            if (1 == 0) //(contact.idOfContact(contactName) != String.Empty)
            {
                //return Convert.ToInt32(contact.idOfContact(contactName));
            }
            else
            {
                contact.ID = Convert.ToInt32(contact.GetLastRowID()) + 1; //get the max ID number
                contact.Name = contactName;
                contact.Description = ""; //disabled information
                contact.Email = ""; //disabled information
                contact.Create();
                return contact.ID; // return the new ID
            }
        }

        public string GetLastContactID()
        {
            Contact contact = new Contact(_connectionString, _provider);
            return contact.GetLastRowID();
        }

        //for threading the contact importer we need a number adder that doesnt have return values
        public void AddPhoneNumberNoReturn(object cont)
        {
            contactNumber miNumber = ((contactNumber) cont);
            AddPhoneNumber(miNumber.id, miNumber.number, miNumber.description, miNumber.type);
        }

        public List<ValidationError> UpdatePhoneNumber(string contactID, string oldnumber, string newnumber, string description, string type)
        {
            List<ValidationError> validationErrors = new List<ValidationError>();
            PhoneNumber phoneNumber = new PhoneNumber(_connectionString, _provider);

            try
            {
                // Perform validation
                try
                {
                    int convertedID = Convert.ToInt32(contactID);
                    phoneNumber.ContactID = convertedID;
                }
                catch (Exception)
                {
                    validationErrors.Add(new ValidationError("The Contact ID should be a number"));
                }

                if (newnumber != String.Empty)
                {
                    if (Regex.Match(newnumber, @"^[+]?([0-9]*[\.\s\-\(\)]|[0-9]+){3,24}$").Success)
                    {
                        if ((type == "Internal") || (type == "External"))
                        {
                            phoneNumber.Number = newnumber;
                            phoneNumber.Description = description;
                            phoneNumber.Type = type;
                        }
                        else
                        {
                            validationErrors.Add(new ValidationError("Invalid Type specified."));
                        }

                    }
                    else
                    {
                        validationErrors.Add(new ValidationError("Entered number is not a valid phone number"));
                    }
                }
                else
                {
                    validationErrors.Add(new ValidationError("Phone Number field cannot be blank"));
                }

                if (validationErrors.Count == 0)
                {
                    // Saves the user to the database and returns an array of errors (strings) if any occurred
                    phoneNumber.Update(oldnumber);
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(new ValidationError("Unexpected Error: " + ex.ToString().Replace('\'', '"')));
            }
            return validationErrors;
        }

        public List<ValidationError> UpdatePhoneNumber(int contactID, string contactName, string oldnumber, string newnumber, string type)
        {
            List<ValidationError> validationErrors = new List<ValidationError>();
            PhoneNumber phoneNumber = new PhoneNumber(_connectionString, _provider);
            ContactManager conManager = new ContactManager(_connectionString, _provider);
            try
            {

                List<ValidationError> conErrors = conManager.UpdateContact(contactID.ToString(), contactName, "", "");
                foreach (ValidationError err in conErrors)
                {
                    validationErrors.Add(err);
                }
                if (contactName != String.Empty)
                {
                    if (newnumber != String.Empty)
                    {
                        if (Regex.Match(newnumber, @"^[+]?([0-9]*[\.\s\-\(\)]|[0-9]+){3,24}$").Success)
                        {
                            if ((type == "Internal") || (type == "External"))
                            {
                                phoneNumber.ContactID = contactID;
                                phoneNumber.Number = newnumber;
                                phoneNumber.Description = "";
                                phoneNumber.Type = type;
                                phoneNumber.Update(oldnumber);
                            }
                            else
                            {
                                validationErrors.Add(new ValidationError("Invalid Contact Type specified."));
                            }

                        }
                        else
                        {
                            validationErrors.Add(new ValidationError("Entered number is not a valid phone number"));
                        }
                    }
                    else
                    {
                        validationErrors.Add(new ValidationError("Number field cannot be blank"));
                    }
                }
                else
                {
                    validationErrors.Add(new ValidationError("Contact Name field cannot be blank"));
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(new ValidationError("Unexpected Error: " + ex.ToString()));
            }
            return validationErrors;
        }

        public List<ValidationError> DeletePhoneNumber(string contactID, string number, string type)
        {
            List<ValidationError> validationErrors = new List<ValidationError>();
            int convertedID = -1;
            try
            {
                try
                {
                    convertedID = Convert.ToInt32(contactID);
                }
                catch (Exception)
                {
                    validationErrors.Add(new ValidationError("The Contact ID should be a number"));
                }

                if (Regex.Match(number, @"^[+]?([0-9]*[\.\s\-\(\)]|[0-9]+){3,24}$").Success)
                {
                    if ((type == "Internal") || (type == "External"))
                    {
                    }
                    else
                    {
                        validationErrors.Add(new ValidationError("Could not delete Phone Number. Invalid Type specified."));
                    }
                }
                else
                {
                    validationErrors.Add(new ValidationError("Could not delete Phone Number. The Number is not a valid phone number"));
                }
                if ((validationErrors.Count == 0) && (convertedID != -1))
                {
                    PhoneNumber numberToDelete = new PhoneNumber(_connectionString, _provider);
                    numberToDelete.Delete(convertedID, number, type);
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(new ValidationError("Unexpected Error: " + ex.ToString().Replace('\'', '"')));
            }
            return validationErrors;
        }
        public List<ValidationError> DeletePhoneNumber(int numberID)
        {
            List<ValidationError> validationErrors = new List<ValidationError>();
            try
            {
                PhoneNumber numberToDelete = new PhoneNumber(_connectionString, _provider);
                numberToDelete.Delete(numberID);
            }
            catch (Exception ex)
            {
                validationErrors.Add(new ValidationError("Unexpected Error: " + ex.ToString().Replace('\'', '"')));
            }
            return validationErrors;
        }
    }
    public class contactNumber
    {
        public string id;
        public string description;
        public string number;
        public string type;

        public contactNumber(string desc, string num)
        {
            description = desc.Trim();
            number = num.Trim().Replace("-", "").Replace("\"", "").Replace("'", "");
        }
    }
}
