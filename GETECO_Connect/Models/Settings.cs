using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETECO_Connect.Models
{


    public class settings
    {
        public List<SData> Settings { get; set; }
    }
    public class SData
    {
        public string id { get; set; }
        public string username { get; set; }
        public string vorname { get; set; }
        public string name { get; set; }
        public string id_person { get; set; }
        public string is_master { get; set; }
        public string is_user { get; set; }
        public string picture { get; set; }
        public string session { get; set; }
    }
    


}
