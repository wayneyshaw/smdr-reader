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
using System.Security;
using System.Configuration;
using MiSMDR.Security;
using MiSMDR.DataAccessLayer;

namespace MiSMDR.DBIntegrity
{
    public class ConnStringer
    {

        public ConnStringer()
        {
        }

        public string buildExpressConnectionString(string targetMachine, string database, string login, string password, bool needEncryption)
        {
            if (needEncryption)
            {
                //tofix : this is if we allows non-admin users to install MiSMDR ? possibly needed in the future. hopefully not hard
                SecureString secure = PasswordSecurity.ToSecureString(password);
                String encrypted = PasswordSecurity.EncryptString(secure);

                return "Data Source=" + targetMachine + ";Initial Catalog=master;User Id=MiUser;Password=" + encrypted+";";
            }
            else
            {
                return "Data Source=" + targetMachine + ";Initial Catalog=" + database + ";Integrated Security=SSPI;";
                //return "Data Source=" + targetMachine + ";Initial Catalog=" + database + ";User Id=MiSMDR;Password=" + password;
            }
        }
        public string buildLiteConnectionString(string targetFile, string version, string isNew, string compress, string login, string password, bool needEncryption)
        {
            if (needEncryption)
            {
                //tofix : this is if we allows non-admin users to install MiSMDR ? possibly needed in the future. hopefully not hard
                SecureString secure = PasswordSecurity.ToSecureString(password);
                String encrypted = PasswordSecurity.EncryptString(secure);
                
                return "Data Source=" + targetFile + ";Version=" + version + ";New=" + isNew + ";Compress=" + compress + ";Login="+login+";Password="+encrypted+",";
            }
            else
            {
                return "Data Source=" + targetFile + ";Version=" + version + ";New=" + isNew + ";Compress=" + compress + ";";
                //return "Data Source=DemoT.db;Version=3;New=False;Compress=True;"
            }
        }

    }
}
