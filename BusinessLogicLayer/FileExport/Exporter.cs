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
using System.Data;
using System.IO;
using System.Text;

namespace MiSMDR.BusinessLogicLayer
{
    public class Exporter
    {
        public Exporter()
        { }
        
        /*
         * Export the data to CSV
         */ 
        public string Export(DataTable dt, string path)
        {
            try
            {
                string fileName = "";
                if (Path.GetExtension(path) == "")
                {
                    fileName = path + ".csv";
                }
                else
                {
                    fileName = path;
                }
                // Create the CSV file to which grid data will be exported.
                StreamWriter sw = new StreamWriter(fileName, false);
                // First we will write the headers.
                int iColCount = dt.Columns.Count;
                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(dt.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
                // Now write all the rows.
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            sw.Write(dr[i].ToString());
                        }
                        if (i < iColCount - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                }
                sw.Close();

                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
