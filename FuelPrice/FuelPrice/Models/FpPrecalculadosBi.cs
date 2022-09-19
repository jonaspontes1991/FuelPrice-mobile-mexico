using System;
using System.Collections.Generic;
using System.Text;

namespace FuelPrice.Models
{
   public class FpPrecalculadosBi
    {

        public int PrbCodigo { get; set; }
        public Guid? PrbEstCodigo { get; set; }
        public string PrbCliNopermiso { get; set; }
        public string PrbCliDescripcion { get; set; }
        public DateTime? PrbFechaDia { get; set; }
        public string PrbVtpConCodigo { get; set; }
        public string PrbVtpDescripcion { get; set; }
        public string PrbVtpDescripcionCorta { get; set; }
        public string PrbVtpDescripcionCre { get; set; }
        public decimal? PrbDifdia { get; set; }
        public decimal? PrbPcreal { get; set; }
        public decimal? PrbPtransfeobj { get; set; }
        public decimal? PrbPtransfehoy { get; set; }
        public decimal? PrbPvpobjhoy { get; set; }
        public decimal? PrbPvprecult { get; set; }
        public decimal? PrbPvpcomp { get; set; }
        public decimal? PrbPvpmax { get; set; }
        public decimal? PrbPpvpmin { get; set; }
        public decimal? PrbPvpest { get; set; }
        public decimal? PrbVolobjetivo { get; set; }
        public decimal? PrbVolumenreal { get; set; }
        public decimal? PrbPorcVolrealObjmes { get; set; }
        public DateTime? PrbFechaUltimaCompra { get; set; }
        public decimal? PrbPrecioVtacliente { get; set; }
        public decimal? PrbMargenObj { get; set; }
        public string PrbEstEstratNopermiso { get; set; }
        public decimal? PrbPcHoy { get; set; }
        public DateTime? PrbFechaRegistro { get; set; }
        public string Nome => $"{PrbVtpDescripcion} : {PrbVtpDescripcionCre}";

        public static explicit operator FpPrecalculadosBi(List<FpPrecalculadosBi> v)
        {
            throw new NotImplementedException();
        }
    }
}
