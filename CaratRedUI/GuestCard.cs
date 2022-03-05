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
    public partial class GuestCard : UserControl
    {
        public GuestCardInfo GuestCardInfo { get; set; }


        public EventHandler OnScanClick { get; set; }

        public GuestCard()
        {
            InitializeComponent();
            GuestCardInfo= new GuestCardInfo();
            GuestCardInfo.Submitted = false;
        }


        private void GuestCard_Load(object sender, EventArgs e)
        {
            if (GuestCardInfo!=null)
            {
                label1.Text = GuestCardInfo.GuestName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (OnScanClick != null)
            {
                OnScanClick(this, new EventArgs());
            }
        }
    }
}
