using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FuelPrice.Services
{
  public abstract  class Service
    {
        protected HttpClient _cliente;
        protected String BaseApiUrl = "https://www.fuelms.com/APIAPP/";
        //protected String BaseApiUrl = "https://apiappfuelpicemexico20220607145109.azurewebsites.net/";
        //protected String BaseApiUrl = "https://fuelpiceapibr.azurewebsites.net/";
        public Service()
        {
            _cliente = new HttpClient();
        }
    }
}
