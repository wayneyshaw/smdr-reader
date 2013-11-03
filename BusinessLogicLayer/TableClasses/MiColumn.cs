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

namespace MiSMDR.BusinessLogicLayer
{
    public class MiColumn
    {
        private int _ID;
        private int _position;
        private string _columnName;
        private string _type;
        private string _extra;
        private string _default;

        public MiColumn(int ID, int pos, string name, string type, string extra, string def)
        {
            _ID = ID;
            _columnName = name;
            _position = pos;
            _type = type;
            _extra = extra;
            _default = def;
        }
        public int GetID()
        {
            return _ID;
        }
        public string GetName()
        {
            return _columnName;
        }
        public int GetPosition()
        {
            return _position;
        }
        public string GetColumnType()
        {
            return _type;
        }
        public string GetExtra()
        {
            return _extra;
        }
        public string GetDefault()
        {
            return _default;
        }
    }
}
