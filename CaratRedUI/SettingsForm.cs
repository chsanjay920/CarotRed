using CaratRedFi800RLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaratRedUI
{
    public partial class SettingsForm : UserControl
    {
        private static SettingsForm _instance;
        public EventHandler OnSettingClick { get; set; }
        public EventHandler BackToMainBoard { get; set; }
        public static SettingsForm Instance => _instance ?? (_instance = new SettingsForm());

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Domain_Name.Text = ConfigurationManager.AppSettings["Domain_Name"];
            Key.Text = ConfigurationManager.AppSettings["Key"];
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (BackToMainBoard != null)
            {
                BackToMainBoard(this, new EventArgs());
            }
        }

        private void SaveSettings_Click(object sender, EventArgs e)
        {
            string fileName = System.Reflection.Assembly.GetEntryAssembly().Location;
            UpdateConfig("Domain_Name", Domain_Name.Text, fileName);
            UpdateConfig("Key", Key.Text, fileName);
            MessageBox.Show(AppConstants.ConfigSaveMsg);

        }

        public void UpdateConfig(string key, string value, string fileName)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(fileName);
            configFile.AppSettings.Settings[key].Value = value;
            configFile.Save();
        }
    }
}
