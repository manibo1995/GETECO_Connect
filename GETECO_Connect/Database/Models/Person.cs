using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETECO_Connect.DataBase.Models
{
    public class Person
    {
        [PrimaryKey,AutoIncrement]
        public int InternalId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sprache { get; set; }
        public int Id_gruppen { get; set; }
        public string Hinweise { get; set; }
        public string Profildownload { get; set; }
        public string Picture { get; set; }
        public int id_ich { get; set; }
        public string email { get; set; }
        public string geschlecht { get; set; }

    }
}
