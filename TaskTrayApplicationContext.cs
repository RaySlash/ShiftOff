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
    public class TaskTrayApplicationContext : ApplicationContext
    {
        public NotifyIcon notifyIcon = new();
        public Configuration configWindow = new();

        public TaskTrayApplicationContext()
        {
            notifyIcon.Icon = new Icon(@"\AppIcon.ico");
            notifyIcon.DoubleClick += new EventHandler(ShowMessage);
            notifyIcon.ContextMenuStrip = new ContextMenuStrip() ;
            notifyIcon.ContextMenuStrip.Items.AddRange(new ToolStripItem[]
            {
                new ToolStripMenuItem("Configuration",null , new EventHandler(ShowConfig), "Configuration"),
                new ToolStripMenuItem("Exit",null , new EventHandler(Exit), "Exit")
            });
            notifyIcon.Visible = true;
        }

        private void ShowMessage(object sender, EventArgs e)
        {
            if (TaskTrayApplication.Properties.Settings.Default.ShowMessage)
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
