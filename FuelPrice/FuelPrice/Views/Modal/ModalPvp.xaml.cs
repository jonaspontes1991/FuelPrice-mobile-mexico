using FuelPrice.Models;
using FuelPrice.Services;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelPrice.Views.Modal
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ModalPvp : ContentPage
	{
		UserService _services = new UserService();
		PvpService _servicesPvp = new PvpService();
		public List<Produtos> produtos_list { get; set; }
		public List<Pvp> pvp_list { get; set; }
		public List<Cliente> cli_list { get; set; }
		public ModalPvp ()
		{
			InitializeComponent ();
            var ClienteNome = Preferences.Get("ClienteNome", "DefaltValue");
            nomeCliente.Text = ClienteNome;
			produtos_list = new List<Produtos>();
			var listProdutos = _services.getProdutos();
			produtos_list = listProdutos;
            txtHora.Time = DateTime.Now.TimeOfDay;
			BindingContext = this;
		}

        private void CarouselView_Current9ItemChanged(object sender, CurrentItemChangedEventArgs e)
        {

        }

        private void GetValue(object sender, EventArgs e)
        {

        }

        private async void Button_Clicked(object sender, EventArgs e)

        {
           PvpPost _Pvp = new PvpPost();
                string hora = null;
                string minuto = null;
                Produtos v = null;
                v = (Produtos)combName.SelectedItem;
            if (txtPreco.Text == "" || txtPreco.Text == null || v == null)
            {
                await DisplayAlert("Alerta", "¡Ningún campo puede estar vacío!", "Ok");
            }
            else
            {
                var d = txtPreco.Text;
                var prec = d.Replace(",", ".");
                var precio = float.Parse(prec, System.Globalization.CultureInfo.InvariantCulture);


                var cod_est = Preferences.Get("Cliente", "DefaltValue");
                var cnpj = Preferences.Get("ClienteCnpj", "DefaltValue");
                var data = txtData.Date.ToString("yyyy-MM-dd");
                hora = txtHora.Time.Hours.ToString();
                minuto = txtHora.Time.Minutes.ToString();
                if (hora == "0" || hora.Length < 2)
                {
                    hora = "0" + hora;

                }
                if (minuto == "0" || minuto.Length < 2)
                {
                    minuto = "0" + minuto;
                }

                if (precio <= 5.30)
                {
                    await DisplayAlert("Alerta", "¡El precio no puede ser inferior a 3, 00 libras!", "Ok");

                }

                else if (txtPreco.Text != "" && txtPreco.Text != null && v != null)
                {

                    var horaeminuto = hora + ":" + minuto;
                    _Pvp.pvpFecha = data;
                    _Pvp.pvpHora = horaeminuto;
                    _Pvp.pvpPrecio = txtPreco.Text;
                    _Pvp.pvpEstCodigo = cod_est;
                    _Pvp.pvpConCodigo = v.VTP_CON_CODIGO;
                    _Pvp.pvpNopermiso = cnpj;
                    _Pvp.pvpYear = 0;
                    _Pvp.pvpCodigo = "0";
                    var response = await _servicesPvp.insertPvp(_Pvp);
                    if (response == "executado com sucesso")
                    {
                        await DisplayAlert("ejecutado com éxito", "lo registro fue actualizado com éxito!", "Ok");

                    }
                }
            }
            
        }
    }
}