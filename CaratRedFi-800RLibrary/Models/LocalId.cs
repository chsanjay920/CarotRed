using CaratRedFi800RLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaratRedFi_800RLibrary.Models
{
    public class LocalId
    {
        public short CompressionType { get; set; }
        public short ScanTo { get; set; }
        public short PixelType { get; set; }
        public short PaperSupply { get; set; }
        public bool AutoBoarderDetection { get; set; }
        public bool ShowSourceUI { get; set; }
        public short FileType { get; set; }
        public short Rotation { get; set; }

        public LocalId()
        {
            this.ScanTo = ModuleScan.TYPE_RAW_IMAGE_HANDLE;
            this.PixelType = 3;
            this.PaperSupply = ModuleScan.ADF_DUPLEX;
            this.AutoBoarderDetection = true;
            this.ShowSourceUI = false;
            this.FileType = ModuleScan.FILE_BMP;
            this.CompressionType = ModuleScan.COMP_JPEG;
            this.Rotation = ModuleScan.RT_AUTO;
        }
    }
}
