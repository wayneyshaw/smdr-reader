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
using MiSMDR.Logger;
using MiSMDR.DataAccessLayer;

namespace MiSMDR
{
    public partial class LogForm : Form
    {
        public string _connectionString;
        public DataProvider _provider;

        public LogForm(string connectionString, DataProvider provider)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _provider = provider;
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            GetLogData();
        }

        private void GetLogData()
        {
            LogManager.SetConnectionString(_connectionString,_provider);
            DataSet logData = LogManager.GetLogData();

            try
            {
                DataTable table = logData.Tables[0];
                logDataGridView.DataSource = table;
            }
            catch (Exception)
            {

            }
        }

        private void logDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Select the whole row
            try
            {
                logDataGridView.Rows[logDataGridView.SelectedCells[0].RowIndex].Selected = true;
            }
            catch (Exception)
            {

            }
        }

        private void bnRefresh_Click(object sender, EventArgs e)
        {
            GetLogData();
        }

        private void bnExport_Click(object sender, EventArgs e)
        {
            string _exportPath = "";

            exportSaveDialog.FileName = "[" + DateTime.Now.ToString("ddMMMyyyy") + "] MiSMDR_Error_Data.csv";
            exportSaveDialog.Filter = "Comma Seperated Value Files (*.csv)|*.csv|All Files (*.*)|*.*";
            DialogResult exportDialog = exportSaveDialog.ShowDialog();

            if (exportDialog == DialogResult.OK)
            {
                _exportPath = exportSaveDialog.FileName;

                BusinessLogicLayer.Exporter exporter = new BusinessLogicLayer.Exporter();

                LogManager.SetConnectionString(_connectionString,_provider);
                DataTable dt = LogManager.GetLogData().Tables[0];

                string result = exporter.Export(dt, _exportPath);
                if (result != null)
                {
                    string errorMessage = "Failed to export data: " + result;
                    MessageBox.Show(errorMessage, "Export Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //"[EXPORT]: Successfully exported MiSMDR call data to ";
                }
            }
        }
    }
}
