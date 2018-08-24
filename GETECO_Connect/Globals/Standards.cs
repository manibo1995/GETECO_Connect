using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETECO_Connect.Globals
{
    public static class Standards
    {
        public static string BaseUrl = "http://172.20.10.2/myweb/topoinex_web/";
        //public static string BaseUrl = "85.214.88.234";


        public static string ApiUrl = BaseUrl + "/xconnectapi.php?";
        public static string CmdUrl = ApiUrl + "secureid=" + UserData.SecureID + "&cmd=";
        public static string FormatXML = "&format=xml";
        public static string FormatJson = "&format=json";
    }
}
