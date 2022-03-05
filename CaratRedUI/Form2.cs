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
    public partial class Form2 : Form
    {
        public Image SelectedImage { get; set; }

        public Image picture1 { get; set; }
        public Image picture2 { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Bitmap image)
        {
            InitializeComponent();
            SplitImage(image);
        }
        public void SplitImage(Bitmap bmp)
        {
            if (bmp != null)
            {
                Bitmap image = bmp;
                Rectangle rect = new Rectangle(0, 0, image.Width, image.Height / 2);
                Bitmap firstHalf = image.Clone(rect, image.PixelFormat);
                picture1 = firstHalf;
                pictureBox1.Image = firstHalf;
                rect = new Rectangle(0, image.Height / 2, image.Width, image.Height / 2);
                Bitmap secondHalf = image.Clone(rect, image.PixelFormat);
                picture2 = secondHalf;
                pictureBox2.Image = secondHalf;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SelectedImage = picture1;
            panel2.BackColor = Color.Transparent;
            panel1.BackColor = Color.LightSeaGreen;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SelectedImage = picture2;
            panel1.BackColor = Color.Transparent;
            panel2.BackColor = Color.LightSeaGreen;
        }
    }
}
