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

namespace MiSMDR
{
    partial class MiForm
    {
        private void LoadSplashContent()
        {
            //Main Welcome Content
            tbWelcomeContent.Rtf = @"{\rtf1\ansi
            \b Getting Started Guide\b0
            \par\par
            \b Demo Database\b0
            \par
            The demo database provides a small number of sample call records to demonstrate the application.\par
            \par
            \b Connecting to your Mitel 3300\b0
            \par
            1. Select 'Download call records from Mitel System' to switch to the live database.\par
            2. Enter the IP address of your Mitel phone system.\par
            3. Click 'Connect' to connect to your system and download the call records.\par
            4. The 'Status' icon in the bottom right will change to green when MiSMDR connects to the Mitel 3300.\par
            Once connected, MiSMDR will continually download new call records automatically.\par
            \par
            \b Important\b0
            \par
            We recommend that you only use this application from one computer.\par
            Downloading your Mitel call history from multiple computers will result in lost data.}";

        }

        private void LoadCallCostCopy()
        {
            tbCallCostHelp.Rtf = @"{\rtf1\ansi \b\fs24\qc Call Costs Help\b0\par\fs16\ql
Here you can create call cost rules to track the cost of your calls.\par
Call costs will be calculated and displayed in search results and reports for any calls which match a call cost rule.\par
\par
\b How to use:\b0\par
\bullet  To create a new call cost filter, click 'Create New'.\par
\bullet  Select 'Starts With' to match numbers that begins with a prefix (ie: '619' will match '619-xxx-xxxx')\par
\bullet  Select 'Exact Match' to match an single phone number (ie: '6194445555' will match '619-444-5555')\par
\bullet  Enter 'Connection Cost', 'Block Size' and 'Rate per Block' based on your provider's call cost.\par
\par
\b Example:\b0\par
Any call starting with '619' is charged at 5 cents per minute, with a 20 cent flag fall.\par
\bullet  'Starts With' = '619'\par
\bullet  'Connection Cost' = 20\par
\bullet  'Block Size' = 60\par
\bullet  'Rate per Block' = 5\par
\par
\b Charge for Incomplete Block\b0\par
\bullet  If your provider charges on 'entry' to a new block of time, then check this option.\par
ie: If the block size is 60 seconds, and your provider charges two blocks for 61 seconds.\par
\par
\bullet  If your provider charges on the completion of a block of time, then uncheck this option.\par
ie: If the block size is 60 seconds, and your provider charges one block for 61 seconds.\par
\par
\b Tips:\b0\par
\bullet  Click 'Test Rules' to check your call cost rules for a phone number.\par
\bullet  The first matching rule will be used.\par
\par
\b Regular Expressions (advanced users)\b0\par
\bullet  You can also use regular expressions (regex) to match a call entry.\par
\bullet  View a list of command and examples.}";
        }
        private void LoadAddressBookCopy()
        {
            tbAddressBookHelp.Rtf = @"{\rtf1\ansi \b\fs24\qc Address Book Help\b0\par\fs16\ql
You can associate a name to a phone number (internal or external) using the address book.\par
Names will be displayed in the search results and reports for any associated numbers.\par
\par
\b Tips:\b0\par
\bullet  Create address book entries for each internal extension number to easily track calls to a person or department.\par
\bullet  You can use an address book name to search for calls in 'Search Call Records'.\par
\par
\b How to use:\b0\par
\bullet  Click 'Create New' to make a new address book item.\par
\bullet  Select an address book item by clicking on it in the list.\par
\bullet  Use the 'Save' button to save any changes to a selected item.\par
\bullet  Use the 'Delete' button to remove an address book entry.}";
        }
    }
}
