
using GETECO_Connect.DataBase;
using System.IO;
using GETECO_Connect.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFileHelper))]
namespace GETECO_Connect.Droid
{
    public class LocalFileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}