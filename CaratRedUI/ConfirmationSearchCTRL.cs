using CaratRedFi800RLibrary;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class ConfirmationSearchCTRL : UserControl
    {
        private static ConfirmationSearchCTRL _instance;

        public static ConfirmationSearchCTRL Instance => _instance ?? (_instance = new ConfirmationSearchCTRL());
        public EventHandler OnSearchClick { get; set; }
        public EventHandler OnSettingClick { get; set; }
        public EventHandler OnScanClick { get; set; }
        public EventHandler OnBackClick { get; set; }

        public int NumberOfAdults { get; set; }
        public string guestConformationNumber { get; set; }

        public int x = 0, y = 0, guestcount = 0;

        public Stack<GuestCard> stackofguests = new Stack<GuestCard>();

        public ConfirmationSearchCTRL()
        {
            InitializeComponent();
        }

        public void LoadGuestCards(String guestConfNumber, String guest_first_name, int no_of_adults)
        {
            guestConformationNumber = guestConfNumber;
            NumberOfAdults = no_of_adults;
            textBox1.Text = no_of_adults.ToString();
            guestcount = no_of_adults;
            //label6.Text = guest_first_name;

            guestcount = no_of_adults;
            for (int i = 1; i <= no_of_adults; i++)
            {
                GuestCard guestCard = new GuestCard();
                guestCard.OnScanClick = OnScanClick;
                guestCard.BackColor = Color.White;
                guestCard.GuestCardInfo.GuestNumber =guestConfNumber;
                stackofguests.Push(guestCard);
                tableLayoutPanel1.Controls.Add(guestCard);
                tableLayoutPanel1.Invalidate();

                if (i == 1)
                {
                    guestCard.GuestCardInfo.GuestName = guest_first_name;
                    label6.Text = guest_first_name;
                }
                else
                {
                    guestCard.GuestCardInfo.GuestName = "Guest"+i;
                }
            }

        }

        private void ConfirmationSearchCTRL_Load(object sender, EventArgs e)
        {
            textBox2.Text = guestConformationNumber;
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (OnSearchClick != null)
            {
                OnSearchClick(this, new EventArgs());
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (OnSearchClick != null)
            {
                OnSearchClick(this, new EventArgs());
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            guestcount--;
            textBox1.Text = guestcount.ToString();
            GuestCard guestCard = stackofguests.Pop();
            tableLayoutPanel1.Controls.Remove(guestCard);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (OnSettingClick != null)
            {
                OnSettingClick(this, new EventArgs());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            if (OnBackClick != null)
            {
                OnBackClick(this, new EventArgs());
            }
        }

        private void ConfirmationSearchCTRL_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            guestcount++;
            GuestCard guestCard = new GuestCard();
            guestCard.BackColor = Color.White;
            guestCard.OnScanClick = OnScanClick;
            //guestCard.Name = "guest"+(guestcount+1).ToString();
            guestCard.GuestCardInfo.GuestName= "Guest"+guestcount;
            guestCard.GuestCardInfo.GuestNumber =textBox2.Text;
            textBox1.Text = guestcount.ToString();
            stackofguests.Push(guestCard);
            tableLayoutPanel1.Controls.Add(guestCard);
        }
        public void reload()
        {
            tableLayoutPanel1.Controls.Clear();
            foreach (GuestCard g in stackofguests)
            {
                tableLayoutPanel1.Controls.Add(g);
            }
            tableLayoutPanel1.Invalidate();
        }
    }
}
