using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelPrice.Views.Partial_Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeaderMenu : ContentView
    {
        public HeaderMenu()
        {
            InitializeComponent();
            txtNameUser.Text = Preferences.Get("UserName", "DafaltValue");
            total.Source = Preferences.Get("LogoMaestro", "defalt");
        }
    }
}