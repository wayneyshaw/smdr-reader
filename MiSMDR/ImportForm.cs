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
using System.Threading;
using System.IO;
using MiSMDR.MitelManager;
using MiSMDR.DataAccessLayer;

namespace MiSMDR
{
    public partial class ImportForm : Form
    {
        private BackgroundWorker backgroundWorker1;
        delegate void SetTextCallback(string text);

        private string fileLocation;
        private bool finished = false;
        private string _connectionString;
        private DataProvider _provider;

        public ImportForm(string connString, DataProvider provider)
        {
            _connectionString = connString;
            _provider = provider;
            InitializeComponent();
        }
        private void browseForFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "MitelData_Log.txt";
            openFileDialog.Filter = "Mitel RAW Data Log Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Title = "Mitel Raw Log File";
            DialogResult d = openFileDialog.ShowDialog();

            if (d == DialogResult.OK)
            {
                tbCallRecordLoc.Text = openFileDialog.FileName;
                fileLocation = tbCallRecordLoc.Text;
                startImport.Enabled = true;
                startImport.Text = "Start";
                finished = false;
            }
        }

        private void bnBrowseRecordFile_Click(object sender, EventArgs e)
        {
            browseForFile();
        }
        private void tbCallRecordLoc_MouseClick(object sender, MouseEventArgs e)
        {
            browseForFile();
        }

        private void startImport_Click(object sender, EventArgs e)
        {
            if (!finished)
            {
                this.tbCallRecordLoc.Enabled = false;
                this.bnBrowseRecordFile.Enabled = false;
                this.ControlBox = false;
                startImport.Enabled = false;
                label1.Text = "";
                this.backgroundWorker1 = new BackgroundWorker();
                this.backgroundWorker1.WorkerReportsProgress = true;

                this.backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
                this.backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
                this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
                this.backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                this.Close();
            }
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
            MiManager newManager = new MiManager(_connectionString, _provider, fileLocation.Replace(".txt", "2.txt"));
            string[] myFile = File.ReadAllLines(fileLocation);
            bool ignoreDuplicates = false;
            bool continueProcessing = true;
            int lines = myFile.Length;
            SetText("Importing " + lines + " call records");
            int progress = 0;
            int step;
            if (lines > 100)
            {
                step = (int)Math.Round(lines / 100.0);
            }
            else
            {
                step = (int)Math.Round(100.0 / lines) * (-1);
            }
            //MessageBox.Show("Step size: " +step + " -- fraction:"+fraction);
            for (int i = 0; i < lines && continueProcessing; i++)
            {
                if (step > 0)
                {
                    if (i % step == 0)
                    {
                        progress++;
                    }
                }
                else
                {
                    progress = progress + (-1 * step);
                }
                
                backgroundWorker1.ReportProgress(progress);
                //MessageBox.Show("Line: " + myFile[i]);
                try
                {
                    int result = newManager.SmartParseString(myFile[i]);
                    if ( result == -1 && !ignoreDuplicates)
                    {
                        DialogResult dr = MessageBox.Show("There seems to be duplicate call records in this file on line "+i.ToString()+". Are you sure you want to continue? (Duplicate records will be ignored)", "Possible duplicates", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        switch (dr)
                        {
                            case DialogResult.Yes:
                                ignoreDuplicates = true;
                                break;
                            case DialogResult.No:
                                continueProcessing = false;
                                //MessageBox.Show("breaking out of for loop");
                                break;
                        }
                    }
                }
                catch (Exception ex) { }
            }
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage<100) progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.tbCallRecordLoc.Enabled = true;
            this.bnBrowseRecordFile.Enabled = true;
            progressBar1.Value = 100;
            this.ControlBox = true;
            finished = true;
            startImport.Text = "OK";
            startImport.Enabled = true;
            label1.Text = "Import is complete";
            //MessageBox.Show("Import Done", "Finished Importing", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
