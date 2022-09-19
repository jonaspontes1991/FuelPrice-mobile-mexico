using FuelPrice.Models;
using FuelPrice.Services;
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
    public partial class Informe : ContentPage
    {
        UserService _service = new UserService();
        PvpService _servicesPvp = new PvpService();
        public List<Pvp> pvp_list { get; set; }
        public List<Concorrencia> conc_List { get; set; }
        public List<FpPrecalculadosBi> _pvpl { get; set; }
        public List<ReportConcorrencia> RptConcorrencia { get; set; }
        public List<Cliente> cli_List { get; set; }
        public List<string> date_List { get; set; }
        public Informe()
        {
            InitializeComponent();
            Fgrid.IsVisible = false;

            List<string> date_List = new List<string>();
            var date_now = DateTime.Now.Date.ToString("yyyy-MM-dd");
            var date_today = Convert.ToDateTime(date_now);
            date_List.Add(date_today.ToString("dd/MM/yyyy"));
            for (int i = 1; i < 7; i++)
            {
                var dt = Convert.ToDateTime(date_now);
                var dt2 = dt.AddDays(-i);
                date_List.Add(dt2.ToString("dd/MM/yyyy"));

            }
            seletorData.ItemsSource = date_List;
            seletorData.SelectedItem = date_now;
            //UserService _service = new UserService();
            cli_List = new List<Cliente>();
            var _cli_List = _service.getCliente();
            cli_List = _cli_List;
            seletor.ItemsSource = _cli_List;

        }
        private async void seletor_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            seletor2.IsVisible = false;
            Fgrid.IsVisible = false;
            Flogo.IsVisible = true;
            tabelaRefresh.IsRefreshing = false;
            tabelaRefresh.IsEnabled = false;

            dia.Text = "xxxx";
            max.Text = "xxxx";
            min.Text = "xxxx";
            est.Text = "xxxx";
            com.Text = "xxxx";
            DIFPVPMAX.Text = "xxxx";
            DIFPVPMIN.Text = "xxxx";
            DIFCON.Text = "xxxx";
            DIFEST.Text = "xxxx";
            MARGEN.Text = "xxxx";
            var pickit = seletorData.SelectedItem.ToString();
            var pickData = Convert.ToDateTime(pickit);
            var data = pickData.ToString("yyyy-MM-dd");
            var pick = (Picker)sender;
            object cliente1 = pick.SelectedItem;
            var cliente = (Cliente)cliente1;
            if (cliente != null && cliente.Est_cod != null)
            {
                //PvpService service = new PvpService();
                await _servicesPvp.ReportGetPvp(cliente.Est_cod.ToString(), data, cliente.Nome.ToString());

                lg.IsRefreshing = true;
                tabelaRefresh.IsRefreshing = false;
            }
            else
            {
                seletor.ItemsSource = cli_List;
                tabela.IsVisible = false;
                tabelaRefresh.IsEnabled = false;
                await DisplayAlert("Alerta", "No se han encontrado valores precalculados para este Negocio", "Ok");

            }



        }
        private async void RefreshView_Refreshing(object sender, EventArgs e)
        {
            lg.IsRefreshing = false;
            var post1 = Preferences.Get("ReportCliente", "Defalt value");
            if (post1 != "" && post1!="[]" && post1 != null)
            {
                var post2 = JsonConvert.DeserializeObject<List<FpPrecalculadosBi>>(post1);

                _pvpl = new List<FpPrecalculadosBi>();
                _pvpl = post2;
                seletor2.IsVisible = true;
                seletor2.ItemsSource = _pvpl;

            }
            else
            {
                seletor.ItemsSource = cli_List;
                tabela.IsVisible = false;
                tabelaRefresh.IsEnabled = false;

                await DisplayAlert("Alerta", "No se han encontrado valores precalculados para este Negocio", "Ok");

            }



        }

        private void seletor2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabela.IsVisible = false;
            tabelaRefresh.IsEnabled = true;

            if (seletor2.SelectedItem != null && seletor2.SelectedItem.ToString() !="" && seletor2.IsVisible == true)
            {

                tabelaRefresh.IsRefreshing = true;
                setPrecaulculados();

            }
        }
        public async void prConcorrencia(string cli_cod, string conCod, string data)
        {
            ReportConcorrencia conco = new ReportConcorrencia();
            List<ReportConcorrencia> reportConcorrencia = new List<ReportConcorrencia>();
            await _service.GetConcorrencia(cli_cod);
            var post1 = Preferences.Get("Concorrente", "Defalt value");
            var post = JsonConvert.DeserializeObject<List<Concorrencia>>(post1);
            conc_List = new List<Concorrencia>(post);
            foreach (Concorrencia i in conc_List)
            {

                await _servicesPvp.ReportGetPvpConcorrencia(i.NCO_CLI_CODIGOCOMPETENCIA, conCod, data);
                var postPrCom = Preferences.Get("ReportConcorrencia", "Defalt value");
                if (postPrCom != null && postPrCom != "[]" && postPrCom != "")
                {
                    var post2PrCom = JsonConvert.DeserializeObject<List<ReportConcorrencia>>(postPrCom);
                    reportConcorrencia.Add((ReportConcorrencia)post2PrCom[0]);

                }



            }
            tabela.ItemsSource = reportConcorrencia;
            tabelaRefresh.IsRefreshing = false;
            tabelaRefresh.IsEnabled = false;
            tabela.IsVisible = true;


        }
        public void setPrecaulculados()
        {
            //var pick = (Picker)sender;
            //object cliente1 = pick.SelectedItem;
            FpPrecalculadosBi precalculadosBi = new FpPrecalculadosBi();
            //precalculadosBi = (FpPrecalculadosBi)cliente1;

            object posto = seletor.SelectedItem;
            var cliente = (Cliente)posto;

            object pickData = seletorData.SelectedItem;


            object prProduto = seletor2.SelectedItem;
            var prProduto2 = (FpPrecalculadosBi)prProduto;
            precalculadosBi = prProduto2;
            if (precalculadosBi != null && precalculadosBi.PrbCodigo.ToString() != "" && precalculadosBi.ToString() !="[]")
            {
                DateTime dt = Convert.ToDateTime(pickData);
                var dtform = dt.ToString("yyyy-MM-dd");
                prConcorrencia(cliente.Cli_cod, prProduto2.PrbVtpConCodigo, dtform);
                string prdia = precalculadosBi.PrbPrecioVtacliente.ToString();
                string prmax = precalculadosBi.PrbPvpmax.ToString();
                string prmin = precalculadosBi.PrbPpvpmin.ToString();
                string prest = precalculadosBi.PrbPvpest.ToString();
                string prcom = precalculadosBi.PrbPvpcomp.ToString();
                string difMax = (precalculadosBi.PrbPvpmax - precalculadosBi.PrbPrecioVtacliente).ToString();
                string difMin = (precalculadosBi.PrbPrecioVtacliente - precalculadosBi.PrbPpvpmin).ToString();
                string difCom = (precalculadosBi.PrbPvpcomp - precalculadosBi.PrbPrecioVtacliente).ToString();
                string difEst = (precalculadosBi.PrbPvpest - precalculadosBi.PrbPrecioVtacliente).ToString();
                string margen = (precalculadosBi.PrbPcreal - precalculadosBi.PrbPrecioVtacliente).ToString();
                dia.Text = prdia;
                max.Text = prmax;
                min.Text = prmin;
                est.Text = prest;
                com.Text = prcom;
                DIFPVPMAX.Text = difMax;
                DIFPVPMIN.Text = difMin;
                DIFCON.Text = difCom;
                DIFEST.Text = difEst;
                MARGEN.Text = margen;
                Flogo.IsVisible = false;
                Fgrid.IsVisible = true;

            }
        }
        private void busca_TextChanged(object sender, TextChangedEventArgs e)
        {
            var ResultList2 = cli_List.Where(c => c.Nome.ToLower().Contains(busca.Text.ToLower()));
            tabelaRefresh.IsEnabled = false;
            seletor.ItemsSource = ResultList2.ToList();
            
        }
    }
}