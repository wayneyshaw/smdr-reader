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
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MiSMDR.BusinessLogicLayer
{
    public class MiTable
    {
        //Name of the table
        private string _name;
        //List of MiColumns (each with name and position)
        private List<MiColumn> _columns;
        //DB version this schema belongs to
        private string _version;
        //indexes
        private string _indexes;

        public MiTable(string name, string version)
        {
            _name = name;
            _version = version;
            _columns = new List<MiColumn>();
        }

        public void AddColumn(int ID, int position, string name, string type, string extraInformation, string defaultValue)
        {
            MiColumn col = new MiColumn(ID, position, name, type, extraInformation, defaultValue);
            _columns.Add(col);
        }

        public string GetName()
        {
            return _name;
        }
        public List<MiColumn> GetColumns()
        {
            return _columns;
        }
        public string GetVersion()
        {
            return _version;
        }
        public MiColumn GetColumn(string name)
        {
            foreach(MiColumn col in _columns)
            {
                if(col.GetName() == name) return col;
            }
            return null;
        }
        public MiColumn GetColumn(int pos)
        {
            foreach (MiColumn col in _columns)
            {
                if (col.GetPosition() == pos) return col;
            }
            return null;
        }
        public void AddIndex(string index)
        {
            if(index.EndsWith(";")) _indexes = _indexes + index;
            else  _indexes = _indexes + index + ";";
        }
        public string GetCreateCommand()
        {
            string command = "CREATE TABLE";
            command += " [" + _name + "] (";
            int pos = 1;
            foreach (MiColumn col in _columns)
            {
                //if () command += " "+col.GetName;
                pos++;
            }

            return command;

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
