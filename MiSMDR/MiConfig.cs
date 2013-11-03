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
using System.Text;
using MiSMDR.DataAccessLayer;
using System.Configuration;
using MiSMDR.Properties;
using System.Windows.Forms;

namespace MiSMDR
{
    public static class MiConfig
    {
        public static DataProvider GetProvider()
        {
            try
            {
                if (Settings.Default.MiProvider != String.Empty)
                {
                    switch (Settings.Default.MiProvider)
                    {
                        case "Sqlite":
                            return DataProvider.Sqlite;
                        case "SqlServer":
                            return DataProvider.SqlServer;
                        default:
                            return DataProvider.None;
                    }
                }
                else
                {
                    return DataProvider.None;
                }
            }
            catch (Exception)
            {
                //No config available
                return DataProvider.None;
            }
        }

        public static void SetProvider(DataProvider provider)
        {
            Settings.Default.MiProvider = provider.ToString();
        }

        public static void SetState(FormWindowState state)
        {
            Settings.Default.WindowState = state.ToString();
        }

        public static string GetState()
        {
            return Settings.Default.WindowState;
        }

        public static string GetConnectionString(string connString)
        {
            try
            {
                switch (connString)
                {
                    case "MiDatabaseString":
                        return Settings.Default.MiDatabaseString;
                    case "MiDemoString":
                        return Settings.Default.MiDemoString;
                    default:
                        return "";
                }
            }
            catch (Exception)
            {
                //No config available
                return "";
            }
        }

        public static void SetConnectionString(string connString, string value)
        {
            switch (connString)
            {
                case "MiDatabaseString":
                    Settings.Default.MiDatabaseString = value;
                    break;
                case "MiDemoString":
                    Settings.Default.MiDemoString = value;
                    break;
            }
        }

        public static void buildDefaultConfigFile(string configPath)
        {
            // Open App.Config of executable

            // Add an Application Setting
            Settings.Default.Server = "127.0.0.1";
            Settings.Default.Port = "1752";

            Settings.Default.MiProvider = "notinstalled";
            Settings.Default.LogFile = "notinstalled";
            
            Settings.Default.MiDatabaseString = "notinstalled";
            Settings.Default.MiDemoString = "notinstalled";

            Settings.Default.RecordLimit = "10000";
            Settings.Default.DemoMode = "true";
            Settings.Default.ShowDebug = "false";

            // Save the changes in App.config file.
            Settings.Default.Save();
            Settings.Default.Reload();
        }

        public static string GetLogPath()
        {
            try
            {
                if (Settings.Default.LogFile != String.Empty)
                {
                    return Settings.Default.LogFile;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static void SetLogPath(string path)
        {
            Settings.Default.LogFile = path;
            Settings.Default.Save();
            Settings.Default.Reload();
        }

        public static bool GetShowDebug()
        {
            try
            {
                if (Settings.Default.ShowDebug != String.Empty)
                {
                    return Convert.ToBoolean(Settings.Default.ShowDebug);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void SetShowDebug(bool showDebug)
        {
            Settings.Default.ShowDebug = showDebug.ToString();
            Settings.Default.Save();
            Settings.Default.Reload();
        }

        public static bool GetConnectOnStartup()
        {
            try
            {
                if (Settings.Default.ConnectOnStartup != String.Empty)
                {
                    return Convert.ToBoolean(Settings.Default.ConnectOnStartup);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void SetConnectOnStartup(bool connectOnStartup)
        {
            Settings.Default.ConnectOnStartup = connectOnStartup.ToString();
            Settings.Default.Save();
            Settings.Default.Reload();
        }

        public static string GetServer()
        {
            try
            {
                if (Settings.Default.Server != String.Empty)
                {
                    return Settings.Default.Server;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static void SetServer(string server)
        {
            Settings.Default.Server = server;
            Settings.Default.Save();
            Settings.Default.Reload();
        }

        public static bool GetMinimiseToTray()
        {
            try
            {
                if (Settings.Default.MinimiseToTray != String.Empty)
                {
                    return Convert.ToBoolean(Settings.Default.MinimiseToTray);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void SetMinimiseToTray(bool minimise)
        {
            Settings.Default.MinimiseToTray = minimise.ToString();
            Settings.Default.Save();
            Settings.Default.Reload();
        }

        public static bool GetShowNotifications()
        {
            try
            {
                if (Settings.Default.ShowNotifications != String.Empty)
                {
                    return Convert.ToBoolean(Settings.Default.ShowNotifications);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void SetShowNotifications(bool notify)
        {
            Settings.Default.ShowNotifications = notify.ToString();
            Settings.Default.Save();
            Settings.Default.Reload();
        }

        public static void SetShowSplash(bool splash)
        {
            Settings.Default.ShowSplash = splash.ToString();
            Settings.Default.Save();
            Settings.Default.Reload();
        }

        public static bool GetShowSplash()
        {
            try
            {
                if (Settings.Default.ShowSplash != String.Empty)
                {
                    return Convert.ToBoolean(Settings.Default.ShowSplash);
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }

        public static int GetRecordLimit()
        {
            try
            {
                if (Settings.Default.RecordLimit != String.Empty)
                {
                    return Convert.ToInt32(Settings.Default.RecordLimit);
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static void SetRecordLimit(int recordLimit)
        {
            Settings.Default.RecordLimit = recordLimit.ToString();
            Settings.Default.Save();
            Settings.Default.Reload();
        }

        public static int GetPort()
        {
            try
            {
                if (Settings.Default.Port != String.Empty)
                {
                    return Convert.ToInt32(Settings.Default.Port);
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static void SetPort(int port)
        {
            Settings.Default.Port = port.ToString();
            Settings.Default.Save();
            Settings.Default.Reload();
        }

        public static bool GetDemoMode()
        {
            try
            {
                if (Settings.Default.DemoMode != String.Empty)
                {
                    return Convert.ToBoolean(Settings.Default.DemoMode);
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }

        public static void SetDemoMode(bool demo)
        {
            Settings.Default.DemoMode = demo.ToString();
            Settings.Default.Save();
            Settings.Default.Reload();
        }
    }
}
