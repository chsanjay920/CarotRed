//****************************************************************************
//
//   Scanner Control SDK Test Program
//
//   Copyright PFU Limited 2009-2021
//
//****************************************************************************
using System;
using System.Text;
using System.Runtime.InteropServices;

namespace CaratRedFi800RLibrary
{
    /// <summary>
    /// Summary description for ModuleScan.
    /// </summary>
    public class ModuleScan
    {
        public ModuleScan()
        {
        }

        //Win32API define
        #region using windows method
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileInt(
            string lpApplicationName,
            string lpKeyName,
            int nDefault,
            string lpFileName);

        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(
            string lpApplicationName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFileName);


        [DllImport("kernel32")]
        public static extern int WritePrivateProfileString(
            string lpApplicationName,
            string lpKeyName,
            string lpString,
            string lpFileName);

        [DllImport("kernel32")]
        public static extern IntPtr GlobalLock(IntPtr hMem);

        [DllImport("kernel32")]
        public static extern bool GlobalUnlock(IntPtr hMem);

        [DllImport("kernel32")]
        public static extern IntPtr GlobalFree(IntPtr hMem);

        #endregion

        //Windows define
        public const int MAX_PATH = 260;

        //ScanTo
        public const int TYPE_FILE = 0;                         //File
        public const int TYPE_DIB_HANDLE = 1;                   //DIB handle
        public const int TYPE_RAW_IMAGE_HANDLE = 2;             //Memory

        //FileType
        public const int FILE_BMP = 0;                          //Windows Bitmap
        public const int FILE_TIF = 1;                          //TIFF
        public const int FILE_MULTIF = 2;                       //Multiimmage TIFF
        public const int FILE_JPEG = 3;                         //JPEG
        public const int FILE_PDF = 4;                          //PDF
        public const int FILE_MULPDF = 5;                       //Multiimage PDF
        public const int FILE_MULTIIMAGE_OUTPUT = 6;            //Multi Image Output
        public const int FILE_AUTO_COLOR_DETECTION = 7;         //Auto Color Detection

        //CompressionType
        public const int NO_COMP = 0;                           //No compression
        public const int COMP_MH = 1;                           //CCITT G3(1D)
        public const int COMP_MR2 = 2;                          //CCITT G3(2D) Kfactor = 2
        public const int COMP_MR4 = 3;                          //CCITT G3(2D) Kfactor = 4
        public const int COMP_MMR = 4;                          //CCITT G4
        public const int COMP_JPEG = 5;                         //JPEG
        public const int COMP_OLDJPEG = 6;                      //OLD JPEG

        //PixelType
        public const int PIXEL_BLACK_WHITE = 0;                 //Monochrome
        public const int PIXEL_GRAYSCALE = 1;                   //Grayscale
        public const int PIXEL_RGB = 2;                         //RGB

        //Resolution
        public const int RS_200 = 0;                            //200dpi
        public const int RS_240 = 1;                            //240dpi
        public const int RS_300 = 2;                            //300dpi
        public const int RS_400 = 3;                            //400dpi
        public const int RS_500 = 4;                            //500dpi
        public const int RS_600 = 5;                            //600dpi
        public const int RS_700 = 6;                            //700dpi
        public const int RS_800 = 7;                            //800dpi
        public const int RS_1200 = 9;                           //1200dpi
        public const int RS_CUSTM = 99;                         //Custom

        //Background
        public const int MODE_OFF = 0;                          //Invalid
        public const int MODE_ON = 1;                           //Effective
        public const int MODE_AUTO = 2;                         //Automatic

        //Outline
        public const int NONE = 0;                              //Nothing
        public const int OUTLINE_EMPHASIS_LOW = 1;              //Emphasis low
        public const int OUTLINE_EMPHASIS_MIDIUM = 2;           //Emphasis midium
        public const int OUTLINE_EMPHASIS_HIGH = 3;             //Emphasis high
        public const int OUTLINE_SMOOTH = 4;                    //Smooth
        public const int OUTLINE_EDGE_EXTRACT = 5;              //Edge extract

        //Halftone
        public const int DITHER_PATTERN0 = 1;                   //deep photograph picture
        public const int DITHER_PATTERN1 = 2;                   //mixture deep character and photograph
        public const int DITHER_PATTERN2 = 3;                   //light photograph picture
        public const int DITHER_PATTERN3 = 4;                   //mixture light character and phtograph
        public const int DITHER_PATTERN_FILE = 5;               //halftone pattern file
        public const int DITHER_ERROR_DIFFUSION = 6;            //error diffusion method

        //Gamma
        public const int GAMMA_SOFT = 1;                        //Soft
        public const int GAMMA_HARD = 2;                        //Sharp
        public const int GAMMA_PATTERN_FILE = 3;                //Gamma pattern file
        public const int GAMMA_CUSTOM = 4;                      //custom

        //PaperSupply
        public const int FLATBED = 0;                           //Flatbed
        public const int ADF = 1;                               //ADF
        public const int ADF_DUPLEX = 2;                        //ADF(duplex)
        public const int ADF_BACKSIDE = 3;                      //ADF(back side)
        public const int ADF_A3CS = 4;                          //A3 CarrierSheet(ADFduplex)
        public const int ADF_DLCS = 5;                          //Double Letter CarrierSheet(ADFduplex)
        public const int ADF_B4CS = 6;                          //B4 CarrierSheet(ADFduplex)
        public const int ADF_CS = 7;                            //CarrierSheet front and back image separately(ADFduplex)

        //PaperSize
        public const int PSIZE_A3 = 0;                          //A3
        public const int PSIZE_A4 = 1;                          //A4
        public const int PSIZE_A5 = 2;                          //A5
        public const int PSIZE_A6 = 3;                          //A6
        public const int PSIZE_B4 = 4;                          //B4(JIS)
        public const int PSIZE_B5 = 5;                          //B5(JIS)
        public const int PSIZE_B6 = 6;                          //B6(JIS)
        public const int PSIZE_LETTER = 7;                      //letter
        public const int PSIZE_LEGAL = 8;                       //legal
        public const int PSIZE_EXECUTIVE = 9;                   //exective
        public const int PSIZE_DOUBLELETTER = 10;               //double letter
        public const int PSIZE_POSTCARD = 11;                   //post card
        public const int PSIZE_PHOTO = 12;                      //photograph
        public const int PSIZE_CARD = 13;                       //card
        public const int PSIZE_C4 = 15;                         //C4
        public const int PSIZE_C5 = 16;                         //C5
        public const int PSIZE_C6 = 17;                         //C6
        public const int PSIZE_DATA_CUSTOM = 99;               //custom
        public const int PSIZE_INDEX_CUSTOM = 14;              //index of List
        public const int PSIZE_ISO_B4 = 18;                    //B4(ISO)
        public const int PSIZE_ISO_B5 = 19;                    //B5(ISO)
        public const int PSIZE_ISO_B6 = 20;                    //B6(ISO)
        public const int PSIZE_85x170 = 21;                    //8.5 x 17inch
        public const int PSIZE_85x340 = 22;                    //8.5 x 34inch
        public const int PSIZE_85x1063 = 23;                    //8.5 x 106.3inch
        public const int PSIZE_85x1250 = 24;                    //8.5 x 125inch
        public const int PSIZE_85x1600 = 25;                    //8.5 x 160inch
        public const int PSIZE_85x2150 = 26;                    //8.5 x 215inch
        public const int PSIZE_85x2200 = 27;                    //8.5 x 220inch
        public const int PSIZE_117x170 = 28;                    //11.7 x 17inch
        public const int PSIZE_117x340 = 29;                    //11.7 x 34inch
        public const int PSIZE_120x170 = 30;                    //12 x 17inch
        public const int PSIZE_120x340 = 31;                    //12 x 34inch
        public const int PSIZE_120x1250 = 32;                   //12 x 125inch
        public const int PSIZE_MAX = 33;                   //MaxSize
        public const int PSIZE_120x1063 = 34;                   //12 x 106.3inch
        public const int PSIZE_120x1600 = 35;                   //12 x 160inch
        public const int PSIZE_120x2150 = 36;                   //12 x 215inch
        public const int PSIZE_120x2200 = 37;                   //12 x 220inch

        //JobControl
        public const int INCLUDE_AND_CONTINUE = 1;              //A special paper/Patch Code paper is read and it continues
        public const int INCLUDE_AND_STOP = 2;                  //A special paper/Patch Code paper is read and stopped
        public const int EXCLUDE_AND_CONTINUE = 3;              //A special paper/Patch Code paper is skipped and it continues
        public const int EXCLUDE_AND_STOP = 4;                  //A special paper/Patch Code paper is skipped and stopped

        //OvweWrite
        public const int OW_OFF = 0;                            //It does not overwrite
        public const int OW_ON = 1;                             //It overwrites
        public const int OW_CONFIRM = 2;                        //A check message is displayed

        //Orientation
        public const int PORTRAIT = 0;                          //The direction of length
        public const int LANDSCAPE = 1;                         //Transverse direction

        //Rotation
        public const int RT_NONE = 0;                           //It does not rotate
        public const int RT_R90 = 1;                            //90 right rotation
        public const int RT_R180 = 2;                           //180-degree rotation
        public const int RT_R270 = 3;                           //270 right rotation
        public const int RT_AUTO = 4;                           //auto

        //AutoSeparation
        public const int AS_OFF = 0;                            //Automatic picture domain separation processing is not performed
        public const int AS_ON = 1;                             //Automatic picture domain separation processing is performed

        //SEE
        public const int SEE_OFF = 0;                           //Selection emphasis processing is not performed
        public const int SEE_ON = 1;                            //Selection emphasis processing is performed

        //CarrierSheetClippingMode
        public const int CSCM_CONTENT = 0;                      //Content
        public const int CSCM_EDGE = 1;                         //Edge
        public const int CSCM_DRIVERSETTING = 2;                //Driver Setting

        //Report
        public const int RP_OFF = 0;                            //A result is not reported
        public const int RP_DISPLAY = 1;                        //A result displays on a screen
        public const int RP_FILE = 2;                           //A result outputs to a file
        public const int RP_DISPLAY_FILE = 3;                   //A result displays on a screen and outputs to a file

        //JpegQuarity
        public const int COMP_JPEG1 = 0;                        //Jpeg compression ratio 1
        public const int COMP_JPEG2 = 1;                        //Jpeg compression ratio 2
        public const int COMP_JPEG3 = 2;                        //Jpeg compression ratio 3
        public const int COMP_JPEG4 = 3;                        //Jpeg compression ratio 4
        public const int COMP_JPEG5 = 4;                        //Jpeg compression ratio 5
        public const int COMP_JPEG6 = 5;                        //Jpeg compression ratio 6
        public const int COMP_JPEG7 = 6;                        //Jpeg compression ratio 7

        //ScanMode
        public const int SM_NORMAL = 0;                         //Normal Scan
        public const int SM_ASSIST = 0;                         //Assist Scan

        //Filter
        public const int FILTER_GREEN = 0;                      //Green
        public const int FILTER_RED = 1;                        //Red
        public const int FILTER_BLUE = 2;                       //Blue
        public const int FILTER_OFF = 3;                        //No color
        public const int FILTER_WHITE = 4;                      //White

        //ThreshholdCurve
        public const int TH_CURVE1 = 0;                         //light
        public const int TH_CURVE2 = 1;                         //little light
        public const int TH_CURVE3 = 2;                         //usually1
        public const int TH_CURVE4 = 3;                         //usually2
        public const int TH_CURVE5 = 4;                         //little deep
        public const int TH_CURVE6 = 5;                         //deep
        public const int TH_CURVE7 = 6;                         //usually
        public const int TH_CURVE8 = 7;                         //deepest

        //GammaCurve
        public const int GM_CHARREC1 = 0;                       //For character recognition1
        public const int GM_CHARREC2 = 1;                       //For character recognition2
        public const int GM_IMAGE1 = 2;                         //For deep picture
        public const int GM_IMAGE2 = 3;                         //equal division

        //OverScan
        public const int OVERSCAN_OFF = 0;                      //OverScan is not performed
        public const int OVERSCAN_ON = 1;                      //OverScan is performed

        //Unit
        public const int UNIT_INCHES = 0;                       //Inches
        public const int UNIT_CENTIMETERS = 1;                  //Centimeters
        public const int UNIT_PIXELS = 2;                       //Pixels

        public const double INCH254 = 2.54;

        //Sharpness
        public const int SH_NONE = 0;                           //None

        //PunchHoleRemoval
        public const int PHR_DO_NOT_REMOVE = 0;                 //Do not remove

        //PunchHoleRemovalMode
        public const int PHRM_STANDARD = 0;                     //Standard

        //EndorserFont
        public const int EDF_HORIZONTAL = 0;                    //Horizontal

        //EndorserDialog
        public const int EDD_OFF = 0;                           //OFF

        //JobControlMode
        public const int JCM_SPECIAL_DOCUMENT = 0;              //Special Document

        //FrontBackMergingLocation
        public const int FBML_RIGHT = 3;                        //Right

        //FrontBackMergingRotation
        public const int FBMR_NONE = 0;                         //It does not rotate
        public const int FBMR_R180 = 2;                         //180-degree rotation
        public const int FBMR_INDEX_R180 = 1;                   //index of list

        //FrontBackMergingTarget
        public const int FBMT_ALL = 0;                          //All

        //FrontBackMergingTargetMode
        public const int FBMTM_CUSTOM = 1;                      //Custom
        public const int FBMTM_CARDSIZE = 2;                    //CardSize
        public const int FBMTM_INDEX_CUSTOM = 0;                //index of list(Custom)
        public const int FBMTM_INDEX_CARDSIZE = 1;              //index of list(CardSize)

        //FrontBackMergingTargetSize
        public const double FBMTG_DEFAULT = 1;                  //1 inch

        //SelectOutputSize
        public const int SOS_MARGIN = 0;                        //Margin

        //CharacterExtractionMethod
        public const int CEM_REVERSEDTYPEEXTRACTION = 1;        //ReversedTypeExtraction
        public const int CEM_HALFTONEREMOVAL = 2;               //HalftoneRemoval
        public const int CEM_STAMPREMOVAL = 4;                  //StampRemoval

        //FrontBackDetection
        public const int FBD_NONE = 0;                          //None

        //PaperProtection
        public const int PP_DRIVERSETTING = 3;                  //Driver Setting

        //AutomaticRotateMode
        public const int ARM_STANDARD = 0;                      //Standard

        //ColorReproduction
        public const int CR_CONTRAST = 0;                       //Contrast
        public const int CR_HUE = 1;                            //Hue

        //BarcodeDirection
        public const int BD_HORIZONTAL_VERTICAL = 2;            //Horizontal & Vertical

        //BarcodeType
        public const int BA_UNDEFINED = 0;                      //Undefined
        public const int BA_EAN8 = 1;                       //EAN 8
        public const int BA_EAN13 = 2;                       //EAN 13
        public const int BA_CODE3OF9 = 4;                       //Code 3 of 9
        public const int BA_CODE128 = 8;                       //Code 128
        public const int BA_ITF = 16;                      //ITF
        public const int BA_UPCA = 32;                      //UPC-A
        public const int BA_CODABAR = 64;                      //Codabar
        public const int BA_PDF417 = 128;                     //PDF417
        public const int BA_QRCODE = 256;                     //QR Code
        public const int BA_DATAMATRIX = 512;                   //Data Matrix
        public const int BA_AZTECCODE = 1024;                   //Aztec Code

        public const String BA_STR_UNDEFINED = "Undefined";     // Undefined
        public const String BA_STR_EAN8 = "EAN 8";          // EAN 8
        public const String BA_STR_EAN13 = "EAN 13";         // EAN 13
        public const String BA_STR_CODE3OF9 = "Code 3 of 9";    // Code 3 of 9
        public const String BA_STR_CODE128 = "Code 128";       // Code 128
        public const String BA_STR_ITF = "ITF";            // ITF
        public const String BA_STR_UPCA = "UPC-A";          // UPC-A
        public const String BA_STR_CODABAR = "Codabar";        // Codabar
        public const String BA_STR_PDF417 = "PDF417";         // PDF417
        public const String BA_STR_QRCODE = "QR Code";        // QR Code
        public const String BA_STR_DATAMATRIX = "Data Matrix";  // Data Matrix
        public const String BA_STR_AZTECCODE = "Aztec Code";    // Aztec Code

        //BarcodeRotation
        public const int BA_RT_0 = 0;
        public const int BA_RT_90 = 1;
        public const int BA_RT_180 = 2;
        public const int BA_RT_270 = 3;
        public const int BA_RT_X = 4;

        public const String BA_RT_STR_0 = "0";
        public const String BA_RT_STR_90 = "90";
        public const String BA_RT_STR_180 = "180";
        public const String BA_RT_STR_270 = "270";
        public const String BA_RT_STR_X = "Uncertainty";

        //PatchCodeDirection
        public const int PD_VERTICAL = 1;                       //Vertical

        //PatchCodeType
        public const int PA_PATCH1 = 1;                       //Patch 1
        public const int PA_PATCH2 = 2;                       //Patch 2
        public const int PA_PATCH3 = 4;                       //Patch 3
        public const int PA_PATCH4 = 8;                       //Patch 4
        public const int PA_PATCH6 = 32;                      //Patch 6
        public const int PA_PATCHT = 256;                     //Patch T

        public const String PA_STR_PATCH1 = "Patch 1";         //Patch 1
        public const String PA_STR_PATCH2 = "Patch 2";         //Patch 2
        public const String PA_STR_PATCH3 = "Patch 3";         //Patch 3
        public const String PA_STR_PATCH4 = "Patch 4";         //Patch 4
        public const String PA_STR_PATCH6 = "Patch 6";         //Patch 6
        public const String PA_STR_PATCHT = "Patch T";         //Patch T

        //EdgeFiller
        public const int EF_OFF = 0;                            //Off

        //MultiStreamMode
        public const int MSM_OFF = 0;                           //OFF

        //MultiStreamFileNameMode
        public const int MSFNM_OFF = 0;                         //OFF

        //MultiStreamDefaultValueMode
        public const int MSDVM_OFF = 0;                         //OFF

        //AutoProfile
        public const int AP_DISABLED = 0;                       //Disabled
        public const int AP_ENABLED = 1;                        //Enabled

        //AIQCResult
        public const String AR_BADIMAGE = "Bad Image";
        public const String AR_NOERROR = "No Error";

        //MultiFeedResult
        public const String MR_DETECT = "Detection";
        public const String MR_NOT_DETECT = "Non-detection";

        //error code
        public const int RC_NOT_DS_FJTWAIN = 2;                 //It is not TWAIN driver
        public const int RC_FAILURE = -1;                       //error
        public const int RC_SUCCESS = 0;                        //success
        public const int RC_CANCEL = 1;                         //cancel

        //other
        public static int intOrientation;                       //Orientation
        public static int intReport;                            //Report
        public static string strReportFile;                     //ReportFile
        public static string strOutputResult;                   //OutputResult
        public static int intCarrierSheetClippingMode;          //CarrierSheetClippingMode

        public static bool blnIsExistsFB;                       //IsExistFB
        public static string strImageScanner;                   //ImageScanner
        public static int intPageCount;                         //PageCount
        public static int intErrorCode;                         //ErrorCode
        public static string strTwainDS;                        //TwainDS

        public static bool blnFjtwn;                            //Be TWAIN Driver or not?
        public static bool blnOpenScanner;                      //It is open scanner or not?
        public static string strFilePath;                       //File path
        public static string strDirPath;                        //Directory path

        public static bool bInitialFileRead = false;            //InitialFileRead() Flag
        public static int PreviousUnit;                         //The state before change of Unit ComboBox
        public static int PreviousReso;                         //The state before change of Resolution ComboBoX

        public static bool bCancelScan = false;                 //CancelScan Flag

        public static int[] intProfileNum = new int[1];         //ProfileNumber

        public const short BR_DETECTION = 1;
        public const short BR_NONDETECTION = 0;

        public const String BR_STR_DETECTION = "Detection";
        public const String BR_STR_NONDETECTION = "Non-detection";
    }
}
