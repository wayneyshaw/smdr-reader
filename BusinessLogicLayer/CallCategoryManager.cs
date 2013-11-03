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
using System.Text.RegularExpressions;
using MiSMDR.DataAccessLayer;
using MiSMDR.Logger;
using MiSMDR.DBIntegrity;

namespace MiSMDR.BusinessLogicLayer
{
    /*
     * The CallCategoryManager class is used to manage the individual CallCategory objects and
     * acts as a controller between the main class and the CallCategory class.
     */ 
    public class CallCategoryManager
    {
        private string _connectionString;
        private DataProvider _provider;

        public CallCategoryManager(string connectionString, DataProvider provider)
        {
            _connectionString = connectionString;
            _provider = provider;
            DBControl control = new DBControl(connectionString, provider);
            if (!control.CheckDataAccess()) control.CreateTables();
        }

        // Retrieve all of the call cost data from the database. This can then be iterated through
        // to retrieve the different call cost types and their related connection/per minute costs
        public DataSet GetCallCostData()
        {
            using(IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();
                return manager.ExecuteDataSet(CommandType.Text, "SELECT [ID],[Name],'' AS [Filter],[Regular Expression],[Block Size],Cost AS [Cost Per Block],[Connection Cost],[Type],[Priority],[Charge Unfinished] FROM [CallCategory]");
            }
        }

        public DataSet GetCallCostData(string reg, string name, string connCost, string blockSize, string costPerBlock)
        {
            using(IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();
                string whereString = " ";
                if (reg != String.Empty) whereString += "AND Regular_Expression LIKE '%" + reg + "%' ";
                if (name != String.Empty) whereString += "AND Name LIKE '%" + name + "%' ";
                if (connCost != String.Empty) whereString += "AND Connection_Cost LIKE '%" + connCost + "%' ";
                if (blockSize != String.Empty) whereString += "AND Block_Size LIKE '%" + blockSize + "%' ";
                if (costPerBlock != String.Empty) whereString += "AND Cost LIKE '%" + costPerBlock + "%' ";

                return manager.ExecuteDataSet(CommandType.Text, "SELECT [ID],[Name],'',[Regular Expression],[Block Size],Cost AS [Cost Per Block],[Connection Cost],[Type],[Priority],[Charge Unfinished] FROM [CallCategory] WHERE 1=1" + whereString);
            }
        }

        public DataSet GetFilterMatches(string number, string duration)
       {
            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();

                return manager.ExecuteDataSet(CommandType.Text, @"
                    SELECT
                    [Name]
                    ,CASE
                    WHEN [Charge Unfinished] = '0' THEN
                    TRUNCATE( (  TRUNCATE( (( '" + duration + @"' + '0.0' ) / [Block Size]) )  *  [Cost]  +   [Connection Cost]   ) / 100   ,2)
                    ELSE
                    TRUNCATE( ( (TRUNCATE( (( '" + duration + @"' + '0.0' ) / [Block Size]) )+1)  *  [Cost]  +   [Connection Cost]   ) / 100   ,2)
                    END AS CallCost, Priority
                    
                    FROM [CallCategory]

                    WHERE '" + number + @"' REGEXP [Regular Expression] ORDER BY [Priority];");
            }
        }

        /// <summary>
        /// Add a new call cost to the database
        /// </summary>
        /// <param name="ID">A unique ID</param>
        /// <param name="blockSize">The size of each call cost block. For example, a 60 second block size is charged at $2</param>
        /// <param name="cost">The cost for the specified block size ($)</param>
        /// <param name="connectionCost">The amount charged to make the initial connection</param>
        /// <param name="regex">The regular expression that defines the calls for the specified call cost</param>
        /// <param name="name">A friendly name for the call cost</param>
        /// <param name="updating">Whether to update the existing call cost or create a new call cost</param>
        /// <returns></returns>
        public List<ValidationError> UpdateCallCost(string ID, string blockSize, string cost, string connectionCost, string regex, string type, string name, string priority, string chargeUnfinished, bool updating)
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            CallCategory callCategory = new CallCategory(_connectionString, _provider);

            try
            {
                // Perform validation
                if (name != String.Empty)
                {
                    if (regex != String.Empty)
                    {
                        callCategory.Name = name;


                        // Validate the 'Block Size' field
                        int block_size = 0;
                        try
                        {
                            block_size = Convert.ToInt32(blockSize);
                            if (block_size < 0) throw new Exception();
                            if (block_size > 999999) throw new InvalidOperationException();
                        }
                        catch (InvalidOperationException)
                        {
                            validationErrors.Add(new ValidationError("Block Size value must be less than 1,000,000"));
                        }
                        catch (Exception)
                        {
                            validationErrors.Add(new ValidationError("Invalid block size - must be a number, greater than zero."));
                        }

                        // Validate the 'Cost' field
                        int costValue = 0;
                        try
                        {
                            costValue = Convert.ToInt32(cost);
                            if (costValue < 0)
                                throw new Exception();
                            if (costValue > 999999) throw new InvalidOperationException();
                        }
                        catch (InvalidOperationException)
                        {
                            validationErrors.Add(new ValidationError("Rate per Block value must be less than 1,000,000"));
                        }
                        catch (Exception)
                        {
                            validationErrors.Add(new ValidationError("Invalid 'Rate per Block' value - must be a number, equal to or greater than zero."));
                        }

                        // Validate the 'Connection Cost' field
                        int connCost = 0;
                        try
                        {
                            connCost = Convert.ToInt32(connectionCost);
                            if (connCost < 0) throw new Exception();
                            if (connCost > 999999) throw new InvalidOperationException();
                        }
                        catch (InvalidOperationException)
                        {
                            validationErrors.Add(new ValidationError("Connection Cost must be less than 1,000,000"));
                        }
                        catch (Exception)
                        {
                            validationErrors.Add(new ValidationError("Invalid 'Connection Cost' value - must be a number, greater than or equal to zero."));
                        }

                        // Validate the 'Regular Expression' field
                        Regex reg = CreateRegex(regex);
                        if (reg == null)
                        {
                            validationErrors.Add(new ValidationError("'Regular Expression' field must be a valid regular expression"));
                        }

                        //Validate the priority
                        int priorityInt = 0;
                        try
                        {
                            priorityInt = Convert.ToInt32(priority);
                            if (priorityInt < 0) throw new Exception();
                        }
                        catch (Exception)
                        {
                            validationErrors.Add(new ValidationError("'Priority' field must be a number"));
                        }

                        //Validate the Charge Unfinished
                        int chargeInt = 0;
                        try
                        {
                            chargeInt = Convert.ToInt32(chargeUnfinished);
                            if (chargeInt < 0) throw new Exception();
                        }
                        catch (Exception)
                        {
                            validationErrors.Add(new ValidationError("Error with the 'Charge Unfinished Block' check box."));
                        }

                        if (ID != String.Empty) callCategory.ID = Convert.ToInt32(ID);
                        else callCategory.ID = -1;

                        callCategory.Name = name;
                        callCategory.ConnectionCost = connCost;
                        callCategory.Cost = costValue;
                        callCategory.BlockSize = block_size;
                        callCategory.RegularExpression = reg;
                        callCategory.Type = type;
                        callCategory.Priority = priorityInt;
                        callCategory.ChargeUnfinished = chargeInt;
                    }
                    else
                    {
                        validationErrors.Add(new ValidationError("'Regular Expression' field cannot be blank"));
                    }
                }
                else
                {
                    validationErrors.Add(new ValidationError("'Name' field cannot be blank"));
                }

                if (validationErrors.Count == 0)
                {
                    // Saves the Call Cost to the database if there are no errors
                    callCategory.Save(updating);
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(new ValidationError("Unexpected Error: " + ex.ToString().Replace('\'', '"')));
            }
            return validationErrors;

        }

        // Create a Regular Expression with the string
        public Regex CreateRegex(string reg)
        {
            try
            {
                return new Regex(reg);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetLastRowID()
        {
            CallCategory cc = new CallCategory(_connectionString,_provider);
            return cc.GetLastRowID();
        }

        // Delete the call cost at the specified ID
        public List<ValidationError> DeleteCallCost(int id)
        {
            List<ValidationError> errors = new List<ValidationError>();
            try
            {
                if (id != -1)
                {
                    CallCategory callCostToDelete = new CallCategory(_connectionString, _provider);
                    callCostToDelete.Delete(id);
                }
                else
                {
                    // if not a valid id then throw an exception to be caught in the application handler
                    errors.Add(new ValidationError("Could not delete Call Cost. Invalid ID."));
                }
            }
            catch (Exception ex)
            {
                errors.Add(new ValidationError("Unexpected Error: " + ex.ToString().Replace('\'', '"')));
            }
            return errors;
        }

        public void GetSchema()
        {
            /* The columns that exist in ALL versions of this table
             * (this list is a reference for finding the ID of the column when creating the schema)
             * (DO NOT change the reference numbers here because they allow the columns to be updated for each DB version)
             * 
             * 1. ID - the automatic ID number for the row
             * 2. Regular Expression - the regular expression used for the call category (used in matching to phone numbers)
             * 3. Name - the name of the call category
             * 4. Connection Cost - the cost of connecting to the receiver's number
             * 5. Block Size - The block of time that is charged for
             * 6. Cost - The rate that each block is charged at
             * 7. Priority - The priority of this call category. Used if 2 call categories apply to the same phone number
             * 8. Charge Unfinished - Whether or not the rate is charged on entry into a new block or only when it is completed
             */

            //Setup Table - CallCategory , version 1.1.2
            MiTable callCategoryTable = new MiTable("CallCategory","1.1.2");
            callCategoryTable.AddColumn(1, 1, "ID", "INTEGER", "PRIMARY KEY AUTOINCREMENT NOT NULL", "");

            /*
            CREATE TABLE [CallCategory] (
                    [ID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [Regular Expression]	varchar(150) COLLATE NOCASE,
                    [Name]	varchar(50) COLLATE NOCASE,
                    [Connection Cost]	numeric,
                    [Block Size]	integer,
                    [Cost]	varchar(50) COLLATE NOCASE,
                    [Type] varchar(20) COLLATE NOCASE,
                    [Priority] char(2) COLLATE NOCASE,
                    [Charge Unfinished] char(1) COLLATE NOCASE
                    );
                    CREATE  INDEX [regeg] ON [CallCategory] ([Regular Expression] ASC);
             */
        }
    }
}
