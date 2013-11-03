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

namespace MiSMDR
{
    public partial class KeyGenerator : Form
    {
        public KeyGenerator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] rijnKey;
            byte[] rijnIV;
            Encoding byteEncoder = Encoding.UTF8;
            rijnKey = byteEncoder.GetBytes("3b2dyfxd_ob5efyiarcd8fg_ajcde4g1");
            rijnIV = byteEncoder.GetBytes("z5c6etssdbjdeeg_");
            if (textBox1.Text.Length > 0)
            {
                string encrypted = Encrypter.EncryptIt(textBox1.Text.Trim(), rijnKey, rijnIV);

                RegisteredDetails rgd;
                LicenseBreaker breaker = new LicenseBreaker(encrypted);
                rgd = breaker.BreakKey();
                MessageBox.Show(rgd.GetMD5());
                string newunencrypted = textBox1.Text.Trim() + "|md5=" + rgd.GetMD5();
                MessageBox.Show(newunencrypted);
                encrypted = Encrypter.EncryptIt(newunencrypted, rijnKey, rijnIV);

                textBox2.Text = encrypted;
            }
            textBox3.Text = Encrypter.DecryptIt(textBox2.Text.Trim(), rijnKey, rijnIV);

        }
    }
}
