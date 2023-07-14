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
            Auteo();
                
        }
        private async void Auteo()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(key));
            try
            {
                var salvar = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("datostoken1",""));
                var refrescar = await authProvider.RefreshAuthAsync(salvar);
                Preferences.Set("datostoke1",JsonConvert.SerializeObject(refrescar));
                txtUsuario.Text = salvar.User.Email;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await DisplayAlert("Alerta", "exito", "cerrar");
            }
           
        }

        private void btnRecuperarContrasena_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
           //if (txtUsuario.Text == "user" && txtContrasena.Text=="123" )
           // {
           //     await Navigation.PushAsync(new DetallesUsuario());
           // }
           // if (txtUsuario.Text == "tecn" && txtContrasena.Text == "456") 
           // { 
           //     await Navigation.PushAsync (new DetallesTicket());
           // }
           //if (txtContrasena.Text != "456" && txtContrasena.Text != "123")
           // {
           //     await DisplayAlert("", "Error", "Cerrar");
           // }
           // if (txtUsuario.Text != "tecn" && txtUsuario.Text != "user")
           // {
           //     await DisplayAlert("", "Error", "Cerrar");
           // }
           Preferences.Remove("datostoke1");
            App.Current.MainPage=new NavigationPage(new DetallesTicket());
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }

       
    }
}
   
