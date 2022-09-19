using FuelPrice.Models;
using FuelPrice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelPrice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {

        public List<Carrossel> ListCar{ get; set; }

        public Home()
        {
            InitializeComponent();           
            ListCar = new List<Carrossel>();
            Carrossel carrossel = new Carrossel();
            var carr = carrossel.carrossels();
            ListCar = carr;

            car.ItemsSource = ListCar;
            Device.StartTimer(TimeSpan.FromSeconds(2),(Func<bool>)(()=>
            {
                car.Position = (car.Position + 1) % ListCar.Count;
                return true;
            }));
            _ = GetAcessoAsync();

        }

        private  void ImageButton_Clicked(object sender, EventArgs e)
        {

            Fram1.BackgroundColor = Color.FromHex("#00c1a6");
            Fram4_1.BackgroundColor = Color.FromHex("#00c1a6");
            Fram5_1.BackgroundColor = Color.FromHex("#00c1a6");
            Fram6_1.BackgroundColor = Color.FromHex("#00c1a6");


            App.Current.MainPage = new SehellDynamics();
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            RefreshV.IsRefreshing = true;

            Fram2_2.BackgroundColor = Color.FromHex("#00c1a6");
            Fram4_2.BackgroundColor = Color.FromHex("#00c1a6");
            Fram5_2.BackgroundColor = Color.FromHex("#00c1a6");
            Fram7_2.BackgroundColor = Color.FromHex("#00c1a6");

            App.Current.MainPage = new shellReport();


        }

        private void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            RefreshV.IsRefreshing = true;

            Fram3_3.BackgroundColor = Color.FromHex("#00c1a6");
            Fram4_3.BackgroundColor = Color.FromHex("#00c1a6");
            Fram6_3.BackgroundColor = Color.FromHex("#00c1a6");
            Fram7_3.BackgroundColor = Color.FromHex("#00c1a6");


            App.Current.MainPage = new shellforeCast();
        }
        public async Task GetAcessoAsync ()
        {
            UserService _service = new UserService();
            await _service.getpass();
            var logoMaestro = Preferences.Get("LogoMaestro", "DefaltValue");
            var acessoUMser = Preferences.Get("AcessoUser", "DefaltValue");
            if(acessoUMser == "1")
            {
                Acesso1.IsVisible = true;
                Acesso2.IsVisible = false;
                Acesso3.IsVisible = false;
                Acesso4.IsVisible = false;
                Acesso5.IsVisible = false;
                Acesso6.IsVisible = false;
                Acesso7.IsVisible = false;

            }
            else if(acessoUMser == "2")
            {
                Acesso1.IsVisible = false;
                Acesso2.IsVisible = true;
                Acesso3.IsVisible = false;
                Acesso4.IsVisible = false;
                Acesso5.IsVisible = false;
                Acesso6.IsVisible = false;
                Acesso7.IsVisible = false;

            }
            else if(acessoUMser == "3")
            {
                Acesso1.IsVisible = false;
                Acesso2.IsVisible = false;
                Acesso3.IsVisible = true;
                Acesso4.IsVisible = false;
                Acesso5.IsVisible = false;
                Acesso6.IsVisible = false;
                Acesso7.IsVisible = false;

            }        
            else if(acessoUMser == "4")
            {
                Acesso1.IsVisible = false;
                Acesso2.IsVisible = false;
                Acesso3.IsVisible = false;
                Acesso4.IsVisible = true;
                Acesso5.IsVisible = false;
                Acesso6.IsVisible = false;
                Acesso7.IsVisible = false;

            }
            else if(acessoUMser == "5")
            {
                Acesso1.IsVisible = false;
                Acesso2.IsVisible = false;
                Acesso3.IsVisible = false;
                Acesso4.IsVisible = false;
                Acesso5.IsVisible = true;
                Acesso6.IsVisible = false;
                Acesso7.IsVisible = false;

            }
            else if(acessoUMser == "6")
            {
                Acesso1.IsVisible = false;
                Acesso2.IsVisible = false;
                Acesso3.IsVisible = false;
                Acesso4.IsVisible = false;
                Acesso5.IsVisible = false;
                Acesso6.IsVisible = true;
                Acesso7.IsVisible = false;

            }
            else if(acessoUMser == "7")
            {
                Acesso1.IsVisible = false;
                Acesso2.IsVisible = false;
                Acesso3.IsVisible = false;
                Acesso4.IsVisible = false;
                Acesso5.IsVisible = false;
                Acesso6.IsVisible = false;
                Acesso7.IsVisible = true;

            }
            else
            {
                Acesso1.IsVisible = false;
                Acesso2.IsVisible = false;
                Acesso3.IsVisible = false;
                Acesso4.IsVisible = false;
                Acesso5.IsVisible = false;
                Acesso6.IsVisible = false;
                Acesso7.IsVisible = false;

            }

        }

        private void RefreshV_Refreshing(object sender, EventArgs e)
        {
            _ = GetAcessoAsync();
            RefreshV.IsRefreshing = false;

        }
    }
}