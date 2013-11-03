using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MiStats.ContactImporter
{
    public partial class LoadSplash : Form
    {
        public LoadSplash()
        {
            InitializeComponent();
        }
        public void showMsg(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
