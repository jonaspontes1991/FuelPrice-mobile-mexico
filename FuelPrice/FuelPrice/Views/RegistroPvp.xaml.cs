using FuelPrice.Models;
using FuelPrice.Services;
using FuelPrice.Views.Modal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Forms.Grid;

namespace FuelPrice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroPvp : ContentPage
    {
        UserService _service = new UserService();
        public List<Cliente> cli_List { get; set; }
        public List<Concorrencia> conc_List { get; set; }



        public RegistroPvp()
        {


            InitializeComponent();
            listv.IsVisible = false;
            UserService _service = new UserService();
            cli_List = new List<Cliente>();
            var _cli_List = _service.getCliente();
            cli_List = _cli_List;
            BindingContext = this;
            lblNome.IsVisible = false;
            lblId.IsVisible = false;
            txtCnpjCliente.IsVisible = false;


        }
        //protected async void GetValue(object sender, EventArgs a)
        //{
        //    conc_List = new List<Concorrencia>();
        //    object cliente1 = seletor.SelectedItem;
        //    var cliente = (Cliente)cliente1;
        //    await _service.GetConcorrencia(cliente.Cli_cod);
        //    var post1 = Preferences.Get("Concorrente", "Defalt value");
        //    var post = JsonConvert.DeserializeObject<List<Concorrencia>>(post1);
        //    conc_List = new List<Concorrencia>(post);
        //    listv.ItemsSource = conc_List;
        //    listv.IsVisible = true;
        //    //RefreshV.IsRefreshing = false;

        //}

        private void Button_Clicked(object sender, EventArgs e)
        {
            object cliente1 = seletor.SelectedItem;
            var cliente = (Cliente)cliente1;
            if (cliente != null)
            {
                Preferences.Set("Cliente", cliente.Est_cod);
                Preferences.Set("ClienteCnpj", cliente.Cnpj);
                Preferences.Set("ClienteNome", cliente.Nome);
                Navigation.PushModalAsync(new ModalPvp());

            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            object cliente1 = seletor.SelectedItem;
            var cliente = (Cliente)cliente1;
            if (cliente != null)
            {
                Preferences.Set("Cliente", cliente.Est_cod);
                Preferences.Set("ClienteNome", cliente.Nome);
                Navigation.PushModalAsync(new BuscaPvp());

            }
        }

        private void SwipeItem_Clicked(object sender, EventArgs e)
        {
            var btn = (SwipeItem)sender;
            var cliente = (Concorrencia)btn.BindingContext;
            if (cliente != null)
            {
                Preferences.Set("Cliente", cliente.NCO_CLI_CODIGOCOMPETENCIA);
                Preferences.Set("ClienteNome", cliente.NCO_RAZONSOCIAL);
                Preferences.Set("ClienteCnpj", cliente.NCO_PERMISO);
                Navigation.PushModalAsync(new ModalPvp());
            }
        }

        private void SwipeItem_Clicked_1(object sender, EventArgs e)
        {
            var btn = (SwipeItem)sender;
            var cliente = (Concorrencia)btn.BindingContext;
            if (cliente != null)
            {
                Preferences.Set("Cliente", cliente.NCO_CLI_CODIGOCOMPETENCIA);
                Preferences.Set("ClienteNome", cliente.NCO_RAZONSOCIAL);
                Navigation.PushModalAsync(new BuscaPvp());
            }
        }

        private void busca_TextChanged(object sender, TextChangedEventArgs e)
        {
            refreshV.IsRefreshing = false;
            listv.IsVisible = false;
            lblNome.IsVisible = false;
            lblId.IsVisible = false;
            txtCnpjCliente.IsVisible = false;


            var buscaResult = cli_List.Where(c => c.Nome.ToLower().Contains(busca.Text.ToLower()));
            seletor.ItemsSource = buscaResult.ToList();
        }


        private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            object cliente1 = seletor.SelectedItem;
            var cliente = (Cliente)cliente1;
            if (cliente != null)
            {
                refreshV.IsRefreshing = true;
                lblId.IsVisible = true;
                lblNome.IsVisible = true;
                txtCnpjCliente.IsVisible = true;
                txtCnpjCliente.Text = cliente.Cnpj;
                conc_List = new List<Concorrencia>();
                await _service.GetConcorrencia(cliente.Cli_cod);
                var post1 = Preferences.Get("Concorrente", "Defalt value");
                var post = JsonConvert.DeserializeObject<List<Concorrencia>>(post1);
                conc_List = new List<Concorrencia>(post);
                listv.ItemsSource = conc_List;
                listv.IsVisible = true;
                refreshV.IsRefreshing = false;
            }

        }
    }
}