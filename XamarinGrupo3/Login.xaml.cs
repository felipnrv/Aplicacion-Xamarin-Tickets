using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinGrupo3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        Registro aute = new Registro();
        public Login(string nombre, string contrasena)
        {
            InitializeComponent();
            txtUsuario.Text = nombre;
            txtContrasena.Text = contrasena;         
        }

        private void btnRecuperarContrasena_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
           if (txtUsuario.Text == "user" && txtContrasena.Text=="123" )
            {
                await Navigation.PushAsync(new DetallesUsuario());
            }
            if (txtUsuario.Text == "tecn" && txtContrasena.Text == "456") 
            { 
                await Navigation.PushAsync (new DetallesTicket());
            }
           if (txtContrasena.Text != "456" && txtContrasena.Text != "123")
            {
                await DisplayAlert("", "Error", "Cerrar");
            }
            if (txtUsuario.Text != "tecn" && txtUsuario.Text != "user")
            {
                await DisplayAlert("", "Error", "Cerrar");
            }

        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }

       
    }
}
   
