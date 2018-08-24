using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GETECO_Connect.Views
{
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
            this.BindingContext = new Viewmodels.RegisterViewmodel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (usname.Text == String.Empty || gender.SelectedItem == null || mail.Text == String.Empty || mailagain.Text == String.Empty || pw.Text == String.Empty)
            {
                DisplayAlert("Achtung!", "Bitte überprüfen sie Ihre eingabe", "OK");
            }
            else if (mail.Text == mailagain.Text)
            {
                string gen = "";
                if (gender.SelectedItem.ToString() == "Männlich")
                {
                    gen = "m";
                }
                else
                {
                    gen = "w";
                }
                var a = ((Viewmodels.RegisterViewmodel)this.BindingContext).SendRegister(Globals.Commands.getAddUserString(usname.Text, vorname.Text, nachname.Text, mail.Text, tel.Text, gen, pw.Text));
                this.Navigation.PushAsync(new Views.Feed());
            }
            else
            {
                DisplayAlert("Achtung!", "Überprüfen Sie die E-Mailadresse", "OK");
            }
        }
    }
}
