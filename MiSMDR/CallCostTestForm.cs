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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MiSMDR.Logger;
using MiSMDR.BusinessLogicLayer;
using MiSMDR.DataAccessLayer;

namespace MiSMDR
{
    public partial class CallCostTestForm : Form
    {
        private string _connectionString;
        private DataProvider _provider;

        public CallCostTestForm(string connString, DataProvider provider)
        {
            _connectionString = connString;
            _provider = provider;
            InitializeComponent();
        }

        private bool matchesRegex(string number, string duration)
        {
            CallCategoryManager callCostManager = new CallCategoryManager(_connectionString, _provider);
            
            DataTable newTable = callCostManager.GetFilterMatches(number, duration).Tables[0];
            //string test1 = newTable.Rows[0].ItemArray.GetValue(1).ToString();
            testDataGrid.DataSource = null;
            testDataGrid.DataSource = newTable;

            //string test = testDataGrid.Rows[0].Cells[1].Value.ToString();

            testDataGrid.Columns[2].Visible = false; //hide the priority column
            testDataGrid.Columns[1].DefaultCellStyle.Format = "C2"; //currency

            if (testDataGrid.RowCount > 0) return true;
            else return false;
        }

        private void tbTestNumber_TextChanged(object sender, EventArgs e)
        {
            if (matchesRegex(tbTestNumber.Text, tbTestDuration.Text))
            {
                picTick.Visible = true;
                picCross.Visible = false;
                lbMatchNotice.Text = "Matches the Call Cost filters below";
            }
            else
            {
                picTick.Visible = false;
                picCross.Visible = true;
                lbMatchNotice.Text = "Currently does not match.";
            }
        }

        private void bnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
