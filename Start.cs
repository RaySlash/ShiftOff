using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        private void SaveSettings(object sender, FormClosingEventArgs e)
        {
            // If the user clicked "Save"
            if (this.DialogResult == DialogResult.OK)
            {
                Properties.Settings.Default.Save();
                var Configuration = new Configuration();
                string writeDirectory = Configuration.fileName;
                // using (var writer = new StreamWriter(writeDirectory, false))
                // using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    string dateTimeValue = DateTime.Now.ToString();                
                    // csv.WriteRecord(dateTimeValue);
                    // writer.Flush();
                    // csv.Flush();
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }
    }
}