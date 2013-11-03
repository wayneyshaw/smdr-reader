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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MiSMDR
{
    public partial class CallInfo : UserControl
    {
        public CallInfo()
        {
            InitializeComponent();
        }

        public String CallDate
        {
            set { lbCallDate.Text = value; }
        }
        public String Duration
        {
            set { lbDuration.Text = value; }
        }
        public String TimeToAnswer
        {
            set { lbTimeToAnswer.Text = value; }
        }
        public String Direction
        {
            set { lbDirection.Text = value; }
        }

        public String CallerName
        {
            set { lbCallerName.Text = value; }
        }
        public String CallerNumber
        {
            set { lbCallerNumber.Text = value; }
        }
        public String ReceiverName
        {
            set { lbReceiverName.Text = value; }
        }
        public String ReceiverNumber
        {
            set { lbReceiverNumber.Text = value; }
        }

        public void ClearFields()
        {
            lbCallDate.Text = "";
            lbDuration.Text = "";
            lbTimeToAnswer.Text = "";
            lbDirection.Text = "";
            lbCallerName.Text = "";
            lbCallerNumber.Text = "";
            lbReceiverName.Text = "";
            lbReceiverNumber.Text = "";
        }
    }
}
