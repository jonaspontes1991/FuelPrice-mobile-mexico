using System;
using System.Collections.Generic;
using System.Text;

namespace FuelPrice.Models
{
  public  class Pvp
    {
        public string CODIGO { get; set; }
        public string CON_DESC { get; set; }
        public string CON_CODIGO { get; set; }
        public string FECHA { get; set; }
        public string HORA { get; set; }
        public string EST_CODIGO { get; set; }
        public string PRE_HOY { get; set; }
        public string CNPJ { get; set; }
        public string PRE_YEAR { get; set; }
        public string PRE_INSERT_FROM_PVP { get; set; }
    }
}
public class PvpPost
{
 
    public string pvpCodigo { get; set; }
    public int pvpYear { get; set; }
    public string pvpFecha { get; set; }
    public string pvpHora { get; set; }
    public string pvpEstCodigo { get; set; }
    public string pvpConCodigo { get; set; }
    public string pvpPrecio { get; set; }
    public string pvpNopermiso { get; set; }
}
