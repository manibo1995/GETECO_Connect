using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETECO_Connect.Globals
{
    public static class UserData
    {
        public static string SecureID
        {
            get
            {
                return "123";    //Anscheinend neue SecureId
            }
        }


        private static string userID;
        public static string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public static string OwnId { get; set; }
        public static string Username { get; set; }
        public static string Vorname { get; set; }
        public static string Name { get; set; }
        public static string Id_Person { get; set; }
        public static string Is_Master { get; set; }
        public static string Is_User { get; set; }
        public static string Picture { get; set; }
        




    }
}
