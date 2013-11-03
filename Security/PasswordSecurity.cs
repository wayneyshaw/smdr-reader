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
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System;
using System.IO;
using System.Globalization;
using MiSMDR.Logger;
using System.Text.RegularExpressions;

namespace MiSMDR.Security
{
    public class StringSecurity
    {
        public static string EncryptString(string data, string key, string iv)
        {
            try
            {
                byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
                Rijndael alg = Rijndael.Create();
                alg.Padding = PaddingMode.Zeros;
                alg.Mode = CipherMode.CBC;
                alg.Key = System.Text.Encoding.UTF8.GetBytes(key);
                alg.KeySize = 128;
                alg.IV = System.Text.Encoding.UTF8.GetBytes(iv);
                //alg.GenerateIV();
                ICryptoTransform encryptor = alg.CreateEncryptor(alg.Key,alg.IV);
                byte[] Buffer = System.Text.Encoding.UTF8.GetBytes(data);
                //return Convert.ToBase64String(alg.IV);
                //return Convert.ToBase64String(encryptor.TransformFinalBlock(Buffer, 0, Buffer.Length));

                MemoryStream memoryStream = new MemoryStream();

                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(dataBytes, 0, dataBytes.Length);

                cryptoStream.FlushFinalBlock();

                byte[] cipherTextBytes = memoryStream.ToArray();

                memoryStream.Close();
                cryptoStream.Close();

                return Convert.ToBase64String(cipherTextBytes);
            }
            catch(Exception ex)
            {
                return "FAIL"+ex.ToString();
            }
        }
        public static string DecryptString(string data, string key, string iv)
        {
            try
            {
                byte[] dataBytes = Convert.FromBase64String(data);
                Rijndael alg = Rijndael.Create(); // RJ128 by default
                alg.Padding = PaddingMode.Zeros;
                alg.Mode = CipherMode.CBC;
                alg.Key = System.Text.Encoding.UTF8.GetBytes(key);
                alg.KeySize = 128;
                alg.IV = System.Text.Encoding.UTF8.GetBytes(iv);
                //alg.GenerateIV();
                ICryptoTransform decryptor = alg.CreateDecryptor(alg.Key,alg.IV);
                byte[] Buffer = Convert.FromBase64String(data);
                //return Convert.ToBase64String(decryptor.TransformFinalBlock(Buffer, 0, Buffer.Length));
                
                MemoryStream memoryStream = new MemoryStream(dataBytes);

                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Write);
                cryptoStream.Write(dataBytes, 0, dataBytes.Length);

                cryptoStream.FlushFinalBlock();

                byte[] cipherTextBytes = memoryStream.ToArray();

                memoryStream.Close();
                cryptoStream.Close();

                return Convert.ToBase64String(cipherTextBytes);
            }
            catch(Exception ex)
            {
                return "Invalid Key"+ex.ToString();
            }
        }
    }
    public class PasswordSecurity
    {
        static byte[] entropy = System.Text.Encoding.Unicode.GetBytes("your special salt");

        public static string EncryptString(System.Security.SecureString input)
        {
            byte[] encryptedData = System.Security.Cryptography.ProtectedData.Protect(
                System.Text.Encoding.Unicode.GetBytes(ToInsecureString(input)),
                entropy,
                System.Security.Cryptography.DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(encryptedData);
        }

        public static SecureString DecryptString(string encryptedData)
        {
            try
            {
                byte[] decryptedData = System.Security.Cryptography.ProtectedData.Unprotect(
                    Convert.FromBase64String(encryptedData),
                    entropy,
                    System.Security.Cryptography.DataProtectionScope.CurrentUser);
                return ToSecureString(System.Text.Encoding.Unicode.GetString(decryptedData));
            }
            catch
            {
                return new SecureString();
            }
        }

        public static SecureString ToSecureString(string input)
        {
            SecureString secure = new SecureString();
            foreach (char c in input)
            {
                secure.AppendChar(c);
            }
            secure.MakeReadOnly();
            return secure;
        }

        public static string ToInsecureString(SecureString input)
        {
            string returnValue = string.Empty;
            IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(input);
            try
            {
                returnValue = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
            }
            return returnValue;
        }

        public static string GetPassword(string connectionString)
        {
            try
            {
                string[] csComponents = connectionString.Split(';');

                string pwdComponent = csComponents[3]; //password
                string pwd = pwdComponent.Substring(9, pwdComponent.Length - 9);
                
                SecureString encrypted = PasswordSecurity.DecryptString(pwd);
                return PasswordSecurity.ToInsecureString(encrypted);
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
    
     public class rot13
     {
         private string str;
         private string mystr = ""; 
        // Public 
        public void setstr(string temp) { 
            this.str=temp; 
        } 

        public string getstr() { 
            return this.str; 
        }

        public string getenc()
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();

            byte[] data = System.Text.Encoding.ASCII.GetBytes(this.mystr);

            data = x.ComputeHash(data);

            return Convert.ToBase64String(data);

            //return this.mystr;
        }

        public void doit()
        {
            char x;
            for (int i = 0; i < str.Length; i++)
            {
                // If lowercase, add 13 and if it its gone past 
                // z then subtract 26 so it gets that much deviation 
                // from a instead of returning some wierd character 
                if (((int)str[i] >= 65) && ((int)str[i] < 91))
                {
                    x = (char)((int)str[i] + 13);
                    if ((int)x >= 91) { x = (char)((int)x - 26); }
                }
                else
                {
                    // If uppercase, add 13 and if it its gone past 
                    // Z then subtract 26 so it gets that much deviation 
                    // from A instead of returning some wierd character 
                    if (((int)str[i] >= 97) && ((int)str[i] < 123))
                    {
                        x = (char)((int)str[i] + 13);
                        if ((int)x >= 123) { x = (char)((int)x - 26); }
                    }
                    else
                    {
                        // If its a special character, ie not upper 
                        // or lower case then just return as it is 
                        x = this.str[i];
                    }
                }
                // Append the encrypted char to mystr 
                this.mystr += Convert.ToString(x);
            }
        }
    }
     public static class Encrypter
     {
         public static String EncryptIt(String s, byte[] key, byte[] IV)
         {
             String result;

             RijndaelManaged rijn = new RijndaelManaged();
             rijn.Mode = CipherMode.ECB;
             rijn.Padding = PaddingMode.Zeros;

             using (MemoryStream msEncrypt = new MemoryStream())
             {
                 using (ICryptoTransform encryptor = rijn.CreateEncryptor(key, IV))
                 {
                     using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                     {
                         using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                         {
                             swEncrypt.Write(s);
                         }
                     }
                 }
                 result = Convert.ToBase64String(msEncrypt.ToArray());
             }
             rijn.Clear();

             return result;
         }

         public static String DecryptIt(String s, byte[] key, byte[] IV)
         {
             String result;

             RijndaelManaged rijn = new RijndaelManaged();
             rijn.Mode = CipherMode.ECB;
             rijn.Padding = PaddingMode.Zeros;

             using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(s)))
             {
                 using (ICryptoTransform decryptor = rijn.CreateDecryptor(key, IV))
                 {
                     using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                     {
                         using (StreamReader swDecrypt = new StreamReader(csDecrypt))
                         {
                             result = swDecrypt.ReadToEnd();
                         }
                     }
                 }
             }
             rijn.Clear();

             return result;
         }
     }
     public class LicenseBreaker
     {
         private RegisteredDetails details;
         byte[] rijnKey;
         byte[] rijnIV;

         public LicenseBreaker(string input_key)
         {
             details = new RegisteredDetails();
             details.key = input_key;
             Encoding byteEncoder = Encoding.UTF8;
             rijnKey = byteEncoder.GetBytes("3b2dyfxd_ob5efyiarcd8fg_ajcde4g1");
             rijnIV = byteEncoder.GetBytes("z5c6etssdbjdeeg_");
         }
         public RegisteredDetails BreakKey()
         {
             try
             {
                 if ((details.key != null)&&(details.key!=String.Empty))
                 {
                     String decryption = Encrypter.DecryptIt(details.key, rijnKey, rijnIV); //decrypt the key
                     decryption.Replace(";;;;", "|");
                     string[] arr = decryption.Split('|');
                     foreach (string var in arr)
                     {
                         string[] pair = var.Split('=');
                         string key = pair[0].Replace("\"", "");
                         string value = pair[1].Replace("\"", "");
                         if (key == "registered")
                         {
                             // opensource version is always registered
                             //if (value == "true")
                             if (true)
                             {
                                 details.registered = "true";
                             }
                             else
                             {
                                 details.registered = "false";
                             }
                         }
                         else if ((key == "licence-type") || (key == "license-type"))
                         {
                             details.licence_type = value;
                             details.orig_licence_type = value.Trim();
                         }
                         else if (key == "expiry")
                         {
                             details.SetExpiry(value);

                             if (Convert.ToDateTime(value) < DateTime.Now)
                             {
                                 details.orig_licence_type = details.licence_type; // record original type
                                 if ((details.registered == "true") && (details.licence_type == "trial"))
                                 {
                                     details.licence_type = "expired-trial";
                                 }
                                 else
                                 {
                                     details.licence_type = "expired";
                                 }
                                 details.registered = "false";
                             }
                         }
                         else if (key == "c_email")
                         {
                             details.c_email = value;
                         }
                         else if (key == "c_name")
                         {
                             details.c_name = value;
                         }
                         else if (key == "reseller")
                         {
                             details.reseller = value;
                         }
                         else if (key == "md5")
                         {
                             //string pattern = "[^a-zA-Z 0-9]"; //regex pattern 
                             //string result = Regex.Replace(value, pattern, "");
                             details.md5Str = value.Trim().Replace("\0", ""); //weird arse null characer on the end of the md5 string
                         }
                     }
                     if (!details.CheckMD5())
                     {
                         //invalid MD5 therefore the code has been tampered with
                         details.registered = "false";
                         details.licence_type = "invalid";
                     }
                 }
                 else
                 {
                     details.registered = "false";
                     details.licence_type = "unregistered";
                 }
             }
             catch (Exception ex)
             {
                 details.registered = "false";
                 details.licence_type = "invalid";
                 LogManager.Log(LogEntryType.Error, SourceType.MiSMDR, "Licensing Error: " + ex.ToString());
             }
             return details;
         }
         
     }
     public class RegisteredDetails
     {
         public string registered;
         public string key;
         public string c_name;
         public string c_email;
         public string expiry;
         public string orig_expiry;
         public string reseller;
         public string licence_type;
         public string orig_licence_type;
         public string md5Str;

         public RegisteredDetails()
         {
             registered = "invalid";
             licence_type = "invalid";
             orig_licence_type = "invalid";
             c_name = "";
             c_email = "";
             expiry = "";
             reseller = "";
             md5Str = "";
         }
         public void SetExpiry(string input_expiry)
         {
             orig_expiry = input_expiry;
             expiry = Convert.ToDateTime(input_expiry).ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
         }
         public bool CheckMD5()
         {
             //md5($_REQUEST['licence-type'].$_REQUEST['expiry'].$_REQUEST['c_name'].$_REQUEST['c_email'].$_REQUEST['reseller']);

             string newMd5 = GetMD5();
             if (newMd5 == md5Str) return true;
             else return false;
         }
         public string MD5(string password)
         {
             byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(password);
             try
             {
                 System.Security.Cryptography.MD5CryptoServiceProvider cryptHandler;
                 cryptHandler = new System.Security.Cryptography.MD5CryptoServiceProvider();
                 byte[] hash = cryptHandler.ComputeHash(textBytes);
                 string ret = "";
                 foreach (byte a in hash)
                 {
                     if (a < 16)
                         ret += "0" + a.ToString("x");
                     else
                         ret += a.ToString("x");
                 }
                 return ret;
             }
             catch
             {
                 throw;
             }
         }
         public string GetMD5()
         {
             string temp = orig_licence_type + orig_expiry + c_name + c_email + reseller;
             Encoding byteEncoder = Encoding.UTF8;
             byte[] temp2 = byteEncoder.GetBytes(temp);
             return MD5(Convert.ToBase64String(temp2)).Trim();
         }
     }
}
