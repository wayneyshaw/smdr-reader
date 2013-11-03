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
using System.Configuration;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using MiSMDR.DBIntegrity;
using MiSMDR.DataAccessLayer;
using MiSMDR.Security;

namespace MiSMDR
{
    public partial class SplashScreen : Form
    {
        delegate void SetTextCallback(string text);
        delegate void CloseCallback();
        delegate void HideCallback();

        private bool _demo;
        private bool _forcedDemo;
        private bool _popup;
        private bool _trialStatus;
        private string _configPath;
        private string _demoPath;
        private bool _firstTime;
        private int _statusCount;

        private Mutex SingleInstanceMutex;

        //private DBControl dbcontroller;

        [STAThread]
        static void Main()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreen());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("An error occurred in the MiSMDR application:" + e.Exception, "MiSMDR Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //FIX THIS !!!!!
            String msg = "";
            AppDomain domain = AppDomain.CurrentDomain;
            Assembly[] AssembliesLoaded = domain.GetAssemblies();

            foreach (Assembly assembly in AssembliesLoaded)
            {
                msg = msg + assembly.FullName;
            }

            // NEEDED: Email Functionality - send an email to the specified address with a detailed error message
            MessageBox.Show("MiSMDR has encountered an unhandled exception and will now close.  Error: " + e.ToString() + msg, "MiSMDR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        public SplashScreen()
        {
            try
            {
                SingleInstanceMutex = Mutex.OpenExisting("MiSMDRMutex0");
                MessageBox.Show("There is already an instance of MiSMDR running.", "MiSMDR already running", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                SingleInstanceMutex = new Mutex(false, "MiSMDRMutex0");

                _firstTime = true; //Never change this
                _statusCount = 0;

                CheckVersion();

                _forcedDemo = false; // TURN ON AND OFF DEMO HERE - to force into demo mode every startup
                _popup = false;
                _trialStatus = false;

                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\MiSMDR");
                string existing_key = (string)key.GetValue("MiSMDRKey");
                key.Close();
                LicenseBreaker breaker = new LicenseBreaker(existing_key);
                RegisteredDetails details = breaker.BreakKey();

                if ((details.licence_type == "expired-trial") || (details.licence_type == "unregistered") || (details.licence_type=="invalid")) //only show popup for expired trial, invalid or unregistered
                {
                    _popup = true; //make the registration page popup
                }
                if ((details.licence_type == "trial") || (details.licence_type == "expired-trial"))
                {
                    _trialStatus = true; //make the trial status appear
                }

                if (_forcedDemo)
                {
                    MiConfig.SetDemoMode(_forcedDemo); //always overwrite the config file if this is forced Demo Only
                    _demo = true;
                }
                else
                {
                    _demo = MiConfig.GetDemoMode(); //get the stored demo mode if it is not forced (returns true if there is no config)
                }

                //get the location of the user settings
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                _configPath = config.FilePath.Remove(config.FilePath.Length - 11); // user.config is 11 characters

                InitializeComponent();
            }
        }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            if (_firstTime)
            {
                _firstTime = false;
                Thread miThread = new Thread(new ThreadStart(afterLoad));
                miThread.SetApartmentState(ApartmentState.STA);
                miThread.Start();
            }
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            linkLabel1.Links.Remove(linkLabel1.Links[0]);
            linkLabel1.Links.Add(0, linkLabel1.Text.Length, "http://www.MiSMDR.info");
            if (MiConfig.GetShowSplash()) this.WindowState = FormWindowState.Normal;
            else this.WindowState = FormWindowState.Minimized;
        }

        private void lbStatus_TextChanged(object sender, EventArgs e)
        {
            //this.Refresh();
            _statusCount++;
            progressBar.Step = 10;
            progressBar.PerformStep();
            //tofix - settings can reduce the time taken here with a tick box (instant startup or something)
            //Thread.Sleep(200);
        }

        private void initDatabase(string connString, bool demo)
        {
            string prefix = String.Empty;
            if (demo) prefix = "Demo Call Records - ";
            else prefix = "Mitel Call Records - ";
            
            DBInstaller myInstaller = new DBInstaller(connString, MiConfig.GetProvider());
            this.SetText(prefix+"Creating Database");
            myInstaller.CreateDatabase();
            this.SetText(prefix + "Adding Tables");
            myInstaller.CreateTables();
            this.SetText(prefix + "Adding default hardware formats");
            myInstaller.InsertInputFormats();
            if (demo)
            {
                this.SetText(prefix + "Adding Demo Data");
                myInstaller.InsertDefaultData();
            }
        }

        private void ShowMsg(string text)
        {
            MessageBox.Show(text);
        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (MiConfig.GetShowSplash()) Thread.Sleep(20);
            if (this.lbStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lbStatus.Text = text;
            }
        }

        private void CloseSplash()
        {
            try
            {
                //Release the MiSMDR single instance checker
                SingleInstanceMutex.ReleaseMutex();
            }
            catch (Exception ex)
            {
            }
            Application.Exit();
        }

        private void HideSplash()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lbStatus.InvokeRequired)
            {
                HideCallback d = new HideCallback(HideSplash);
                this.Invoke(d);
            }
            else
            {
                this.Visible = false;
            }
        }

        private void CheckProgressBar()
        {
            Random random = new Random();
            int n;
            while (_statusCount < 9)
            {
                n = random.Next(0, 4);
                if (n == 0) this.SetText("Cleaning up threaded processes");
                else if (n == 1) this.SetText("Checking the database version");
                else if (n == 2) this.SetText("Checking the database tables");
                else if (n == 3) this.SetText("Checking the number of columns in the database");
                else if (n == 4) this.SetText("Preparing the user config");
                else if (n == 5) this.SetText("Checking the demo data file");
            }
            this.SetText("Loading MiSMDR");
        }

        private void afterLoad()
        {
            string myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //first thing is to see if the config is new
            if (MiConfig.GetProvider() != DataProvider.Sqlite)
            {
                this.SetText("Updating configuration file");
                MiConfig.buildDefaultConfigFile(_configPath); //rebuild it just in case
                MiConfig.SetProvider(DataProvider.Sqlite);
            }

            if (MiConfig.GetProvider() != DataProvider.Sqlite)
            {
                //CHECK AGAIN - this is to make sure the config file is in a writable location
                this.SetText("Unable to create a config file. Please contact the MiSMDR support team at support@MiSMDR.info");
            }

            if ((MiConfig.GetConnectionString("MiDatabaseString") == "notinstalled") || (MiConfig.GetConnectionString("MiDemoString") == "notinstalled"))
            {
                CheckMiSMDRFolder();

                //now we need to check the demo file location
                if (MiConfig.GetConnectionString("MiDemoString") == "notinstalled")
                {
                    BuildDemoFile();
                }

                if (MiConfig.GetConnectionString("MiDatabaseString") == "notinstalled")
                {
                    BuildMitelFile();
                }
            }

            if (MiConfig.GetLogPath() == "notinstalled")
            {
                this.SetText("Checking Mitel Data log file");
                string dataLogPath = myDocs + "\\MiSMDR\\MitelData_Log.txt";
                MiConfig.SetLogPath(dataLogPath);
            }

            DBControl demoChecker = new DBControl(MiConfig.GetConnectionString("MiDemoString"), MiConfig.GetProvider());
            DBControl liveChecker = new DBControl(MiConfig.GetConnectionString("MiDatabaseString"), MiConfig.GetProvider());

            this.SetText("Configuration looks ok");
            this.SetText("Checking Database access");
            if (!demoChecker.CheckDataAccess())
            {
                this.SetText("Demo Database looks ok");
                CheckMiSMDRFolder(); //check the folder exists
                BuildDemoFile();
            }
            if (!liveChecker.CheckDataAccess())
            {
                this.SetText("Mitel Database looks ok");
                CheckMiSMDRFolder();
                BuildMitelFile();
            }

            //Load MiSMDR main
            CheckProgressBar();
            HideSplash();
            MiSMDR.MiForm.customStart(_popup,_trialStatus);
            CloseSplash(); //after the MiForm is closed then kill the App
        }

        private void BuildMitelFile()
        {
            ConnStringer stringer = new ConnStringer();
            string myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            this.SetText("Creating the Mitel Call Records Database");
            string dataPath = myDocs + "\\MiSMDR\\Mitel_Call_Records.db";
            string connString = stringer.buildLiteConnectionString(dataPath, "3", "False", "False", "", "", false);
            MiConfig.SetConnectionString("MiDatabaseString", connString);
            //we only need to intialise the database if it doesnt have any content
            DBControl control = new DBControl(MiConfig.GetConnectionString("MiDatabaseString"), MiConfig.GetProvider());
            if (!control.CheckDataAccess()) initDatabase(connString, false);
        }

        private void BuildDemoFile()
        {
            ConnStringer stringer = new ConnStringer();
            string myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            this.SetText("Creating the Demo Call Records Database");
            string demoPath = myDocs + "\\MiSMDR\\Demo_Call_Records.db";
            string connString = stringer.buildLiteConnectionString(demoPath, "3", "True", "False", "", "", false);
            MiConfig.SetConnectionString("MiDemoString", connString);
            //initialise and put demo data in the database if there is none already
            DBControl control = new DBControl(MiConfig.GetConnectionString("MiDemoString"), MiConfig.GetProvider());
            if (!control.CheckDataAccess()) initDatabase(connString, true);
        }

        private void CheckMiSMDRFolder()
        {
            string myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            this.SetText("Creating MiSMDR directory in My Documents");
            //because a database does not exist then we need to create it in the default location MyDocuments/MiSMDR/
            if (!Directory.Exists(myDocs + "\\MiSMDR")) Directory.CreateDirectory(myDocs + "\\MiSMDR");
        }

        private void SplashScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                MessageBox.Show("Exiting...");
                Application.Exit();
            }
        }

        private void CheckVersion()
        {
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            Version appVersion = a.GetName().Version;
            string appVersionString = appVersion.ToString();

            if (Properties.Settings.Default.ApplicationVersion != appVersion.ToString())
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.ApplicationVersion = appVersionString;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(e.Link.LinkData.ToString());
            Process.Start(sInfo);
        }
    }
}
