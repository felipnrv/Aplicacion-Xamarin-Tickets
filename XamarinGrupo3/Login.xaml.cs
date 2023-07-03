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
        public Login()
        {
            InitializeComponent();
        }

        private void btnRecuperarContrasena_Clicked(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            if
              (txtUsuario.Text == "admin" || txtContrasena.Text == "123")
            {
                Navigation.PushAsync(new Tickets());
            }
            else
            {
                DisplayAlert("Advertencia", "Nombre de Usuario o Contraseña incorrecta", "Cerrar");
            }
            if (txtUsuario.Text == "Tecnico" || txtContrasena.Text == "4567")
            {
                Navigation.PushAsync(new DetallesTicket ());

            }
            else
            {
                DisplayAlert("Advertencia", "Nombre de Usuario o Contraseña incorrecta", "Cerrar");
            }
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}