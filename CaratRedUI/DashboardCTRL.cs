using CaratRedFi800RLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaratRedUI
{
    public partial class DashboardCTRL : UserControl
    {
        private static DashboardCTRL _instance;
        public EventHandler onForiegnClick { get; set; }
        public EventHandler onPassportClick { get; set; }
        public EventHandler onLocalIDClick { get; set; }
        public EventHandler BackToMain { get; set; }
        public GuestCardInfo CurrentGuestCard { get; set; }

        public static DashboardCTRL Instance => _instance ?? (_instance = new DashboardCTRL());
        public DashboardCTRL()
        {
            InitializeComponent();
            //label1.Text = this.CurrentGuestCard.GuestName;
        }
        private void DashboardCTRL_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void Foreginbtn_Click(object sender, EventArgs e)
        {
            ForeginCTRL.Instance.CurrentGuestCard = this.CurrentGuestCard;
            ForeginCTRL.Instance.CurrentGuestCard.SelectedCard = IndianPassprtbtn.Text;
            if (onForiegnClick != null)
            {
                onForiegnClick(this, new EventArgs());
            }
        }
        private void IndianPassprtbtn_Click(object sender, EventArgs e)
        {
            IndianPassportCTRL.Instance.CurrentGuestCard = this.CurrentGuestCard;
            IndianPassportCTRL.Instance.CurrentGuestCard.SelectedCard = IndianPassprtbtn.Text;
            if (onPassportClick != null)
            {
                onPassportClick(this, new EventArgs());
            }
        }
        private void LocalIDbtn_Click(object sender, EventArgs e)
        {
            LocalID.Instance.CurrentGuestCard = this.CurrentGuestCard;
            LocalID.Instance.CurrentGuestCard.SelectedCard = IndianPassprtbtn.Text;

            if (onLocalIDClick != null)
            {
                onLocalIDClick(this, new EventArgs());
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurrentGuestCard.SelectedCard = "foreginId";
            if (onForiegnClick != null)
            {
                ForeginCTRL.Instance.CurrentGuestCard = this.CurrentGuestCard;
                onForiegnClick(this, new EventArgs());
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (BackToMain != null)
            {
                BackToMain(this, new EventArgs());
            }
        }

        private void DashboardCTRL_MouseEnter(object sender, EventArgs e)
        {
            //label1.Text = CurrentGuestCard.GuestName;
        }

        private void DashboardCTRL_Paint(object sender, PaintEventArgs e)
        {
            label1.Text = CurrentGuestCard.GuestName;
        }
    }
}
