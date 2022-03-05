using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaratRedFi800RLibrary
{
    public static class AppConstants
    {
        public const string ConfigSaveMsg = "Settings Updated Success";
        public const string FileUploadSuccessMsg = "FileUploaded Success";
        public const string FileUploadFailMsg = "FileUploaded Failed";
        public const string InvalideConfirNumber = "confirmation is invalid";
        public const string EmptyInput = "input cannot be empty";
        public const string url = "http://{0}:8001/api/method/version2_app.passport_scanner.doctype.dropbox.dropbox.create_doc_using_base_files";
        public const string autocompleturl = "http://{0}:8001/api/method/version2_app.arrivals.doctype.arrival_information.arrival_information.autocomplete_arrival_info";
    }
}
