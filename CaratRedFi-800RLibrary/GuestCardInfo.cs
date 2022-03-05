using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaratRedFi800RLibrary
{
    public class GuestCardInfo
    {
        public String SigBase64_Img1 { get; set; }
        public String SigBase64_Img2 { get; set; }
        public Bitmap Image1 { get; set; }
        public Bitmap Image2 { get; set; }
        public String GuestNumber { get; set; }
        public String GuestName { get; set; }
        public bool Submitted { get; set; }
        public String SelectedCard { get; set; }
    }
}
