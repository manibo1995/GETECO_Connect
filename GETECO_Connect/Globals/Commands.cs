using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETECO_Connect.Globals
{
    public static class Commands
    {
        //here is space for helping Methods for constructing the Command-Urls u need to communicate with the server.
        //public static string login = Standards.CmdUrl + "login&pw=goethe&email=janik.prinz@geteco.de"+Standards.FormatJson;
        public static string getFeed(string single_id)
        {
            var temp = App.Database.GetLocalUser(1);
            return Standards.ApiUrl + "secureid=" + Globals.UserData.SecureID + "&userid=" + temp.Zusatzinfo + "&cmd=list_feeds&single_id="+single_id+"&format=json";
        }
        public static string getAddUserString(string username,string vorname,string nachname, string email,string phone,string geschlecht, string passwort)
        {
            return Globals.Standards.ApiUrl + "secureid=" + Globals.UserData.SecureID + "&userid=-1&cmd=adduser&username=" + username + "&vorname=" + vorname + "&nachname=" + nachname + "&email=" + email + "&phone=" + phone + "&geschlecht=" + geschlecht + "&passwort=" + passwort + Globals.Standards.FormatJson;
        }
        public static string getAddPersonString(string PersonName, string Email, string Gruppe, string Hinweis, string geschlecht)
        {
            var temp = App.Database.GetLocalUser(1);
            return Standards.ApiUrl + "secureid=" + Globals.UserData.SecureID + "&userid=" + temp.Zusatzinfo + "&cmd=add_person&name=" + PersonName + "&email=" + Email + "&gruppe=" + Gruppe + "&hinweis=" + Hinweis + "&profildownload=0&geschlecht="+geschlecht+"&format=json";
        }
        public static string getLoginString(string username, string password)
        {
            return Standards.CmdUrl + "login&pw="+password+"&email="+username+"" + Standards.FormatJson;
        }
        public static string getSettingsString()
        {
            var temp = App.Database.GetLocalUser(1);
            return Standards.ApiUrl + "secureid=" + Globals.UserData.SecureID + "&userid=" + temp.Zusatzinfo + "&cmd=settings" + Globals.Standards.FormatJson;
        }
        public static string getCmdString()
        {
            var temp = App.Database.GetLocalUser(1);
            return Standards.ApiUrl + "secureid=" + Globals.UserData.SecureID + "&userid=" + temp.Zusatzinfo+"&cmd=";
        }
        public static string getConnectString(string _foreinuserid,int _person_nr,string _profileid)
        {
            var temp = App.Database.GetLocalUser(1);
            return Standards.ApiUrl + "secureid=" + Globals.UserData.SecureID + "&userid=" + temp.Zusatzinfo + "&cmd=connect&foreinuserid=" + _foreinuserid + "&person_nr=" + _person_nr + "&profileid=" + _profileid+"&format=json";
        }
        public static string getaddBewerterString(int profileid)
        {
            var temp = App.Database.GetLocalUser(1);
            //Hier nicht die USer-Id sondern die person_id
            var owner=App.Database.GetOwner(1);
            return Standards.ApiUrl + "secureid=" + Globals.UserData.SecureID + "&userid=" + temp.Zusatzinfo + "&cmd=add_bewerter&profilid="+profileid+"&person="+owner.ownId+"&format=json";
        }
        public static string getAddProfileString(int persId)
        {
            var temp = App.Database.GetLocalUser(1);
            return Standards.ApiUrl + "secureid=" + Globals.UserData.SecureID + "&userid=" + temp.Zusatzinfo + "&cmd=add_profil&profiltyp=2&person=" + persId + "&aufgabe=0&format=json";
        }
        public static string getSetRatingString(int profilenumber, ObservableCollection<DataBase.Models.Rating> rating)
        {
            string wert = "";
            var temp = App.Database.GetLocalUser(1);
            var owner = App.Database.GetOwner(1);
            foreach (var item in rating)
            {
                wert = wert + item.Value + "_";
            }
            wert = wert.Substring(0, wert.Length - 1);
            return Standards.ApiUrl + "secureid=" + Globals.UserData.SecureID + "&userid=" + temp.Zusatzinfo + "&cmd=set_bewertung&profilid="+profilenumber+"&person="+owner.ownId+"&wert="+wert+"&format=json";
        }

        public static string getGetProfilText(DataBase.Models.Profile Profile,int isFremd)
        {
            var temp = App.Database.GetLocalUser(1);
            return Standards.ApiUrl + "secureid=" + Globals.UserData.SecureID + "&userid=" + temp.Zusatzinfo + "&cmd=get_profiltext&profilid="+ Profile.Id+"&fremdwert="+isFremd.ToString()+"&format=json";
        }

        public static string getForeignProfilesForOwner()
        {
            var temp = App.Database.GetLocalUser(1);
            return Standards.ApiUrl + "secureid=" + Globals.UserData.SecureID + "&userid=" + temp.Zusatzinfo + "&cmd=list_foreign_profile & single_id =" + temp.Id + "&format=json";
        }
        public static string getListProfilesString(int? single_id)
        {
            var temp=App.Database.GetLocalUser(1);
            return Standards.ApiUrl + "secureid=" + Globals.UserData.SecureID + "&userid=" + temp.Zusatzinfo + "&cmd=list_profile&single_id="+single_id+"&format=json";
        }
        public static string getListPersonsString(int? single_id)
        {
            var temp = App.Database.GetLocalUser(1);
			return Standards.ApiUrl + "secureid=" + Globals.UserData.SecureID + "&userid=" + temp.Zusatzinfo + "&cmd=list_personen&suche=&single_id="+single_id+"&format=json";
        }

    }
}
