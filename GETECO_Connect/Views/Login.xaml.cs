using System;
using System.Collections.Generic;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace GETECO_Connect.Views
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            this.BindingContext = new Viewmodels.LoginViewmodel();
        }

        private void LoginButton_Clicked()
        {
            Device.BeginInvokeOnMainThread(() =>
            {

                stack.IsVisible = false;
                //BusyIndicator.IsVisible = true;
                //BusyIndicator.IsBusy = true;
            });
            if (true)
            {

                var result = ((Viewmodels.LoginViewmodel)this.BindingContext).Login();
                Device.BeginInvokeOnMainThread(() =>
                {

                    //BusyIndicator.IsBusy = false;
                    //BusyIndicator.IsVisible = false;
                    stack.IsVisible = true;
                    this.Navigation.PushAsync(new Views.Feed());
                });
                if (result == null)
                { }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        //BusyIndicator.IsBusy = false;
                        //BusyIndicator.IsVisible = false;
                        stack.IsVisible = true;
                    });
                    DisplayAlert("Fehler", result, "OK");
                }
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    //BusyIndicator.IsBusy = false;
                    //BusyIndicator.IsVisible = false;
                    stack.IsVisible = true;
                });
                DisplayAlert("Fehler", "Es besteht keine Verbindung zum Internet. Verbinden Sie sich mit dem Inernet und versuchen Sie es erneut!", "OK");
            }
        }

        private void RegisterButton_Clicked()
        {
            this.Navigation.PushAsync(new Views.Register());
        }
    }
}
