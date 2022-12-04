using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TaskTrayApplication
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void LoadSettings(object sender, EventArgs e)
        {
        }

        private void SaveSettings(object sender, FormClosingEventArgs e)
        {
            // If the user clicked "Save"
            if (this.DialogResult == DialogResult.OK)
            {
                TaskTrayApplication.Properties.Settings.Default.Save();
            }
        }
    }
}