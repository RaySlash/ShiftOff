using System;
using System.Collections.Generic;
using System.Drawing.Configuration;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using TaskTrayApplication.Properties;
using static System.Windows.Forms.DataFormats;

namespace TaskTrayApplication
{
    public static class Prompt
    {
        // Dialog box for user-input project code.
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label dialogTextLabel = new() { Left = 50, Top = 20, Text = text };
            TextBox dialogTextBox = new() { Left = 50, Top = 50, Width = 400 };
            Button dialogConfirmation = new() { Text = "Start", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            dialogConfirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(dialogTextBox);
            prompt.Controls.Add(dialogConfirmation);
            prompt.Controls.Add(dialogTextLabel);
            prompt.AcceptButton = dialogConfirmation;

            return prompt.ShowDialog() == DialogResult.OK ? dialogTextBox.Text : "";
        }
    }
    public class TaskTrayApplicationContext : ApplicationContext
    {
        public NotifyIcon notifyIcon = new();
        public Configuration configWindow = new();
        public string startMenuText = "Start";
        public List<string> projectCode = new();

        public TaskTrayApplicationContext()
        {
            notifyIcon.Icon = new Icon(@"\AppIcon.ico");
            notifyIcon.DoubleClick += new EventHandler(ShowMessage);
            notifyIcon.ContextMenuStrip = new ContextMenuStrip() ;
            notifyIcon.ContextMenuStrip.Items.AddRange(new ToolStripItem[]
            {
                // Variable text for Start or Stop Event
                new ToolStripMenuItem(startMenuText ,null , new EventHandler(Start), startMenuText),
                new ToolStripMenuItem("Configuration",null , new EventHandler(ShowConfig), "Configuration"),
                new ToolStripMenuItem("Exit",null , new EventHandler(Exit), "Exit")
            });
            notifyIcon.Visible = true;
        }

        private void Start(object sender, EventArgs e)
        {
            Prompt.ShowDialog("Start", @"Enter your project code(s):");
            dialogTextBox.Text
            projectCode.Add();
            startMenuText = "Stop";
        }
        private void ShowMessage(object sender, EventArgs e)
        {
            if (Settings.Default.ShowMessage)
                MessageBox.Show("Hello World");
        }

        private void ShowConfig(object sender, EventArgs e)
        {
            // If we are already showing the window meerly focus it.
            if (configWindow.Visible)
                configWindow.Focus();
            else
                configWindow.ShowDialog();
        }

        private void Exit(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;

            Application.Exit();
        }
    }
}
