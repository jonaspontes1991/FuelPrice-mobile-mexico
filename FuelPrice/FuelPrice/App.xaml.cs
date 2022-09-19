using FuelPrice.Services;
using FuelPrice.Views;
using Plugin.FirebasePushNotification;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelPrice
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine($"TOKEN : {p.Token}");
            };
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {

                System.Diagnostics.Debug.WriteLine("Received");
                System.Diagnostics.Debug.WriteLine("Opened");
                foreach (var data in p.Data)
                {
                    System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
                }

            };
            CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Opened");
                foreach (var data in p.Data)
                {
                    System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
                }


            };
        }

    protected override void OnStart()
        {
            if (Preferences.ContainsKey("UserName") && Preferences.ContainsKey("AcessoUser"))
            {


                MainPage = new Home();
                //if(Preferences.ContainsKey("UserClientes"))
                //{
                //    RegistroPvp pvp = new RegistroPvp();
                //    pvp.carregaClientes();

                //}

            }
            else
            {

                MainPage = new Login();

            }

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
