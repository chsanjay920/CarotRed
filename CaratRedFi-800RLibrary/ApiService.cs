using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CaratRedFi800RLibrary
{
    public class ApiService
    {
        public async Task<AutoCompleteResponse> GetArrivalInfoByConfirmationNumber(string confirmation_number)
        {
            var url = String.Format(AppConstants.autocompleturl, ConfigurationManager.AppSettings["Domain_Name"]);
            String body = JsonConvert.SerializeObject(new AutoCompleteInfo() { company = "HICC-01", confirmation_number = confirmation_number });
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Content = new StringContent(body, Encoding.UTF8, "application/json"),
            };

            HttpResponseMessage response = await client.SendAsync(request);  // Blocking call!
            if (response.IsSuccessStatusCode)
            {

                String jsonResult = response.Content.ReadAsStringAsync().Result;
                AutoCompleteResponse autoCompleteResponse = JsonConvert.DeserializeObject<AutoCompleteResponse>(jsonResult);
                return autoCompleteResponse;
            }
            return null;
        }

        public async Task<string> UploadInfoToFile(GuestCardInfo guestCardInfo)
        {
            var url = String.Format(AppConstants.url, ConfigurationManager.AppSettings["Domain_Name"]);
            String body = JsonConvert.SerializeObject(new FileUploadRequest()
            {
                reservation_number = int.Parse(guestCardInfo.GuestNumber),
                image_1 = guestCardInfo.SigBase64_Img1,
                image_2 = guestCardInfo.SigBase64_Img2,
                guest_name=guestCardInfo.GuestName
            });
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Content = new StringContent(body, Encoding.UTF8, "application/json"),
            };

            HttpResponseMessage response = await client.SendAsync(request);  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                String jsonResult = await response.Content.ReadAsStringAsync();
                FileUploadRequest fileUploadRequest = JsonConvert.DeserializeObject<FileUploadRequest>(jsonResult);
                return AppConstants.FileUploadSuccessMsg;
            }
            return AppConstants.FileUploadFailMsg;
        }
    }
}
