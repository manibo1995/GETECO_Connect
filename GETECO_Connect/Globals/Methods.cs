using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using GETECO_Connect;
using GETECO_Connect.DataBase.Models;

namespace GETECO_Connect.Globals
{
    public static class Methods
    {
        public static string Login(string url)
        {
            var a = Task.Run(async () =>
            {

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri( Globals.Standards.BaseUrl);

                    try
                    {
                        var json = await client.GetStringAsync(url);
                        Models.status status = JsonConvert.DeserializeObject<Models.status>(json);
                        string result = status.ToString();
                        Globals.UserData.UserID = status.Status[0].zusatzinfo;
                        if (status.Status[0].id != "0")
                        {
                            var error = status.Status[0].text;
                            return error;
                        }
                        else
                        {
                            var tempLocalUser = new DataBase.Models.localUser
                            {
                                InternalId = 1,
                                Id = status.Status[0].id,
                                Session = status.Status[0].session,
                                Text = status.Status[0].text,
                                Zusatzinfo = status.Status[0].zusatzinfo
                            };
                            App.Database.SaveLocalUser(tempLocalUser);
                            return null;
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            });
            a.Wait();
            return a.Result;
        }

        public static void CheckDB()
        {
            ObservableCollection<Person> Persons = new ObservableCollection<Person>();
            ObservableCollection<Profile> Profiles = new ObservableCollection<Profile>();
            //personen 
            var tempPersonen = App.Database.GetPersonen();
            if (tempPersonen.Count() != 0)
            {
                foreach (var item in tempPersonen)
                {
                    Persons.Add(item);
                }
            }

            //Abfrage der Prüfsumme
            //Profile
            var tempProfiles = App.Database.GetProfiles();
            if (tempProfiles.Count() != 0)
            {
                foreach (var item in tempProfiles)
                {
                    Profiles.Add(item);
                }
            }

            //Abrufen der 48 Eigenschaften
            //Rating
            var tempRating = App.Database.GetRating();
            if (tempRating.Count() != 0)
            { }
            else
            {
                List<Rating> RatingList = Globals.Methods.CreateRatingItems();
            }


        }

        public static void Settings(string url)
        {
            var a = Task.Run(async () =>
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Globals.Standards.BaseUrl);
                    try
                    {
                        var json = await client.GetStringAsync(url);
                        Models.settings Data = JsonConvert.DeserializeObject<Models.settings>(json);
                        string result = Data.ToString();
                        if (Data.Settings[0].id != "0")
                        {
                            //Fehlerbehandlung !!!
                        }
                        var tempOwner = new DataBase.Models.Owner
                        {
                            Id = Convert.ToInt32(Data.Settings[0].id),
                            Username = Data.Settings[0].username,
                            Vorname = Data.Settings[0].vorname,
                            Name = Data.Settings[0].name,
                            Id_Person = Convert.ToInt32(Data.Settings[0].id_person),
                            Is_Master = Convert.ToInt32(Data.Settings[0].is_master),
                            Is_User = Convert.ToInt32(Data.Settings[0].is_user),
                            Picture = Data.Settings[0].picture,
                            Session = Data.Settings[0].session,
                            InternalId = 1

                        };
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            App.Database.SaveOwner(tempOwner);
                            //Globals.Methods.CheckDB();
                            App.Current.MainPage = new Views.Feed();
                        });


                    }
                    catch (Exception e)
                    {
                        //TODO: Fehlermeldung ausgeben!
                    }
                }
            });
            a.Wait();
        }

     

        public static string CallService(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://4castagency.de");
                try
                {
                    var requestTask = client.GetStringAsync(url);
                    return requestTask.Result;
                }
                catch (Exception e)
                {
                    var a = e.ToString();
                    throw;
                }
            }
        }

        public static void ClearStackPanelAndNavigateFrist(Page firstPageToNavigate, INavigation navigation)
        {
            //navigation.InsertPageBefore(firstPageToNavigate, navigation.NavigationStack[1]);
            var existingPages = navigation.NavigationStack.ToList();
            for (int i = 1; i < existingPages.Count; i++)
            {
                navigation.RemovePage(existingPages[i]);
            }

            Application.Current.MainPage=new Views.Feed();

        }

        public static List<DataBase.Models.Rating> CreateRatingItems()
        {
            List<DataBase.Models.Rating> templist = new List<DataBase.Models.Rating>();
            templist.Add(
            #region Items
                new DataBase.Models.Rating
                {
                    Text = "abenteuerlustig",
                    Value = "wx1"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "aktiv",
                    Value = "wx3"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "analytisch",
                    Value = "wx4"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "anspruchsvoll",
                    Value = "wx5"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "aufrichtig",
                    Value = "wx7"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "beherrscht",
                    Value = "wx12"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "belebend",
                    Value = "wx13"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "bescheiden",
                    Value = "wx15"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "charmant",
                    Value = "wx19"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "diplomatisch",
                    Value = "wx20"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "direkt",
                    Value = "wx21"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "entschlossen",
                    Value = "wx30"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "entspannt",
                    Value = "wx31"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "formal",
                    Value = "wx35"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "freundlich",
                    Value = "wx36"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "gesprächig",
                    Value = "wx41"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "gewissenhaft",
                    Value = "wx42"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "guter Zuhörer",
                    Value = "wx44"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "herzlich",
                    Value = "wx47"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "hinterfragend",
                    Value = "wx48"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "impulsiv",
                    Value = "wx49"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "initiativ",
                    Value = "wx50"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "instinktiv",
                    Value = "wx53"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "kämpferisch",
                    Value = "wx54"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "kommunikativ",
                    Value = "wx55"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "kraftvoll",
                    Value = "wx61"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "logisch",
                    Value = "wx63"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "methodisch",
                    Value = "wx65"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "mitfühlend",
                    Value = "wx66"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "motivierend",
                    Value = "wx67"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "objektiv",
                    Value = "wx69"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "offen",
                    Value = "wx70"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "optimistisch",
                    Value = "wx71"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "präzise",
                    Value = "wx73"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "proaktiv",
                    Value = "wx74"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "problemlösend",
                    Value = "wx75"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "redegewandt",
                    Value = "wx76"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "rücksichtsvoll",
                    Value = "wx78"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "selbstsicher",
                    Value = "wx81"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "stabil",
                    Value = "wx84"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "taktvoll",
                    Value = "wx88"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "Teamspieler",
                    Value = "wx89"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "treu",
                    Value = "wx90"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "überlegt",
                    Value = "wx91"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "überzeugend",
                    Value = "wx93"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "verständnisvoll",
                    Value = "wx101"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "willensstark",
                    Value = "wx105"
                }
            );
            templist.Add(
                new DataBase.Models.Rating
                {
                    Text = "willensstark",
                    Value = "wx107"
                }
                #endregion Items
            );
            App.Database.SaveRating(templist);
            return templist;

        }
        public static string GetAvatarPicture(List<Models.DataItem> werte,string geschlecht)//Rot_Gelb_Grün_Blau
        {
            var temp = werte;
            string AvaName = "";
            var m = werte.OrderByDescending(a => a.Value).First();
            temp.Remove(m);
            string Endung = "_XX";
            if (geschlecht=="m")
            {
                Endung = "_XY";
            }

            if (m.Value == 0)
            {
                return AvaName = "neutral"+Endung;
            }
            else
            {

                switch (m.Category)
                {
                    case "Rot":
                        AvaName = m.Name;
                        m = werte.OrderByDescending(a => a.Value).First();
                        if (m.Value != 0)
                        {
                            AvaName = AvaName + "_" + m.Name;
                            temp.Remove(m);
                            m = werte.OrderByDescending(a => a.Value).First();
                            if (m.Value != 0)
                            {
                                AvaName = AvaName + "_" + m.Name;
                                temp.Remove(m);
                                m = werte.OrderByDescending(a => a.Value).First();
                                if (m.Value != 0)
                                {
                                    var a = AvaName.Split('_');//+Geschlecht
                                    AvaName = a[0] + "_" + a[1] + "_4"+Endung+".png";
                                    return AvaName;
                                }
                                else
                                {
                                    AvaName = AvaName + Endung + ".png"; //+Geschlecht
                                    return AvaName;
                                }
                            }
                            else
                            {
                                AvaName = AvaName + Endung + ".png"; //+Geschlecht
                                return AvaName;
                            }
                        }
                        else
                        {
                            AvaName = AvaName + Endung + ".png"; //+Geschlecht
                            return AvaName;
                        }
                        break;
                    case "Gelb":
                        AvaName = m.Name;
                        m = werte.OrderByDescending(a => a.Value).First();
                        if (m.Value != 0)
                        {
                            AvaName = AvaName + "_" + m.Name;
                            temp.Remove(m);
                            m = werte.OrderByDescending(a => a.Value).First();
                            if (m.Value != 0)
                            {
                                AvaName = AvaName + "_" + m.Name;
                                temp.Remove(m);
                                m = werte.OrderByDescending(a => a.Value).First();
                                if (m.Value != 0)
                                {
                                    var a = AvaName.Split('_');//+Geschlecht
                                    AvaName = a[0] + "_" + a[1] + "_4" + Endung + ".png";
                                    return AvaName;
                                }
                                else
                                {
                                    AvaName = AvaName + Endung + ".png"; //+Geschlecht
                                    return AvaName;
                                }
                            }
                            else
                            {
                                AvaName = AvaName + Endung + ".png"; //+Geschlecht
                                return AvaName;
                            }
                        }
                        else
                        {
                            AvaName = AvaName + Endung + ".png"; //+Geschlecht
                            return AvaName;
                        }
                        break;
                    case "Grün":
                        AvaName = m.Name;
                        m = werte.OrderByDescending(a => a.Value).First();
                        if (m.Value != 0)
                        {
                            AvaName = AvaName + "_" + m.Name;
                            temp.Remove(m);
                            m = werte.OrderByDescending(a => a.Value).First();
                            if (m.Value != 0)
                            {
                                AvaName = AvaName + "_" + m.Name;
                                temp.Remove(m);
                                m = werte.OrderByDescending(a => a.Value).First();
                                if (m.Value != 0)
                                {
                                    var a = AvaName.Split('_');//+Geschlecht
                                    AvaName = a[0] + "_" + a[1] + "_4" + Endung + ".png";
                                    return AvaName;
                                }
                                else
                                {
                                    AvaName = AvaName + Endung + ".png";//+Geschlecht
                                    return AvaName;
                                }
                            }
                            else
                            {
                                AvaName = AvaName + Endung + ".png"; //+Geschlecht
                                return AvaName;
                            }
                        }
                        else
                        {
                            AvaName = AvaName + Endung + ".png"; //+Geschlecht
                            return AvaName;
                        }
                        break;
                    case "Blau":
                        AvaName = m.Name;
                        m = werte.OrderByDescending(a => a.Value).First();
                        if (m.Value != 0)
                        {
                            AvaName = AvaName + "_" + m.Name;
                            temp.Remove(m);
                            m = werte.OrderByDescending(a => a.Value).First();
                            if (m.Value != 0)
                            {
                                AvaName = AvaName + "_" + m.Name;
                                temp.Remove(m);
                                m = werte.OrderByDescending(a => a.Value).First();
                                if (m.Value != 0)
                                {
                                    var a = AvaName.Split('_');//+Geschlecht
                                    AvaName = a[0] + "_" + a[1] + "_4" + Endung + ".png";
                                    return AvaName;
                                }
                                else
                                {
                                    AvaName = AvaName + Endung + ".png"; //+Geschlecht
                                    return AvaName;
                                }
                            }
                            else
                            {
                                AvaName = AvaName + Endung + ".png"; //+Geschlecht
                                return AvaName;
                            }
                        }
                        else
                        {
                            AvaName = AvaName + Endung + ".png"; //+Geschlecht
                            return AvaName;
                        }
                        break;

                    default:
                        return null;
                        break;
                }
            }
        }


        public static List<Models.DataItem> SeperateTOPOINEX_Code(int wert) //Rot_Gelb_Grün_Blau
        {
            List<Models.DataItem> ColorList = new List<Models.DataItem>();
            var temp = wert / 1000000;
            var mod = wert % 1000000;
            var rot = Convert.ToSingle(temp);//float
            ColorList.Add(new Models.DataItem
            {
                Category = "Rot",
                Value = rot,
                Name = "R"
            });
            temp = mod / 10000;
            mod = mod % 10000;
            var gelb = Convert.ToSingle(temp);//float
            ColorList.Add(new Models.DataItem
            {
                Category = "Gelb",
                Value = gelb,
                Name = "Ge"
            });
            temp = mod / 100;
            mod = mod % 100;
            var gruen = Convert.ToSingle(temp);//float
            ColorList.Add(new Models.DataItem
            {
                Category = "Grün",
                Value = gruen,
                Name = "Gr"
            });
            temp = mod;
            var blau = Convert.ToSingle(temp);//float
            ColorList.Add(new Models.DataItem
            {
                Category = "Blau",
                Value = blau,
                Name = "B"
            });
            return ColorList;
        }

    }
}
