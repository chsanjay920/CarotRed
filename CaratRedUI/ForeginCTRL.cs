using CaratRedFi_800RLibrary;
using CaratRedFi800RLibrary;
using FiScnUtildN;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CaratRedUI
{
    public partial class ForeginCTRL : UserControl
    {
        ScannerConnection sc;
        Bitmap bitmap;
        bool Flag = false;

        Bitmap picture1;
        Bitmap picture2;

        public GuestCardInfo CurrentGuestCard { get; set; }
        private static ForeginCTRL _instance;
        public EventHandler BackToDashBoard1 { get; set; }
        public EventHandler BackToConformationSearch { get; set; }
        public static ForeginCTRL Instance => _instance ?? (_instance = new ForeginCTRL());
        public ForeginCTRL()
        {
            Flag = false;
            InitializeComponent();
            sc = new ScannerConnection();
            sc.axFiScn1.ScanToRawEx += axFiScn1_ScanToRawEx;
            sc.axFiScn1.CreateControl();
        }

        private void ForeginCTRL_Load(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Flag = true;
            pictureBox1.Image = null;
            sc.ForeignId(Handle.ToInt32());
            //SplitImage(bitmap);

            Form2 form2 = new Form2(bitmap);
            form2.ShowDialog();
            pictureBox1.Image = form2.SelectedImage;
            CurrentGuestCard.Image1 = pictureBox1.Image as Bitmap;

            button5.Visible = false;
        }

        private void axFiScn1_ScanToRawEx(object sender, AxFiScnLib._DFiScnEvents_ScanToRawExEvent e)
        {
            ConvH2BM Conv = new ConvH2BM();
            bitmap = Conv.GetBitmapFromRAW(e.resolution, e.imageWidth, e.imageLength, e.bitPerPixel, e.compressionType, e.size, e.raw);

            if (Flag == false)
            {
                if (pictureBox1.Image == null)
                {
                    pictureBox1.Image = bitmap;
                }
                else
                {
                    pictureBox2.Image = bitmap;
                }
            }
        }
        private void SplitImage(Bitmap bmp)
        {
            Bitmap image = bmp;
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height/2);
            Bitmap firstHalf = image.Clone(rect, image.PixelFormat);
            pictureBox1.Image = firstHalf;
            rect = new Rectangle(0, image.Height / 2, image.Width, image.Height/2);
            Bitmap secondHalf = image.Clone(rect, image.PixelFormat);
            pictureBox2.Image = secondHalf;
            Flag = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Flag = true;
            pictureBox4.Image = null;
            sc.ForeignId(Handle.ToInt32());
            //SplitImage(bitmap);

            Form2 form2 = new Form2(bitmap);
            form2.ShowDialog();
            pictureBox4.Image = form2.SelectedImage;
            CurrentGuestCard.Image2 = pictureBox4.Image as Bitmap;
            button6.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Flag = true;
            pictureBox1.Image = null;
            sc.ForeignId(Handle.ToInt32());
            //SplitImage(bitmap);

            Form2 form2 = new Form2(bitmap);
            form2.ShowDialog();
            pictureBox1.Image = form2.SelectedImage;
            CurrentGuestCard.Image1 = pictureBox1.Image as Bitmap;

            button5.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Flag = true;
            pictureBox4.Image = null;
            sc.ForeignId(Handle.ToInt32());
            //SplitImage(bitmap);

            Form2 form2 = new Form2(bitmap);
            form2.ShowDialog();
            pictureBox4.Image = form2.SelectedImage;
            CurrentGuestCard.Image2 = pictureBox4.Image as Bitmap;
            button6.Visible = false;
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            ApiService apiService = new ApiService();

            picture1 = (Bitmap)pictureBox1.Image;
            System.IO.MemoryStream ms1 = new MemoryStream();
            picture1.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] byteImage1 = ms1.ToArray();
            CurrentGuestCard.SigBase64_Img1 = Convert.ToBase64String(byteImage1);

            picture2 = (Bitmap)pictureBox4.Image;
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
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (BackToDashBoard1 != null)
            {
                BackToDashBoard1(this, new EventArgs());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ForeginCTRL_Paint(object sender, PaintEventArgs e)
        {
            label4.Text = CurrentGuestCard.GuestName;
        }
    }
}
