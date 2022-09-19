
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
    public partial class Login : ContentPage
    {
        private UserService _userService;

        public Login()
        {
            _userService = new UserService();
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            RefreshV.IsRefreshing = true;
            String email = null;
            string senha = null;
            email = txtEmail.Text;
            senha = txtSenha.Text.Replace("#","%23");

            if (txtEmail.Text ==null || txtEmail.Text =="")
            {
                txtEmail.Placeholder = "El campo del usuario es obligatorio*";
                txtEmail.PlaceholderColor = Color.Red;
                RefreshV.IsRefreshing = false;

                txtEmail.Focus();
            }
            else if(txtSenha.Text ==null|| txtSenha.Text=="")
            {
                txtSenha.Placeholder = "El campo dela contraseña es obligatorio*";
                txtSenha.PlaceholderColor = Color.Red;
                RefreshV.IsRefreshing = false;

                txtSenha.Focus();

            }
            else if(txtSenha.Text !=null & txtEmail.Text !=null)
            {
                var user = await _userService.login(email, senha);

                //_userService.getCliente();


                if (user == null)
                {
                    RefreshV.IsRefreshing = false;

                    await DisplayAlert("Error 403!", "¡Usuario no encontrado!", "OK");

                }
                else if (user == "404")
                {
                    RefreshV.IsRefreshing = false;

                    await DisplayAlert("Error 404!", "Servidor no disponible", "Ok");
                }                
                else if (user == "403-1")
                {
                    RefreshV.IsRefreshing = false;

                    await DisplayAlert("Acesso Negado!", "Este usuario no tiene acceso a la aplicación móvil", "Ok");
                }
                else
                {
                    RefreshV.IsRefreshing = false;

                    App.Current.MainPage = new MainShell();
                }
            }
            else
            {
                RefreshV.IsRefreshing = false;

                await DisplayAlert("Alerta!", "Todos los campos son obligatorios*", "Ok");
                txtEmail.Focus();
            }


        }


    }
}