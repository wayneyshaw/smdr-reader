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
using MiSMDR.DataAccessLayer;
using System.IO;
using System.Text.RegularExpressions;

namespace MiSMDR
{
    public partial class PluginForm : Form
    {
        private BackgroundWorker backgroundWorker1;
        delegate void SetTextCallback(string text);

        private string fileLocation;
        private string _connectionString;
        private bool _finished = false;
        private DataProvider _provider;

        public PluginForm(string connString, DataProvider provider)
        {
            _connectionString = connString;
            _provider = provider;
            InitializeComponent();
        }

        private void bnBrowseRecordFile_Click(object sender, EventArgs e)
        {
            browseForFile();
        }
        private void browseForFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "";
            openFileDialog.Filter = "MiSMDR Plugins (*.p4m)|*.p4m|All Files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Title = "MiSMDR Plugin File";
            DialogResult d = openFileDialog.ShowDialog();

            if (d == DialogResult.OK)
            {
                tbFileLoc.Text = openFileDialog.FileName;
                fileLocation = tbFileLoc.Text;
                startImport.Enabled = true;
            }
        }

        private void tbFileLoc_MouseDown(object sender, MouseEventArgs e)
        {
            browseForFile();
        }

        private void startImport_Click(object sender, EventArgs e)
        {
            if (!_finished)
            {
                this.ControlBox = false;
                startImport.Enabled = false;
                bnBrowseRecordFile.Enabled = false;
                tbFileLoc.Enabled = false;
                this.backgroundWorker1 = new BackgroundWorker();
                this.backgroundWorker1.WorkerReportsProgress = true;

                this.backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
                this.backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
                this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
                this.backgroundWorker1.RunWorkerAsync();
            }
            else this.Close();
        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.label1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.label1.Text = text;
            }
        }

        // This method does the work you want done in the background.
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            using (IDBManager manager = new DBManager(_provider, _connectionString))
            {
                manager.Open();
                string fileContents = File.ReadAllText(fileLocation);

                //Break the text file into all the separate SQL commands
                Regex regex = new Regex(";", RegexOptions.None);
                string[] sqlCommands = regex.Split(fileContents);
                int commandCount = sqlCommands.Length;

                SetText("Applying " + commandCount + " patches");

                int i = 0;
                int progress = 1;
                int step;
                if (commandCount > 100) step = Convert.ToInt32(commandCount / 100);
                else step = Convert.ToInt32(100 / commandCount) * (-1);

                //Loop through every command in the plug-in file
                foreach (string command in sqlCommands)
                {
                    i++;
                    if (step > 0)
                    {
                        if (i % step == 0) progress++;
                    }
                    else progress = progress + (-1 * step);
                    backgroundWorker1.ReportProgress(progress);
                    try
                    {
                        manager.ExecuteNonQuery(CommandType.Text, command);
                    }
                    catch (Exception ex) {}
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _finished = true;
            progressBar1.Value = 100;
            this.ControlBox = true;
            startImport.Enabled = true;
            startImport.Text = "OK";
            bnBrowseRecordFile.Enabled = true;
            tbFileLoc.Enabled = false;
            label1.Text = "Updating is finished";
        }
    }
}
