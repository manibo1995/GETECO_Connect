using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETECO_Connect.Viewmodels
{
    public class RegisterViewmodel : INotifyPropertyChanged
    {
        private ObservableCollection<string> geschlechter;
        public ObservableCollection<string> Geschlechter
        {
            get
            {
                return geschlechter;
            }
            set
            {
                geschlechter = value;
                OnPropertyChanged("Geschlechter");
            }
        }
        public RegisterViewmodel()
        {
            Geschlechter = new ObservableCollection<string>();
            Geschlechter.Add("Männlich");
            Geschlechter.Add("Weiblich");
        }

        public object SendRegister(string url)
        {
            var a = Globals.Methods.CallService(url);
            return a;
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
