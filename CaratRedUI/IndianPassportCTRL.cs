using CaratRedFi_800RLibrary;
using CaratRedFi800RLibrary;
using FiScnUtildN;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CaratRedUI
{
    public partial class IndianPassportCTRL : UserControl
    {
        ScannerConnection sc;
        Bitmap bitmap;
        bool Flag = false;
        Bitmap picture1;
        Bitmap picture2;

        private static IndianPassportCTRL _instance;
        public GuestCardInfo CurrentGuestCard { get; set; }

        public EventHandler BackToDashBoard2 { get; set; }
        public EventHandler BackToConformationSearch { get; set; }

        public static IndianPassportCTRL Instance => _instance ?? (_instance = new IndianPassportCTRL());
        public IndianPassportCTRL()
        {
            Flag = false;
            InitializeComponent();
            sc = new ScannerConnection();
            sc.axFiScn1.ScanToRawEx += axFiScn1_ScanToRawEx;
            sc.axFiScn1.CreateControl();
            // label5.Text = CurrentGuestCard.GuestName;
        }

        private void IndianPassportCTRL_Load(object sender, EventArgs e)
        {

        }

        private void IndianPassportCTRL_Load_1(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Flag = true;
            pictureBox3.Image = null;
            sc.ForeignId(Handle.ToInt32());
            //SplitImage(bitmap);


            Form2 form2 = new Form2(bitmap);
            form2.ShowDialog();
            pictureBox3.Image = form2.SelectedImage;
            CurrentGuestCard.Image1 = pictureBox3.Image as Bitmap;

            button9.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (BackToDashBoard2 != null)
            {
                BackToDashBoard2(this, new EventArgs());
            }
        }

        private void axFiScn1_ScanToRawEx(object sender, AxFiScnLib._DFiScnEvents_ScanToRawExEvent e)
        {
            ConvH2BM Conv = new ConvH2BM();
            bitmap = Conv.GetBitmapFromRAW(e.resolution, e.imageWidth, e.imageLength, e.bitPerPixel, e.compressionType, e.size, e.raw);

            if (Flag == false)
            {
                if (pictureBox3.Image == null)
                {
                    pictureBox3.Image = bitmap;
                }
                else
                {
                    pictureBox3.Image = bitmap;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Flag = true;
            pictureBox4.Image = null;
            sc.ForeignId(Handle.ToInt32());
            //SplitImage(bitmap);

            Form2 form2 = new Form2(bitmap);
            form2.ShowDialog();
            pictureBox4.Image = form2.SelectedImage;
            CurrentGuestCard.Image2 = pictureBox4.Image as Bitmap;
            button11.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Flag = true;
            sc.ForeignId(Handle.ToInt32());
            //SplitImage(bitmap);


            Form2 form2 = new Form2(bitmap);
            form2.ShowDialog();
            pictureBox3.Image = form2.SelectedImage;
            CurrentGuestCard.Image1 = pictureBox3.Image as Bitmap;

            button9.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Flag = true;
            sc.ForeignId(Handle.ToInt32());
            //SplitImage(bitmap);

            Form2 form2 = new Form2(bitmap);
            form2.ShowDialog();
            pictureBox4.Image = form2.SelectedImage;
            CurrentGuestCard.Image2 = pictureBox4.Image as Bitmap;
            button11.Visible = false;
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            ApiService apiService = new ApiService();

            picture1 = (Bitmap)pictureBox3.Image;
            System.IO.MemoryStream ms1 = new MemoryStream();
            picture1.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] byteImage1 = ms1.ToArray();
            CurrentGuestCard.SigBase64_Img1 = Convert.ToBase64String(byteImage1);
            //textBox1.Text = SigBase641;

            picture2 = (Bitmap)pictureBox4.Image;
            System.IO.MemoryStream ms2 = new MemoryStream();
            picture2.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] byteImage2 = ms2.ToArray();
            CurrentGuestCard.SigBase64_Img2 = Convert.ToBase64String(byteImage2);
            //textBox1.Text = SigBase642;

            String response = await apiService.UploadInfoToFile(CurrentGuestCard);

            MessageBox.Show(response);

            CurrentGuestCard.Image1 = picture1;
            CurrentGuestCard.Image2 = picture2;
            CurrentGuestCard.Submitted = true;
            //CurrentGuestCard.GuestName = **** Guest Name through lable
            if (BackToConformationSearch != null)
            {
                BackToConformationSearch(this, new EventArgs());
            }
        }

        private void IndianPassportCTRL_Paint(object sender, PaintEventArgs e)
        {
            label5.Text = CurrentGuestCard.GuestName;
        }
    }
}
