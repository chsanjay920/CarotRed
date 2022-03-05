using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaratRedFi800RLibrary
{
    public class AutoCompleteResponse
    {
        public Message message { get; set; }
    }

    public class Message
    {
        public bool success { get; set; }
        public Info[] data { get; set; }
    }

    public class Info
    {
        public string name { get; set; }
        public string guest_first_name { get; set; }
        public int no_of_adults { get; set; }
        public int no_of_children { get; set; }
        public string booking_status { get; set; }
        public string virtual_checkin_status { get; set; }
        public string status { get; set; }
    }
}
