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
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;

namespace MiSMDR.DBIntegrity
{
    public class SQLExpressInstaller
    {
        public EmbeddedInstall EI;

        public SQLExpressInstaller()
        {
            EI = new EmbeddedInstall();
        }

        /// <summary>
        /// Install a SQLExpress instance
        /// </summary>
        /// <param name="instanceName">Name of the SQLExpress instance</param>
        /// <param name="installLoc">Folder to install SQL</param>
        /// <param name="sysAdPass">The secure admin password for the SQL instance</param>
        /// <param name="setupLoc">The location of the sqlexpr.exe installer file</param>
        /// <param name="installParams">The parameter for the sqlexpr.exe /qn (silent) or /qb (minimal) or nothing (guided)</param>
        /// <returns></returns>
        public void installNewServer(string instanceName, string installLoc, string sysAdPass, string setupLoc, string installParams)
        {
            //Installing SQL Server 2005 Express Edition

            EI.AutostartSQLBrowserService = false;
            EI.AutostartSQLService = true; //Auto start on windows boot
            EI.Collation = "Latin1_General_CI_AS"; //Good choice for default
            EI.DisableNetworkProtocols = false;

            if (instanceName != String.Empty) { EI.InstanceName = instanceName; }
            else { EI.InstanceName = "SQLEXPRESS"; }

            EI.ReportErrors = true;

            if (setupLoc != String.Empty) { EI.SetupFileLocation = setupLoc; }  //Provide location for the Express setup file
            else { EI.SetupFileLocation = "C:\\Downloads\\sqlexpr.exe"; }

            EI.SqlBrowserAccountName = ""; //Blank means LocalSystem
            EI.SqlBrowserPassword = ""; // N/A

            if (installLoc != String.Empty) { EI.SqlDataDirectory = installLoc + "Microsoft SQL Server\\"; }
            else { EI.SqlDataDirectory = "C:\\Program Files\\Microsoft SQL Server\\"; }

            if (installLoc != String.Empty) { EI.SqlInstallDirectory = installLoc; }
            else { EI.SqlInstallDirectory = "C:\\Program Files\\"; }

            if (installLoc != String.Empty) { EI.SqlInstallSharedDirectory = installLoc; }
            else { EI.SqlInstallSharedDirectory = "C:\\Program Files\\"; }

            EI.SqlServiceAccountName = ""; //Blank means Localsystem
            EI.SqlServicePassword = ""; // N/A

            if (sysAdPass != String.Empty) { EI.SysadminPassword = sysAdPass; }
            else { EI.SysadminPassword = "MiSMDRinstalledsql"; } //<<Supply a secure sysadmin password>>

            EI.UseSQLSecurityMode = true;

            EI.InstallExpress(installParams);
        }
    }
    public class EmbeddedInstall
    {
        #region Internal variables

        //Variables for setup.exe command line
        private string instanceName = "SQLEXPRESS";
        private string installSqlDir = "";
        private string installSqlSharedDir = "";
        private string installSqlDataDir = "";
        private string addLocal = "All";
        private bool sqlAutoStart = true;
        private bool sqlBrowserAutoStart = false;
        private string sqlBrowserAccount = "";
        private string sqlBrowserPassword = "";
        private string sqlAccount = "";
        private string sqlPassword = "";
        private bool sqlSecurityMode = false;
        private string saPassword = "";
        private string sqlCollation = "";
        private bool disableNetworkProtocols = true;
        private bool errorReporting = true;
        private string sqlExpressSetupFileLocation = "c:\\SQLEXPR32.EXE";

        #endregion
        #region Properties
        public string InstanceName
        {
            get
            {
                return instanceName;
            }
            set
            {
                instanceName = value;
            }
        }

        public string SetupFileLocation
        {
            get
            {
                return sqlExpressSetupFileLocation;
            }
            set
            {
                sqlExpressSetupFileLocation = value;
            }
        }

        public string SqlInstallSharedDirectory
        {
            get
            {
                return installSqlSharedDir;
            }
            set
            {
                installSqlSharedDir = value;
            }
        }
        public string SqlDataDirectory
        {
            get
            {
                return installSqlDataDir;
            }
            set
            {
                installSqlDataDir = value;
            }
        }
        public bool AutostartSQLService
        {
            get
            {
                return sqlAutoStart;
            }
            set
            {
                sqlAutoStart = value;
            }
        }
        public bool AutostartSQLBrowserService
        {
            get
            {
                return sqlBrowserAutoStart;
            }
            set
            {
                sqlBrowserAutoStart = value;
            }
        }
        public string SqlBrowserAccountName
        {
            get
            {
                return sqlBrowserAccount;
            }
            set
            {
                sqlBrowserAccount = value;
            }
        }
        public string SqlBrowserPassword
        {
            get
            {
                return sqlBrowserPassword;
            }
            set
            {
                sqlBrowserPassword = value;
            }
        }
        //Defaults to LocalSystem
        public string SqlServiceAccountName
        {
            get
            {
                return sqlAccount;
            }
            set
            {
                sqlAccount = value;
            }
        }
        public string SqlServicePassword
        {
            get
            {
                return sqlPassword;
            }
            set
            {
                sqlPassword = value;
            }
        }
        public bool UseSQLSecurityMode
        {
            get
            {
                return sqlSecurityMode;
            }
            set
            {
                sqlSecurityMode = value;
            }
        }
        public string SysadminPassword
        {
            set
            {
                saPassword = value;
            }
        }
        public string Collation
        {
            get
            {
                return sqlCollation;
            }
            set
            {
                sqlCollation = value;
            }
        }
        public bool DisableNetworkProtocols
        {
            get
            {
                return disableNetworkProtocols;
            }
            set
            {
                disableNetworkProtocols = value;
            }
        }
        public bool ReportErrors
        {
            get
            {
                return errorReporting;
            }
            set
            {
                errorReporting = value;
            }
        }
        public string SqlInstallDirectory
        {
            get
            {
                return installSqlDir;
            }
            set
            {
                installSqlDir = value;
            }
        }

        #endregion
        /// <summary>
        /// Checks if an SQLExpress instance exists
        /// </summary>
        /// <returns>Returns a bool. true if there is an instance or false if there is not</returns>
        public bool IsExpressInstalled()
        {
            using (RegistryKey Key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Microsoft SQL Server\\", false))
            {
                if (Key == null) return false;
                string[] strNames;
                strNames = Key.GetSubKeyNames();

                //If we cannot find a SQL Server registry key, we don't have SQL Server Express installed
                if (strNames.Length == 0) return false;

                foreach (string s in strNames)
                {
                    if (s.StartsWith("MSSQL."))
                    {
                        //Check to see if the edition is "Express Edition"
                        using (RegistryKey KeyEdition = Key.OpenSubKey(s.ToString() + "\\Setup\\", false))
                        {
                            if ((string)KeyEdition.GetValue("Edition") == "Express Edition")
                            {
                                //If there is at least one instance of SQL Server Express installed, return true
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        private string BuildCommandLine()
        {
            StringBuilder strCommandLine = new StringBuilder();

            if (!string.IsNullOrEmpty(installSqlDir))
            {
                strCommandLine.Append(" INSTALLSQLDIR=\"").Append(installSqlDir).Append("\"");
            }

            if (!string.IsNullOrEmpty(installSqlSharedDir))
            {
                strCommandLine.Append(" INSTALLSQLSHAREDDIR=\"").Append(installSqlSharedDir).Append("\"");
            }

            if (!string.IsNullOrEmpty(installSqlDataDir))
            {
                strCommandLine.Append(" INSTALLSQLDATADIR=\"").Append(installSqlDataDir).Append("\"");
            }

            if (!string.IsNullOrEmpty(addLocal))
            {
                strCommandLine.Append(" ADDLOCAL=\"").Append(addLocal).Append("\"");
            }

            if (sqlAutoStart)
            {
                strCommandLine.Append(" SQLAUTOSTART=1");
            }
            else
            {
                strCommandLine.Append(" SQLAUTOSTART=0");
            }

            if (sqlBrowserAutoStart)
            {
                strCommandLine.Append(" SQLBROWSERAUTOSTART=1");
            }
            else
            {
                strCommandLine.Append(" SQLBROWSERAUTOSTART=0");
            }

            if (!string.IsNullOrEmpty(sqlBrowserAccount))
            {
                strCommandLine.Append(" SQLBROWSERACCOUNT=\"").Append(sqlBrowserAccount).Append("\"");
            }

            if (!string.IsNullOrEmpty(sqlBrowserPassword))
            {
                strCommandLine.Append(" SQLBROWSERPASSWORD=\"").Append(sqlBrowserPassword).Append("\"");
            }

            if (!string.IsNullOrEmpty(sqlAccount))
            {
                strCommandLine.Append(" SQLACCOUNT=\"").Append(sqlAccount).Append("\"");
            }

            if (!string.IsNullOrEmpty(sqlPassword))
            {
                strCommandLine.Append(" SQLPASSWORD=\"").Append(sqlPassword).Append("\"");
            }

            if (sqlSecurityMode == true)
            {
                strCommandLine.Append(" SECURITYMODE=SQL");
            }

            if (!string.IsNullOrEmpty(saPassword))
            {
                strCommandLine.Append(" SAPWD=\"").Append(saPassword).Append("\"");
            }

            if (!string.IsNullOrEmpty(sqlCollation))
            {
                strCommandLine.Append(" SQLCOLLATION=\"").Append(sqlCollation).Append("\"");
            }

            if (disableNetworkProtocols == true)
            {
                strCommandLine.Append(" DISABLENETWORKPROTOCOLS=1");
            }
            else
            {
                strCommandLine.Append(" DISABLENETWORKPROTOCOLS=0");
            }

            if (errorReporting == true)
            {
                strCommandLine.Append(" ERRORREPORTING=1");
            }
            else
            {
                strCommandLine.Append(" ERRORREPORTING=0");
            }

            return strCommandLine.ToString();
        }
        /// <summary>
        /// Get a number of instances and assign the parameter references to arrays of information about the installed instances
        /// </summary>
        /// <param name="strInstanceArray">Names of the SQLExpress instances</param>
        /// <param name="strEditionArray">Editions of the SQLExpress instances</param>
        /// <param name="strVersionArray">Versions of the SQLExpress instances</param>
        /// <returns>The number of installed instances</returns>
        public int EnumSQLInstances(ref string[] strInstanceArray, ref string[] strEditionArray, ref string[] strVersionArray)
        {
            using (RegistryKey Key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Microsoft SQL Server\\", false))
            {
                if (Key == null) return 0;
                string[] strNames;
                strNames = Key.GetSubKeyNames();

                //If we can not find a SQL Server registry key, we return 0 for none
                if (strNames.Length == 0) return 0;

                //How many instances do we have?
                int iNumberOfInstances = 0;

                foreach (string s in strNames)
                {
                    if (s.StartsWith("MSSQL."))
                        iNumberOfInstances++;
                }

                //Reallocate the string arrays to the new number of instances
                strInstanceArray = new string[iNumberOfInstances];
                strVersionArray = new string[iNumberOfInstances];
                strEditionArray = new string[iNumberOfInstances];
                int iCounter = 0;

                foreach (string s in strNames)
                {
                    if (s.StartsWith("MSSQL."))
                    {
                        //Get Instance name
                        using (RegistryKey KeyInstanceName = Key.OpenSubKey(s.ToString(), false))
                        {
                            strInstanceArray[iCounter] = (string)KeyInstanceName.GetValue("");
                        }

                        //Get Edition
                        using (RegistryKey KeySetup = Key.OpenSubKey(s.ToString() + "\\Setup\\", false))
                        {
                            strEditionArray[iCounter] = (string)KeySetup.GetValue("Edition");
                            strVersionArray[iCounter] = (string)KeySetup.GetValue("Version");
                        }

                        iCounter++;
                    }
                }
                return iCounter;
            }
        }

        public bool InstallExpress(string installParams)
        {
            
            //In both cases, we run Setup because we have the file.
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = sqlExpressSetupFileLocation;
            myProcess.StartInfo.Arguments = installParams + " " + BuildCommandLine();
            /*      /qn -- Specifies that setup run with no user interface.
                    /qb -- Specifies that setup show only the basic user interface. Only dialog boxes displaying progress information are displayed. Other dialog boxes, such as the dialog box that asks users if they want to restart at the end of the setup process, are not displayed.
            */
            myProcess.StartInfo.UseShellExecute = false;

            bool returnVal = myProcess.Start();
            //myProcess.WaitForExit(); //cannot wait because we cant run 2 MSIs at once damn...
            return returnVal;
        }

    }
}
