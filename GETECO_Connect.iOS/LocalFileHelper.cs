using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Xamarin.Forms;
using GETECO_Connect.iOS;

using Foundation;
using UIKit;
using GETECO_Connect.DataBase;
[assembly:Dependency(typeof(LocalFileHelper))]
namespace GETECO_Connect.iOS
{
    public class LocalFileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "Libary", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, filename);
        }


    }
}