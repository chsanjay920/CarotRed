using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaratRedFi800RLibrary
{
    public class FileUploadRequest
    {
        public int reservation_number { get; set; }
        public string image_1 { get; set; }
        public string image_2 { get; set; }

        public string guest_name { get; set; }
    }

}
