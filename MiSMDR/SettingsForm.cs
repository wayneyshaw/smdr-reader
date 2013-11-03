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
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MiSMDR.DBIntegrity;
using MiSMDR.DataAccessLayer;
using System.IO;
using Microsoft.Win32;

namespace MiSMDR
{
    public partial class SettingsForm : Form
    {
        string _connectionString;
        DataProvider _provider;
        bool _demo; // the main application demo mode

        public SettingsForm(string connString, DataProvider prov, bool demo)
        {
            _connectionString = connString;
            _provider = prov;
            _demo = demo;
            InitializeComponent();
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            tbMitelDataLogPath.Text = MiConfig.GetLogPath();

            cbShowDebug.Checked = MiConfig.GetShowDebug();
            cbConnectOnStartup.Checked = MiConfig.GetConnectOnStartup();
            cbShowNotifications.Checked = MiConfig.GetShowNotifications();
            cbShowSplash.Checked = MiConfig.GetShowSplash();
            cbMinimiseToTray.Checked = MiConfig.GetMinimiseToTray();

            //Get the registry setting
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rkApp.GetValue("MiSMDR") == null)
            {
                cbStartWithWindows.Checked = false;
            }
            else
            {
                cbStartWithWindows.Checked = true;
            }
            
            //Load the database strings
            string[] pieces = MiConfig.GetConnectionString("MiDatabaseString").Split(new string[] { ";" }, StringSplitOptions.None);
            tbCallRecordLoc.Text = pieces[0].Remove(0, 12);
            pieces = MiConfig.GetConnectionString("MiDemoString").Split(new string[] { ";" }, StringSplitOptions.None);
            tbDemoRecords.Text = pieces[0].Remove(0, 12);
            tbCallRecordLimit.Text = MiConfig.GetRecordLimit().ToString();
        }

        private void bnSave_Click(object sender, EventArgs e)
        {
            ConnStringer stringer = new ConnStringer();
            List<string> errors = new List<string>();

            if (tbMitelDataLogPath.Text == String.Empty) errors.Add("Mitel data log file field cannot be blank");
            if (tbDemoRecords.Text == String.Empty) errors.Add("Demo Call Records file location cannot be blank");
            if (tbCallRecordLoc.Text == String.Empty) errors.Add("Mitel Call Records file location cannot be blank");

            if (errors.Count == 0)
            {            
                //Save the file locations
                MiConfig.SetConnectionString("MiDemoString", stringer.buildLiteConnectionString(tbDemoRecords.Text, "3", "True", "False", "", "", false));
                MiConfig.SetConnectionString("MiDatabaseString", stringer.buildLiteConnectionString(tbCallRecordLoc.Text, "3", "True", "False", "", "", false));
                MiConfig.SetLogPath(tbMitelDataLogPath.Text);

                //save options
                MiConfig.SetConnectOnStartup(cbConnectOnStartup.Checked);
                MiConfig.SetShowDebug(cbShowDebug.Checked);
                RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (cbStartWithWindows.Checked)
                {
                    rkApp.SetValue("MiSMDR", Application.ExecutablePath.ToString());
                }
                else
                {
                    rkApp.DeleteValue("MiSMDR", false);
                }
                MiConfig.SetShowSplash(cbShowSplash.Checked);
                MiConfig.SetMinimiseToTray(cbMinimiseToTray.Checked);
                MiConfig.SetRecordLimit(Convert.ToInt32(tbCallRecordLimit.Text));
                MiConfig.SetShowNotifications(cbShowNotifications.Checked);

                //return to MiForm
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                string errorString = "Cannot save settings: " + Environment.NewLine;
                foreach (string error in errors)
                {
                    errorString += "- " + error + Environment.NewLine;
                }
                MessageBox.Show(errorString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnSelectPath_Click(object sender, EventArgs e)
        {
            DialogResult d = saveFileDialog.ShowDialog();

            if (d == DialogResult.OK)
            {
                tbMitelDataLogPath.Text = saveFileDialog.FileName;
            }
        }

        private void bnDataClear_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure you want to clear the Mitel Call Records file?\nWarning: you cannot undo this operation. You may want to back up your call record file before proceeding", "Clear Mitel Call Records File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                String connectionString = MiConfig.GetConnectionString("MiDatabaseString");
                DataProvider provider = MiConfig.GetProvider();
                DBInstaller installer = new DBInstaller(connectionString, provider);
                this.Cursor = Cursors.WaitCursor;
                installer.EmptyCallData();
                this.Cursor = Cursors.Default;
            }
        }

        private void bnDemoData_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure you want to clear the call records file and insert demo call records?", "Demo Call Records", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                String connectionString = MiConfig.GetConnectionString("MiDemoString");
                DataProvider provider = MiConfig.GetProvider();
                DBInstaller installer = new DBInstaller(connectionString, provider);
                this.Cursor = Cursors.WaitCursor;
                installer.InsertDefaultData();
                installer.InsertInputFormats();
                this.Cursor = Cursors.Default;
            }
        }

        private void bnBrowseRecordFile_Click(object sender, EventArgs e)
        {
            saveCallRecordFile(false);
        }

        private void saveCallRecordFile(bool demofile)
        {
            SaveFileDialog openFileDialog = new SaveFileDialog();
            if (!demofile) openFileDialog.FileName = "Mitel_Call_Records.db";
            else openFileDialog.FileName = "Demo_Call_Records.db";
            openFileDialog.Filter = "MiSMDR Call Records Files (*.db)|*.db|All Files (*.*)|*.*";
            openFileDialog.OverwritePrompt = false;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Title = "Call Records File";
            DialogResult d = openFileDialog.ShowDialog();

            if (d == DialogResult.OK)
            {
                ConnStringer stringer = new ConnStringer();
                if (!demofile) tbCallRecordLoc.Text = openFileDialog.FileName;
                else tbDemoRecords.Text = openFileDialog.FileName;
            }
        }

        private void bnResetSettings_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("This will reset all your settings and restart MiSMDR.\nAre you sure?", "Reset MiSMDR Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                MiConfig.buildDefaultConfigFile("");
                Application.Restart();
            }
        }

        private void bnBrowseDemoFile_Click(object sender, EventArgs e)
        {
            saveCallRecordFile(true);
        }

        private void cbMinimiseToTray_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMinimiseToTray.Checked)
            {
                cbShowNotifications.Enabled = true;
                cbShowNotifications.Checked = MiConfig.GetShowNotifications();
            }
            else
            {
                cbShowNotifications.Enabled = false;
                cbShowNotifications.Checked = false;
            }
        }
    }
}
