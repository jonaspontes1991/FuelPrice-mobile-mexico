using FuelPrice.Models;
using FuelPrice.Services;
using FuelPrice.Views.Modal;
using Newtonsoft.Json;
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
    public partial class BuscaPvp : ContentPage
    {
        PvpService _servicesPvp = new PvpService();
        public List<Pvp> pvp_list { get; set; }
        public BuscaPvp()
        {
            InitializeComponent();
            listPvp.IsPullToRefreshEnabled = false;
            var ClienteNome = Preferences.Get("ClienteNome", "DefaltValue");
            nomeCliente.Text = ClienteNome;
            subir.IsVisible = false;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            RefreshV.IsRefreshing = true;
            var data = txtData.Date.ToString("yyyy-MM-dd");
            //DateTime DateObject = DateTime.ParseExact(data, "dd-MM-yyyy", null);

            pvp_list = new List<Pvp>();
            var est_cod = Preferences.Get("Cliente", "Defalt value");
            await _servicesPvp.GetPvp(est_cod,data);

            var post1 = Preferences.Get("Pvp", "Defalt value");
            var post = JsonConvert.DeserializeObject<List<Pvp>>(post1);
            pvp_list = new List<Pvp>(post);
            if(pvp_list.Count >0)
            {
                listPvp.ItemsSource = pvp_list.Distinct();
                listPvp.IsPullToRefreshEnabled = true;
                imgLogo.IsVisible = false;
                filtro.IsVisible = true;
                listPvp.IsVisible = true;
                RefreshV.IsRefreshing = false;
                subir.IsVisible = true;
            }
            else
            {
                RefreshV.IsRefreshing = false;
               await DisplayAlert("Alerta", "¡No se ha encontrado ningún registro para esa fecha!", "OK");
            }

        }
        //private void Button_Clicked2(object sender, EventArgs e)
        //{
        //    var btn = (MenuItem)sender;
        //    var cliente = (Pvp)btn.BindingContext;
        //    var pvpstring = JsonConvert.SerializeObject(cliente);
        //    Preferences.Set("Pvp2", pvpstring);
        //    Navigation.PushModalAsync(new UpdateModal());

        //}

        //private async void MenuItem_Clicked(object sender, EventArgs e)
        //{
        //    var btn = (MenuItem)sender;
        //    var cliente = (Pvp)btn.BindingContext;
        //    var cod = Convert.ToInt32(cliente.CODIGO);
        //    var response = await _servicesPvp.DeletePvp(cod);
        //    if(response == "executado com sucesso")
        //    {
        //       await DisplayAlert("ejecutado com éxito", "Registro borrado!", "OK");
        //    }
        //    else
        //    {
        //        await DisplayAlert("Error", "ningún registro fue borrado!", "OK");

        //    }

        //}

        private async void listPvp_Refreshing(object sender, EventArgs e)
        {
            listPvp.IsVisible = false;
            var data = txtData.Date.ToString("yyyy-MM-dd");
            //DateTime DateObject = DateTime.ParseExact(data, "dd-MM-yyyy", null);

            pvp_list = new List<Pvp>();
            var est_cod = Preferences.Get("Cliente", "Defalt value");
            await _servicesPvp.GetPvp(est_cod, data);

            var post1 = Preferences.Get("Pvp", "Defalt value");
            var post = JsonConvert.DeserializeObject<List<Pvp>>(post1);
            pvp_list = new List<Pvp>(post);
            if (pvp_list.Count > 0)
            {
                listPvp.ItemsSource = pvp_list;

                listPvp.IsVisible = true;
                listPvp.IsRefreshing = false;
            }
            else
            {
                await DisplayAlert("Alerta", "¡No se ha encontrado ningún registro para esa fecha!", "OK");
                listPvp.IsPullToRefreshEnabled = false;
                filtro.IsVisible = false;

            }
        }

        private void busca_TextChanged(object sender, TextChangedEventArgs e)
        {
            var buscaResult = pvp_list.Where(c =>c.HORA.ToLower().Contains(busca.Text.ToLower()));
            listPvp.ItemsSource = buscaResult;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Fbusca.IsVisible = false;
            subir.IsVisible = false;
            baixar.IsVisible = true;
            banner.IsVisible = false;
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            Fbusca.IsVisible = true;
            baixar.IsVisible = false;
            subir.IsVisible = true;
            banner.IsVisible = true;
        }
    }
}