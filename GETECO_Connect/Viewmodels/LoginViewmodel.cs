using System;
using System.ComponentModel;

namespace GETECO_Connect.Viewmodels
{


    public class LoginViewmodel : INotifyPropertyChanged
    {
        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public LoginViewmodel()
        {

        }
        public string Login()
        {
            string loginString = Globals.Commands.getLoginString(Username, Password);

            return Globals.Methods.Login(loginString);
            //if (Globals.Methods.Login(loginString) == null)
            //{
            //    string settingsString = Globals.Commands.getSettingsString();
            //    Globals.Methods.Settings(settingsString);   //Fehlerbehandlung
            //    return null;
            //}
            //else
            //{
            //    return Globals.Methods.Login(loginString);
            //}

        }
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion PropertyChanged

    }
}
