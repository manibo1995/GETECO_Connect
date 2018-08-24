using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETECO_Connect.Models
{
    public class Persons
    {
        public List<Person> Person;
    }

    public class Person
    {
        public int id { get; set; }
        public string name { get; set; }
        public string sprache { get; set; }
        public string id_gruppen { get; set; }
        public string hinweise { get; set; }
        public string profildownload { get; set; }
        public string picture { get; set; }
        public string id_ich { get; set; }
        public string email { get; set; }
        public string geschlecht { get; set; }
    }
}
