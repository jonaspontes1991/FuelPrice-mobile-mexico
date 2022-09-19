
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace FuelPrice.Models
{

    public partial class User
    {

        public string Id { get; set; }


        public string Email { get; set; }


        public string EmailConfirmed { get; set; }


        public string PasswordHash { get; set; }


        public string SecurityStamp { get; set; }


        public string PhoneNumber { get; set; }


        public string PhoneNumberConfirmed { get; set; }


        public string TwoFactorEnabled { get; set; }


        public string LockoutEndDateUtc { get; set; }


        public string LockoutEnabled { get; set; }


        public string AccessFailedCount { get; set; }


        public string UserName { get; set; }


        public string Nombre { get; set; }


        public string ApellidoPaterno { get; set; }


        public string ApellidoMaterno { get; set; }

        public string Estatus { get; set; }


        public string IdUsrRegistra { get; set; }


        public string FechaRegistro { get; set; }


        public string MclCodigo { get; set; }


        public string IdmCultura { get; set; }

      
        public string UsaApp { get; set; }



        public static implicit operator User(string v)
        {
            throw new NotImplementedException();
        }
    }


}
