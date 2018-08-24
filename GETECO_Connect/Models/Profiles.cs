using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETECO_Connect.Models
{
    public class Profiles
    {
        public List<Profil> Profil;
    }
    public class Profil
    {
        public int Id { get; set; }
        public int Typ { get; set; }
        public int Id_Person { get; set; }
        public int Id_Stelle { get; set; }
        public string Topoinex_Code { get; set; }
        public string Topoinex_Profilwert { get; set; }
        public string StatusDate { get; set; }
        public string StatusProfil { get; set; }
        public string topoinex_profilbild { get; set; }
        public string BewertetePerson { get; set; }
        public string Topoinex_profilwert_fremd { get; set; }
        public string Topoinex_profilbild_fremd { get; set; }

    }
}
