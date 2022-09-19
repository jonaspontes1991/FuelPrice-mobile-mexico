
using FuelPrice.Models;
using FuelPrice.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FuelPrice.Services
{
   public class UserService : Service
    {
        public List<Concorrencia> conc_List { get; set; }
        private List<Cliente> cli_List { get; set; }
        private List<Produtos> produtos_List { get; set; }
        private List<User> User_List { get; set; }

        public async Task<string> login(string email,string senha)
        {

            HttpResponseMessage status = await _cliente.GetAsync(BaseApiUrl + "api/br_user/" + email + "?pass=" + senha);
            var response = await _cliente.GetStringAsync(BaseApiUrl + "api/br_user/" + email + "?pass=" + senha);
            var userDat2 = await status.Content.ReadAsStringAsync();
            var post = JsonConvert.DeserializeObject<List<User>>(userDat2);
            bool b = post.Exists(e => e.UsaApp == "true" );
            string n = null ;

            if (status.IsSuccessStatusCode && b == true)
            {
                if(response.Equals(""))
                {
                    n = null;
                }
                else if(response.Length >2)
                {
                    n = "200";
                    //App.Current.Properties.Add("User", JsonConvert.SerializeObject(response));
                    //App.Current.Properties.Add("UserName", email);
                    //await App.Current.SavePropertiesAsync();
                    Preferences.Set("UserName",email);
                    Preferences.Set("Passeword",senha);
                    var user = Preferences.Get("UserName", "default_value");
                    var response2 = await _cliente.GetAsync(BaseApiUrl + "api/BR_Cliente/GetCliente/" + user);
                    var content = await response2.Content.ReadAsStringAsync();
                    var responseProdutos = await _cliente.GetAsync(BaseApiUrl + "api/BR_Cliente/GetProdutos");
                    var contentProdutos = await responseProdutos.Content.ReadAsStringAsync();
                    var responseLogo = await _cliente.GetAsync(BaseApiUrl + "api/br_user/GetLogo/"+ email );
                    var contentLogo = await responseLogo.Content.ReadAsStringAsync();
                    var responseAcesso = await _cliente.GetAsync(BaseApiUrl + "api/br_user/GetAcessoApp/"+ email);
                    var contentAcesso = await responseAcesso.Content.ReadAsStringAsync();


                    Preferences.Set("UserClientes", content);
                    Preferences.Set("ProdutosVenda", contentProdutos);
                    Preferences.Set("LogoMaestro", contentLogo);
                    Preferences.Set("AcessoUser", contentAcesso);


                }
                else
                {
                    n = "404";

                }


            }
            else if(b== false)
            {
                n = "403-1";
 
            }
            else
            {
                n = null;

            }
            return n;

        }
        public List<Cliente> getCliente()
        {


            var cliList = Preferences.Get("UserClientes", "Default_value");
            var post = JsonConvert.DeserializeObject<List<Cliente>>(cliList);
            cli_List = new List<Cliente>(post);
            return cli_List;

        }
        public async Task GetConcorrencia(string CliCodigo)
        {
            var response2 = await _cliente.GetAsync(BaseApiUrl + "api/BR_Cliente/GetCompetencia/" + CliCodigo);
            var content = await response2.Content.ReadAsStringAsync();
            Preferences.Set("Concorrente", content);



        }
        public List<Produtos> getProdutos()
        {


            var cliList = Preferences.Get("ProdutosVenda", "Default_value");
            var post = JsonConvert.DeserializeObject<List<Produtos>>(cliList);
            produtos_List = new List<Produtos>(post);
            return produtos_List;

        }
        public async Task getpass()
        {
            var email = Preferences.Get("UserName", "Default");
            var responseAcesso = await _cliente.GetAsync(BaseApiUrl + "api/br_user/GetAcessoApp/" + email);
            var contentAcesso = await responseAcesso.Content.ReadAsStringAsync();
            Preferences.Set("AcessoUser", contentAcesso);
        }

    }
}
