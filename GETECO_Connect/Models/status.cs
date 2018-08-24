using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETECO_Connect.Models
{
    public class status
    {
        public List<LData> Status { get; set; }
    }
    public class LData
    {
        public string id { get; set; }
        public string text { get; set; }
        public string session { get; set; }
        public string zusatzinfo { get; set; }
    }
}
