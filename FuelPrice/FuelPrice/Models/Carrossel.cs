using System;
using System.Collections.Generic;
using System.Text;

namespace FuelPrice.Models
{
    public class Carrossel
    {

        public string img { get; set; }
        public string cor { get; set; }
        public string txt { get; set; }
        public List<Carrossel> ListCar { get; set; }
        public List<Carrossel> carrossels ()
        {
            ListCar = new List<Carrossel>();
            Carrossel carrossel = new Carrossel();
            Carrossel carrossel2 = new Carrossel();
            Carrossel carrossel3 = new Carrossel();
            carrossel.img = "Logo.png";
            carrossel.cor = "#36a290";
            carrossel.txt = "APLICACIÓN INFORMÁTICA DE DETERMINACION DE PRECIOS";
            ListCar.Add(carrossel);
            carrossel2.img = "logo2.png";
            carrossel2.cor = "#858645";
            carrossel2.txt = "ANÁLISIS DE PRECIOS EN PUNTO DE VENTA";
            ListCar.Add(carrossel2);
            carrossel3.img = "logo3.png";
            carrossel3.cor = "#5f5f61";
            carrossel3.txt = "SERVICIO DE PREVISIÓN DE COMPRAS";
            ListCar.Add(carrossel3);
            return ListCar;
        }
    }
}
