using CaratRedFi_800RLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaratRedFi_800RLibrary
{
    public class ScannerConnection
    {
        public AxFiScnLib.AxFiScn axFiScn1 { get; set; }

        private ForeignId foreignId;
        private IndianPassport indianPassport;
        private LocalId localId;

        public ScannerConnection()
        {
            foreignId = new ForeignId();
            indianPassport = new IndianPassport();
            localId = new LocalId();
            axFiScn1 = new AxFiScnLib.AxFiScn();
            axFiScn1.CreateControl();

        }

        public void ForeignId(int handler)
        {
            int status;
            int ErrorCode;

            axFiScn1.ScanTo = foreignId.ScanTo;
            axFiScn1.PixelType = foreignId.PixelType;
            axFiScn1.FileType = foreignId.FileType;
            axFiScn1.AutoBoarderDetection = foreignId.AutoBoarderDetection;
            axFiScn1.ShowSourceUI = foreignId.ShowSourceUI;
            axFiScn1.PaperSupply = indianPassport.PaperSupply;
            axFiScn1.CompressionType = foreignId.CompressionType;
            axFiScn1.Rotation = foreignId.Rotation;
            axFiScn1.OpenScanner2(handler);

            status = axFiScn1.StartScan(handler);
            if (status == -1)
            {
                ErrorCode = axFiScn1.ErrorCode;
            }
            axFiScn1.CloseScanner(handler);
        }

        public void LocalId(int handler)
        {
            int status;
            int ErrorCode;

            axFiScn1.OpenScanner2(handler);
            axFiScn1.FileType = localId.FileType;
            axFiScn1.ScanTo = localId.ScanTo;
            axFiScn1.PixelType = localId.PixelType;
            axFiScn1.PaperSupply = localId.PaperSupply;
            axFiScn1.AutoBoarderDetection = localId.AutoBoarderDetection;
            axFiScn1.CompressionType = localId.CompressionType;
            axFiScn1.ShowSourceUI = localId.ShowSourceUI;
            axFiScn1.Rotation = localId.Rotation;

            status = axFiScn1.StartScan(handler);
            if (status == -1)
            {
                ErrorCode = axFiScn1.ErrorCode;
            }
            axFiScn1.CloseScanner(handler);
        }

        public void IndianPassport(int handler)
        {
            int status;
            int ErrorCode;

            axFiScn1.OpenScanner2(handler);
            axFiScn1.ScanTo = indianPassport.ScanTo;
            axFiScn1.PixelType = indianPassport.PixelType;
            axFiScn1.FileType = indianPassport.FileType;
            axFiScn1.AutoBoarderDetection = indianPassport.AutoBoarderDetection;
            axFiScn1.ShowSourceUI = indianPassport.ShowSourceUI;
            axFiScn1.PaperSupply = indianPassport.PaperSupply;
            axFiScn1.CompressionType = indianPassport.CompressionType;
            axFiScn1.Rotation = indianPassport.Rotation;

            status = axFiScn1.StartScan(handler);
            if (status == -1)
            {
                ErrorCode = axFiScn1.ErrorCode;
            }
            axFiScn1.CloseScanner(handler);
        }
    }
}
