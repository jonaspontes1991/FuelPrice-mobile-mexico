using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelPrice.Models;
using FuelPrice.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelPrice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FuelPriceDynamics : ContentPage
    {


        


        public FuelPriceDynamics()
        {
                    InitializeComponent();


        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            Fram4.BackgroundColor = Color.FromHex("#00c1a6");
            await Navigation.PushAsync(new RegistroPvp());
            Fram4.BackgroundColor = Color.FromHex("#ededed");


        }


    }
}