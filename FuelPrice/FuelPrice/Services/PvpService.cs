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
    class PvpService : Service
    {
        public async Task GetPvp(string est_cod,string data)
        {
            var response2 = await _cliente.GetAsync(BaseApiUrl + "api/BR_Pvp/GetByDate?cod=" + est_cod+ "&date="+ data);
            var content = await response2.Content.ReadAsStringAsync();
            Preferences.Set("Pvp", content);



        }
        public async Task<String> insertPvp(PvpPost pvp)
        {
            HttpResponseMessage response2 = await _cliente.PostAsJsonAsync($"{BaseApiUrl}api/BR_Pvp", pvp);
            var content = await response2.Content.ReadAsStringAsync();
            return content;
        }
        public async Task ReportGetPvp(string est_cod, string data,string nome)
        {
            var response2 = await _cliente.GetAsync(BaseApiUrl + "GetReportPvp/" + est_cod + "?pass=" + data + "&nome="+ nome);
            var content = await response2.Content.ReadAsStringAsync();
            Preferences.Set("ReportCliente", content);
            //var post = JsonConvert.DeserializeObject<List<FpPrecalculadosBi>>(content).ToList();
            //return post;
        }
        public async Task ReportGetPvpConcorrencia(string est_cod, string conCod, string data)
        {
            var response2 = await _cliente.GetAsync(BaseApiUrl + "GetReportConcorrenciaPvp/" + est_cod + "?conCod=" + conCod + "&data=" + data);
            var content = await response2.Content.ReadAsStringAsync();
            Preferences.Set("ReportConcorrencia", content);
            //var post = JsonConvert.DeserializeObject<List<FpPrecalculadosBi>>(content).ToList();
            //return post;
        }
        //public async Task<string> DeletePvp(Int32 id)
        //{
        //    HttpResponseMessage response2 = await _cliente.GetAsync(BaseApiUrl + "api/BR_Pvp/deletepvp/" + id);
        //    var content = await response2.Content.ReadAsStringAsync();
        //    return content;
        //}
        //public async Task<String> UpdatePvp(PvpPost pvp)
        //{
        //    var  response2 = await _cliente.PostAsJsonAsync($"{BaseApiUrl}api/br_user/",pvp);
        //    var content = await response2.Content.ReadAsStringAsync();
        //    return content;
        //}
    }
}
