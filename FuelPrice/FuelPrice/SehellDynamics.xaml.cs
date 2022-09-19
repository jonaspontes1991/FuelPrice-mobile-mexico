using FuelPrice.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelPrice
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SehellDynamics : Shell
    {
        public SehellDynamics()
        {
            InitializeComponent();

        }
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //App.Current.Properties.Remove("User");
            //App.Current.Properties.Remove("UserName");
            Preferences.Remove("UserName");
            Preferences.Remove("AcessoUser");
            Preferences.Clear();
            App.Current.MainPage = new Login();

        }
        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new Home();

        }
    }
}