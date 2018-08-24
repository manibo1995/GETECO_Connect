using System;
using GETECO_Connect.DataBase;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GETECO_Connect
{
    public partial class App : Application
    {
        static GETECOCONNECTDB database;
        public App()
        {
            InitializeComponent();
            var owner = App.Database.GetLocalUser(1);
            if (owner == null)
            {
                MainPage = new NavigationPage(new Views.Login());
            }
            else
            {
                MainPage = new NavigationPage(new Views.Feed());
            }

        }

        public static GETECOCONNECTDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new GETECOCONNECTDB(DependencyService.Get<IFileHelper>().GetLocalFilePath("GETECOCONNECTDB.db3"));
                }
                return database;
            }
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
