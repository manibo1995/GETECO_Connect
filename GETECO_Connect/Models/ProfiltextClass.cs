using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETECO_Connect.Models
{
    public class ProfiltextClass
    {
        public List<Innerdata> Profiltext { get; set; }
    }
    
    public class Innerdata
    {
        public string text { get; set; }
    }
    
}
