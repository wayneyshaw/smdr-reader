using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using MiStats.BusinessLogicLayer;
using MiStats.DataAccessLayer;
using System.Threading;
using LumenWorks.Framework.IO.Csv;
using System.Windows.Forms;

namespace MiStats.ContactImporter
{
    public class GoogleImporter
    {
        private DataProvider _provider;
        private string _connectionString;
        private LoadSplash loader;

        public GoogleImporter(string connString, DataProvider provider)
        {
            _provider = provider;
            _connectionString = connString;
            loader = new LoadSplash();
        }

        public void StepProgress()
        {

        }

        public void importFile(string path, bool withNumbersOnly)
        {

            /* Read the initial time. */
            DateTime startTime = DateTime.Now;

            TextReader tr = new StreamReader(path);
            string output = "";
            int count = 0;
            //Get number of lines so we can update the progress bar
            output = tr.ReadLine();
            while (output!=null)
            {
                count++;
                output = tr.ReadLine();
            }
            //after "count" should be the total number of lines in the contacts file

            //display Progress Bar form
            loader.miLoaderProgress.Maximum = count;
            loader.miLoaderProgress.Step = 1;
            loader.Show();

            // create reader & open file //tofix try catch
            tr = new StreamReader(path);

            // read a line of text
            output = tr.ReadLine();
            // set the header
            Regex regexAdditionals = new Regex(":::", RegexOptions.None);
            Regex regex = new Regex(",", RegexOptions.None);
            string[] headers = regex.Split(output);
            // Next Line
            output = tr.ReadLine();

            ContactManager contactManager = new ContactManager(_connectionString, _provider);
            PhoneNumberManager phoneManager = new PhoneNumberManager(_connectionString, _provider);

            while (output != null)
            {
                string name = "", email = "", numbers = "", desc = "";
                List<contactNumber> contactNumbers = new List<contactNumber>();

                //get the current line output
                string[] csv = regex.Split(output);

                for (int i = 0; i < headers.Length; i++)
                {
                    if (csv[i] != String.Empty)
                    {
                        if (headers[i] == "Name") name = csv[i] + " ";
                        //Emails
                        else if (headers[i].StartsWith("E-mail") && headers[i].EndsWith("Value"))
                        {
                            if (csv[i].Contains(":::"))
                            {
                                string[] splitEmails = regexAdditionals.Split(csv[i]);
                                foreach (string eAddress in splitEmails)
                                {
                                    email += eAddress + ", ";
                                }
                            }
                            else
                            {
                                email += csv[i];
                            }
                        }
                        //Phone numbers
                        else if ((headers[i].StartsWith("Phone")) && (headers[i].EndsWith("Type")))
                        {
                            if (csv[i + 1].Contains(":::"))
                            {
                                string[] splitNumbers = regexAdditionals.Split(csv[i + 1]);
                                foreach (string number in splitNumbers)
                                {
                                    if (csv[i] != String.Empty)
                                    {
                                        contactNumbers.Add(new contactNumber(csv[i], number));
                                    }
                                    numbers += " " + csv[i] + ": " + number;
                                }
                            }
                            else
                            {
                                if (csv[i] != String.Empty)
                                {
                                    contactNumbers.Add(new contactNumber(csv[i], csv[i + 1]));
                                }
                                numbers += " " + csv[i] + ": " + csv[i + 1];
                            }
                        }
                        //description info
                        else if ((headers[i] == "Organization 1 - Name") || (headers[i] == "Organization 1 - Title") || (headers[i] == "Notes"))
                        {
                            if (desc == String.Empty) desc += csv[i];
                            else desc += " - " + csv[i];
                        }
                    }
                }

                //Clean the data
                name = name.Trim().Replace("\"", "").Replace("'", "");
                desc = desc.Trim().Replace("\"", "").Replace("'", "");
                email = email.Trim().Replace("\"", "").Replace("'", "");

                //Create a new Contact
                List<ValidationError> errors = new List<ValidationError>();

                // Add the contact into the database
                if((!withNumbersOnly) || (contactNumbers.Count>0)) errors = contactManager.AddContact(name, desc, email);


                //tofix throw errors

                loader.miLoaderProgress.PerformStep();

                foreach (contactNumber cont in contactNumbers)
                {
                    cont.id = contactManager._lastid;
                    cont.type = "External";

                    //#### Option 1 - 23.73 seconds
                    //ThreadPool.QueueUserWorkItem(new WaitCallback(phoneManager.AddPhoneNumberNoReturn), cont);

                    //#### Option 2 - 20.76 seconds
                    try
                    {
                        errors = phoneManager.AddPhoneNumber(cont.id, cont.number, cont.description, cont.type);
                    }
                    catch (Exception ex)
                    {
                        errors.Add(new ValidationError(ex.ToString()));
                    }

                    if (errors.Count > 0)
                    {
                        MessageBox.Show("Error occured when importing the phone numbers");
                        foreach (ValidationError err in errors)
                        {
                            loader.showMsg(err.GetMesssage());
                        }
                    }
                    //#### Option 3 - 22.93 seconds
                    //ThreadedContactAdder fetcher = new ThreadedContactAdder(cont,_connectionString,_provider);
                    //new Thread(new ThreadStart(fetcher.AddNumber)).Start();

                }
                
                // Next Line
                output = tr.ReadLine();
            }

            /* Read the end time. */
            DateTime stopTime = DateTime.Now;

            /* Compute the duration between the initial and the end time. */
            TimeSpan duration = stopTime - startTime;
            loader.showMsg(duration.ToString());

            loader.Close();
            // close the stream
            tr.Close();

        }
        public List<ValidationError> ReadCsv(string path, bool withNumbersOnly)
        {
            /* Read the initial time. */
            DateTime startTime = DateTime.Now;
            List<ValidationError> errors = new List<ValidationError>();

            int _i = 0;
            // open the file "data.csv" which is a CSV file with headers
            using (CsvReader csv = new CsvReader(new StreamReader(path), true))
            {
                int fieldCount = csv.FieldCount;
                string[] headers = csv.GetFieldHeaders();

                Regex regexAdditionals = new Regex(":::", RegexOptions.None);

                loader.miLoaderProgress.Maximum = fieldCount;
                loader.miLoaderProgress.Step = 1;
                loader.Show();
                ContactManager contactManager = new ContactManager(_connectionString, _provider);
                PhoneNumberManager phoneManager = new PhoneNumberManager(_connectionString, _provider);

                while (csv.ReadNextRecord())
                {
                    string name = "", email = "", numbers = "", desc = "";
                    List<contactNumber> contactNumbers = new List<contactNumber>();


                    for (int i = 0; i < fieldCount; i++)
                    {
                        //Console.Write(string.Format("{0} = {1};", headers[i], csv[i]));
                        _i = i;
                        if (csv[i] != String.Empty)
                        {
                            if (headers[i] == "Name") name = csv[i] + " ";
                                //Emails
                            else if (headers[i].StartsWith("E-mail") && headers[i].EndsWith("Value"))
                            {
                                if (csv[i].Contains(":::"))
                                {
                                    string[] splitEmails = regexAdditionals.Split(csv[i]);
                                    foreach (string eAddress in splitEmails)
                                    {
                                        email += eAddress + ", ";
                                    }
                                }
                                else
                                {
                                    email += csv[i];
                                }
                            }
                                //Phone numbers
                            else if ((headers[i].StartsWith("Phone")) && (headers[i].EndsWith("Type")))
                            {
                                if (csv[i + 1].Contains(":::"))
                                {
                                    string[] splitNumbers = regexAdditionals.Split(csv[i + 1]);
                                    foreach (string number in splitNumbers)
                                    {
                                        if (csv[i] != String.Empty)
                                        {
                                            contactNumbers.Add(new contactNumber(csv[i], number));
                                        }
                                        numbers += " " + csv[i] + ": " + number;
                                    }
                                }
                                else
                                {
                                    if (csv[i] != String.Empty)
                                    {
                                        contactNumbers.Add(new contactNumber(csv[i], csv[i + 1]));
                                    }
                                    numbers += " " + csv[i] + ": " + csv[i + 1];
                                }
                            }
                                //description info
                            else if ((headers[i] == "Organization 1 - Name") || (headers[i] == "Organization 1 - Title") || (headers[i] == "Notes"))
                            {
                                if (desc == String.Empty) desc += csv[i];
                                else desc += " - " + csv[i];
                            }
                        }
                    }

                    //Clean the data
                    name = name.Trim().Replace("\"", "").Replace("'", "");
                    desc = desc.Trim().Replace("\"", "").Replace("'", "");
                    email = email.Trim().Replace("\"", "").Replace("'", "");


                    // Add the contact into the database
                    if ((!withNumbersOnly) || (contactNumbers.Count > 0))
                    {
                        //Create a new error list
                        List<ValidationError> contactErrors = new List<ValidationError>();
                        try
                        {
                            contactErrors = contactManager.AddContact(name, desc, email);
                        }
                        catch (Exception ex)
                        {
                            contactErrors.Add(new ValidationError(ex.ToString()));
                        }

                        if (errors.Count > 0)
                        {
                            foreach (ValidationError err in contactErrors)
                            {
                                errors.Add(err);
                            }
                        }
                        else
                        {
                            foreach (contactNumber cont in contactNumbers)
                            {
                                cont.id = contactManager._lastid;
                                cont.type = "External";
                                if (cont.id != String.Empty)
                                {
                                    List<ValidationError> newErrors = phoneManager.AddPhoneNumber(cont.id, cont.number, cont.description, cont.type);
                                    if (newErrors.Count > 0)
                                    {
                                        foreach (ValidationError err in newErrors)
                                        {
                                            errors.Add(err);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //tofix throw errors
                    loader.miLoaderProgress.PerformStep();
                }
            }

            /* Read the end time. */
            DateTime stopTime = DateTime.Now;

            /* Compute the duration between the initial and the end time. */
            TimeSpan duration = stopTime - startTime;
            loader.showMsg(duration.ToString()+"  and i="+_i);

            loader.Close();
            return errors;
        }
        
    }
}
