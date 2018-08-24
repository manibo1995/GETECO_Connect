using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETECO_Connect.Models
{
    class NewProfile
    {
        public List<AddedProfile> status;
    }
    public class AddedProfile
    {
        public int id { get; set; }
        public string text { get; set; }
        public string session { get; set; }
        public string zusatzinfo { get; set; }
    }
}
