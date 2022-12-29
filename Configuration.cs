using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TaskTrayApplication
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
        }

        private void LoadSettings(object sender, EventArgs e)
        {
            showMessageCheckBox.Checked = TaskTrayApplication.Properties.Settings.Default.ShowMessage;
        }

        private void SaveSettings(object sender, FormClosingEventArgs e)
        {
            // If the user clicked "Save"
            if (this.DialogResult == DialogResult.OK)
            {
                TaskTrayApplication.Properties.Settings.Default.ShowMessage = showMessageCheckBox.Checked;
                TaskTrayApplication.Properties.Settings.Default.Save();
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            LoadFileNow();
        }

        public static string fileName { get; set; }

        public void LoadFileNow()
        {
            OpenFileDialog openFileDialog1 = new()
            {
                InitialDirectory = "c:\\",
                Filter = "Database files (*.csv)|*.csv",
                FilterIndex = 0,
                RestoreDirectory = true
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                textBox1.Text = fileName;

            }
        }

    }
}