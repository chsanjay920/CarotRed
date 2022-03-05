using CaratRedFi_800RLibrary;
using CaratRedFi800RLibrary;
using FiScnUtildN;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaratRedUI
{
    public partial class LocalID : UserControl
    {
        ScannerConnection sc;
        Bitmap bitmap;
        Bitmap picture1;
        Bitmap picture2;
        bool Flag = false;
        private static LocalID _instance;
        public GuestCardInfo CurrentGuestCard { get; set; }
        public EventHandler BackToDashBoard { get; set; }
        public EventHandler BackToConformationSearch { get; set; }
        public static LocalID Instance => _instance ?? (_instance = new LocalID());
        public LocalID()
        {
            Flag = false;
            InitializeComponent();
            sc = new ScannerConnection();
            sc.axFiScn1.ScanToRawEx += axFiScn1_ScanToRawEx;
            sc.axFiScn1.CreateControl();
            //label1.Text = CurrentGuestCard.GuestName;
        }
        private void button5_Click(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (BackToDashBoard != null)
            {
                BackToDashBoard(this, new EventArgs());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            sc.LocalId(Handle.ToInt32());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            sc.LocalId(Handle.ToInt32());
        }

        private void axFiScn1_ScanToRawEx(object sender, AxFiScnLib._DFiScnEvents_ScanToRawExEvent e)
        {
            ConvH2BM Conv = new ConvH2BM();
            bitmap = Conv.GetBitmapFromRAW(e.resolution, e.imageWidth, e.imageLength, e.bitPerPixel, e.compressionType, e.size, e.raw);

            if (Flag == false)
            {
                if (pictureBox2.Image == null)
                {
                    pictureBox2.Image = bitmap;
                    //button1.Visible = false;
                }
                else
                {
                    pictureBox3.Image = bitmap;
                    //button6.Visible = false;
                }
            }
            CurrentGuestCard.Image1 = pictureBox1.Image as Bitmap;
            CurrentGuestCard.Image2 = pictureBox2.Image as Bitmap;
            CurrentGuestCard.SelectedCard = "localId";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            sc.LocalId(Handle.ToInt32());
            button4.Text = "Re-Scan";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            pictureBox3.Image = null;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            ApiService apiService = new ApiService();

            picture1 = (Bitmap)pictureBox2.Image;
            System.IO.MemoryStream ms1 = new MemoryStream();
            picture1.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] byteImage1 = ms1.ToArray();
            CurrentGuestCard.SigBase64_Img1 = Convert.ToBase64String(byteImage1);

            picture2 = (Bitmap)pictureBox3.Image;
            System.IO.MemoryStream ms2 = new MemoryStream();
            picture2.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] byteImage2 = ms2.ToArray();
            CurrentGuestCard.SigBase64_Img2 = Convert.ToBase64String(byteImage2);

            String response = await apiService.UploadInfoToFile(CurrentGuestCard);
            MessageBox.Show(response);

            CurrentGuestCard.Image1 = picture1;
            CurrentGuestCard.Image2 = picture2;
            CurrentGuestCard.Submitted = true;
            if (BackToConformationSearch != null)
            {
                BackToConformationSearch(this, new EventArgs());
            }
        }

        private void LocalID_Validated(object sender, EventArgs e)
        {

        }

        private void LocalID_MouseEnter(object sender, EventArgs e)
        {
            // label1.Text = CurrentGuestCard.GuestName;
        }

        private void LocalID_Paint(object sender, PaintEventArgs e)
        {
            label1.Text = CurrentGuestCard.GuestName;
        }
    }
}
