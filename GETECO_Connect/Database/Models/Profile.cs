using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GETECO_Connect.Models;
using Xamarin.Forms;

namespace GETECO_Connect.DataBase.Models
{
    public class Profile
    {
        [PrimaryKey,AutoIncrement]
        public int InternalId { get; set; }
        public int Id { get; set; }
        public int Typ { get; set; }
        public int Id_Person { get; set; }
        public int Id_Stelle { get; set; }
        public string Topoinex_Code { get; set; }
        public string Topoinex_Profilwert { get; set; }
        public string topoinex_profilbild { get; set; }
        public string StatusDate { get; set; }
        public string StatusProfil { get; set; }
        public string BewertetePerson { get; set; }
        public string AvatarPic { get; set; }
        public string Topoinex_profilwert_fremd { get; set; }
        public string Topoinex_profilbild_fremd { get; set; }
        public string ProfiltextFremd { get; set; }
        public string Profiltext { get; set; }


    }
}
