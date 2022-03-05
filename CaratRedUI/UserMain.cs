using CaratRedFi800RLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaratRedUI
{
    public partial class UserMain : UserControl
    {
        AutoCompleteStringCollection autoCompleteStringCollection;

        ApiService apiService = null;

        private static UserMain _instance;
        public static UserMain Instance => _instance ?? (_instance = new UserMain());
        public String guestConfirmationNumber { get; set; }
        public String guestFirstName { get; set; }
        public int noOfAdults { get; set; }

        public EventHandler OnSettingClick { get; set; }
        public EventHandler OnSelectReg { get; set; }

        public UserMain()
        {
            InitializeComponent();

            //192.168.1.126:8001 this is the domain available in user settings panel. so we have to save this domain in the program and use it here.
            autoCompleteStringCollection = new AutoCompleteStringCollection();
            textBox1.AutoCompleteCustomSource = autoCompleteStringCollection;
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (OnSettingClick != null)
            {
                OnSettingClick(this, new EventArgs());
            }
        }

        private void UserMain_Load(object sender, EventArgs e)
        {

        }



        private async void button1_Click(object sender, EventArgs e)
        {
            apiService=new ApiService();
            var autoCompleteResponse = await apiService.GetArrivalInfoByConfirmationNumber(textBox1.Text);

            if (autoCompleteResponse.message.success.Equals("true") && autoCompleteResponse.message.data.Length == 0)
            {
                MessageBox.Show(AppConstants.InvalideConfirNumber);
                return;
            }
            if (String.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show(AppConstants.EmptyInput);
                return;
            }
            foreach (Info info in autoCompleteResponse.message.data)
            {
                if (textBox1.Text ==  info.name)
                {
                    guestConfirmationNumber = info.name;
                    guestFirstName = info.guest_first_name;
                    noOfAdults = info.no_of_adults;
                }
            }
            ConfirmationSearchCTRL.Instance.LoadGuestCards(guestConfirmationNumber, guestFirstName, noOfAdults);
            if (OnSelectReg != null)
            {
                OnSelectReg(this, new EventArgs());
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
