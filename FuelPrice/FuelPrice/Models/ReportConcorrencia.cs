using System;
using System.Collections.Generic;
using System.Text;

namespace FuelPrice.Models
{
   public class ReportConcorrencia
    {
        public string PRE_CODIGO { get; set; }
        public string NOME { get; set; }
        public string PRE_PRECIO { get; set; }
        public string PRE_NOPERMISO { get; set; }
        public string DIF { get; set; }
        public string COR { get; set; }
        public string PRE_ANTERIOR { get; set; }
        public string FECHA_ANTERIOR { get; set; }
        public string TENDENCIA { get; set; }
        public string PRE_FECHA_REGISTRO { get; set; }
        public string FECHA { get; set; }
        public static explicit operator ReportConcorrencia(List<ReportConcorrencia> v)
        {
            throw new NotImplementedException();
        }
    }
}
