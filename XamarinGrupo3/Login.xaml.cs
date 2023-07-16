using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinGrupo3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public string key = "AIzaSyDOzceZLeN8q8hC0a-X0hkzZHAlQ9nUVsI";
        Registro aute = new Registro();
        public Login()
        {
            InitializeComponent();  
        }
        
        private void btnRecuperarContrasena_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(key));
            try
            {

                var auth = await authProvider.SignInWithEmailAndPasswordAsync(txtUsuario.Text, txtContrasena.Text);
                var credenc = await auth.GetFreshAuthAsync();
                var contenido = JsonConvert.SerializeObject(credenc);
                Preferences.Set("datostoken", contenido);
                await Navigation.PushAsync(new Rol());

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Usuario o Contraseña erroneo", "X");
            }

        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }

        private void pUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
   
