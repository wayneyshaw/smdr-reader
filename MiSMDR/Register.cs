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
using MiSMDR.Security;
using System.Diagnostics;
using System.Globalization;
using System.Timers;
using System.Text.RegularExpressions;

namespace MiSMDR
{
    public partial class Register : Form
    {
        delegate void SetLaterCallback(string text);
        private string current_key;
        private bool done = true;
        private bool registerKey = true; //default action is to register the key
        private int counter;
        RegisteredDetails details;
        System.Timers.Timer laterButtonTimer = new System.Timers.Timer();
        private bool _startup;

        public Register(bool startup)
        {
            _startup = startup;
            InitializeComponent();

            //when loaded we should check the registry to decide if the text in the screen should change to be the Change License Key page - controlbox show too
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\MiSMDR");
            string existing_key = (string) key.GetValue("MiSMDRKey");
            key.Close();
            LicenseBreaker breaker = new LicenseBreaker(existing_key);
            details = breaker.BreakKey();
            tb_name.Text = details.c_name;
            tb_licencekey.Text = details.key;
            current_key = details.key;
            if (details.registered == "true")
            {
                if (details.licence_type == "trial")
                {
                    if (startup)
                    {
                        int diff = (Convert.ToDateTime(details.orig_expiry) - DateTime.Now).Days + 1;
                        string plural = "";
                        if (diff > 1) plural = "s";
                        if (diff <= 30)
                        {
                            SetStatus("This " + details.orig_licence_type + @" license will expire in " + diff + @" day" + plural + ".");
                        }
                        else
                        {
                            SetStatus("This " + details.orig_licence_type + @" license will expire on "+details.expiry);
                        }
                    }
                }
                else
                {
                    //SetStatus("MiSMDR is registered until " + details.expiry);
                    bn_buy.Visible = false;
                }
                bn_register.Text = "OK";
                bn_register.Enabled = true;
                registerKey = false;
                this.ControlBox = true;
                done = true;
            }
            else if (details.registered == "false")
            {
                if (details.licence_type == "expired")
                {
                    //SetStatus("Support for your " + details.orig_licence_type + " license has expired.\n You can continue using MiSMDR but you won't have access newer updates or features.");
                    if (startup)
                    {
                        SetStatus("Support for your " + details.orig_licence_type + " license has expired.\n You can continue using MiSMDR but you won't have access newer updates or features.");
                        done = false; //only allow closing after timer has ticked down
                        registerKey = false;
                        bn_exit.Visible = true;
                        //bn_later.Enabled = false;
                        counter = 5;
                        /*int days = (DateTime.Now - Convert.ToDateTime(details.expiry)).Days;
                        if (days > counter) counter = days;
                        if (counter > 60) counter = 60;*/
                        SetLater("Later (" + counter.ToString() + ")");
                        laterButtonTimer.Stop();
                        laterButtonTimer.Interval = 1000; // tick every 1 sec
                        laterButtonTimer.Elapsed += new ElapsedEventHandler(laterButtonTimer_Tick);
                        laterButtonTimer.Start();
                        this.ControlBox = true;
                    }
                    else done = true;
                }
                else if (details.licence_type == "expired-trial")
                {
                    bn_exit.Visible = true;
                    SetStatus("Your trial license expired on "+details.expiry+".\n You must purchase a license to continue using MiSMDR.\n Please contact your reseller or visit www.MiSMDR.info");
                    
                    done = false;
                    //bn_later.Enabled = false;
                    bn_register.Enabled = true;
                    registerKey = true;
                }
                else if (details.licence_type == "invalid")
                {
                    bn_exit.Visible = true;
                    SetStatus(@"Your current MiSMDR license key is in invalid.\par Please enter a new one or contact support at www.MiSMDR.info");

                    done = false;
                    if(!_startup) bn_later.Enabled = true;
                    bn_register.Enabled = true;
                    bn_register.Text = "Register";
                    registerKey = true;
                }
                else //unregistered
                {
                    bn_exit.Visible = true;
                    SetStatus(@"Your current MiSMDR license key is in invalid.\par Please enter a new one or contact support at www.MiSMDR.info");
                    done = false;
                    bn_register.Enabled = true;
                    bn_register.Text = "Register";
                    registerKey = true;
                }
            }
            CheckKey();
        }

        private void laterButtonTimer_Tick(object sender, EventArgs e)
        {
            counter--;
            
            if (counter < 1)
            {
                laterButtonTimer.Stop();
                SetLater("Later");
            }
            else
            {
                SetLater("Later (" + counter.ToString() + ")");
            }
        }

        public string RemoveAllWhitespace(string str)
        {
            try
            {
                Regex reg = new Regex(@"\s*");
                str = reg.Replace(str, "");
                return str;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateKey()
        {
            if ((tb_licencekey.Text.Trim() != current_key) &&(tb_licencekey.Text.Trim() != String.Empty))
            {

                string orig_key = RemoveAllWhitespace(tb_licencekey.Text);
                tb_licencekey.Text = orig_key;
                bool newkey = false;

                LicenseBreaker breaker = new LicenseBreaker(orig_key);
                details = breaker.BreakKey();

                if (details.registered == "true")
                {
                    lb_registered.Visible = false; //hide until we check the values
                    lb_registered.Text = "Successfully Registered "+details.licence_type+" version";
                    newkey = true;
                    lb_registered.ForeColor = Color.Black;
                }
                else if (details.registered == "false")
                {
                    if ((details.licence_type == "expired") || (details.licence_type == "expired-trial"))
                    {
                        lb_registered.Text = "LICENSE EXPIRED on " + details.expiry;
                        lb_registered.ForeColor = Color.Red;
                    }
                    else if (details.licence_type == "invalid")
                    {
                        lb_registered.Text = "INVALID KEY";
                        lb_registered.ForeColor = Color.Red;
                        newkey = false;
                    }
                    newkey = false;
                }
                else
                {
                    lb_registered.Text = "INVALID KEY";
                    lb_registered.ForeColor = Color.Red;
                    newkey = false;
                }

                if (newkey)
                {
                    done = true;
                    try
                    {
                        if (details.c_name.Trim() == tb_name.Text.Trim())
                        {
                            Microsoft.Win32.RegistryKey key;
                            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\MiSMDR");
                            key.SetValue("MiSMDRKey", orig_key);
                            key.Close();

                            if (details.registered == "true")
                            {
                                //SetStatus("MiSMDR is registered until " + details.expiry);
                                lb_registered.Visible = true; //now that we have validated the licence we can display the success message
                                //bn_later.Enabled = false;
                                bn_buy.Enabled = true;
                                bn_register.Text = "OK";
                                registerKey = false;
                                this.ControlBox = true;
                                if (details.licence_type == "trial")
                                {
                                    //SetStatus("Your trial license will expire in " + (Convert.ToDateTime(details.expiry) - DateTime.Now).Days.ToString() + " days unless you register.");
                                }
                                else
                                {
                                    bn_buy.Visible = false;
                                }
                            }
                            else if (details.registered == "false")
                            {
                                //SetStatus("This "+details.licence_type+" license key expired on " + details.expiry);
                            }
                            lb_registered.Visible = true;
                        }
                        else
                        {
                            if (_startup) done = false;
                            MessageBox.Show("The owner field does not match license key. Please check your registration details.", "License Key Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        done = true; //allow user to get out
                        MessageBox.Show("Registration Failed. Unable to access the registry. Please contact support@MiSMDR.info", "Registry Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                lb_registered.Text = "You must enter a new key";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CheckKey();
        }

        private void CheckKey()
        {
            if ((tb_licencekey.Text != String.Empty) && (tb_licencekey.Text != current_key)) //if not nothing and not the current key
            {
                bn_register.Enabled = true;
                bn_register.Text = "Register";
                registerKey = true;
                if (!_startup)
                {
                    done = true; //force user to enter valid code on startup
                    bn_later.Visible = true;
                    bn_later.Enabled = true;
                }
            }
            else //if it is nothing or it is the current key
            {
                bn_later.Visible = false;
                //shouldn't allow people to input the same and then click ok if it is expired
                if ((details.licence_type == "expired") || (details.licence_type == "expired-trial") || (details.licence_type == "invalid") || (details.licence_type == "unregistered"))
                {
                    if (!_startup) //if expired or invalid and NOT startup (shouldnt get to this point with expired-trial)
                    {
                        bn_register.Enabled = true;
                        bn_register.Text = "OK";
                        registerKey = false;
                        done = true;
                    }
                    else //if startup and expired, expired-trial or invalid
                    {
                        this.Width = 398;
                        this.Height = 287;
                        if (details.licence_type == "expired") SetStatus("Please enter your license key to use MiSMDR.\\par For support please visit www.MiSMDR.info/support/");
                        else if (details.licence_type == "expired-trial") SetStatus("Your trial license has expired.\\par You must purchase a license to continue using MiSMDR.\\par Please contact your reseller or visit www.MiSMDR.info");
                        else SetStatus("Please enter your license key to use MiSMDR.\\par For support please visit www.MiSMDR.info/support/");
                        bn_register.Enabled = true;
                        bn_register.Text = "Register";
                        registerKey = true;
                        done = false;
                    }
                }
                else // not expired, expired-trial unregistered or invalid
                {
                    bn_register.Enabled = true;
                    bn_register.Text = "OK";
                    registerKey = false;
                    done = true;
                }
            }
        }

        private void SetLater(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.bn_later.InvokeRequired)
            {
                SetLaterCallback d = new SetLaterCallback(SetLater);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                if (text == "Later") this.bn_later.Enabled = true;
                this.bn_later.Text = text;
                done = true;
            }
        }

        public void SetStatus(string text)
        {
            rtb_status.Rtf = @"{\rtf1\ansi\b\fs16\qc "+text.Replace("\n","\\par")+@"\b0}";
        }

        private void tb_licencekey_MouseUp(object sender, MouseEventArgs e)
        {
            tb_licencekey.SelectionStart = 0;
            tb_licencekey.SelectionLength = tb_licencekey.TextLength;
        }

        private void bn_register_Click(object sender, EventArgs e)
        {
            if (registerKey)
            {
                UpdateKey();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void bn_later_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bn_buy_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://www.MiSMDR.info/");
            Process.Start(sInfo);
        }
        private void bn_exit_Click(object sender, EventArgs e)
        {
            done = true; //allow the form to close
            Application.Exit();
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!done) e.Cancel = true; //if we are not done then cancel the closing ;)
        }

        private void rtb_status_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(e.LinkText.ToString());
            Process.Start(sInfo);
        }

    }
}
