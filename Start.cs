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
                using var writer = new StreamWriter(@"C:\Users\alfred\Downloads\test.csv", false);
                var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                // string date = DateTime.Now.ToString("d");
                // string time = DateTime.Now.ToString("T");
                csv.WriteRecords(textBox1.Text);
                // csv.WriteRecord(date);
                // csv.WriteRecord(time);
                writer.Flush();
                csv.Flush();
            }
        }
    }
}