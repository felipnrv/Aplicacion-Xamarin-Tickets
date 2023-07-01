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
    public partial class Registro : ContentPage
    {
        UsuarioDB usuariodb = new UsuarioDB();
        public Registro()
        {
            InitializeComponent();
        }

        private void pUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pUsuarios.SelectedIndex == -1)
            {
                DisplayAlert("Alerta", "Valor Nulo", "Cerrar");
            }
            else
            {
                DisplayAlert("Alerta", pUsuarios.Items[pUsuarios.SelectedIndex], "cerrar");

            }
        }

        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            DateTime edad = dpEdad.Date;
            string genero = txtGenero.Text;
            string cedula = txtCedula.Text;
            string telefono = txtTelefono.Text;
            string ciudad = txtCiudad.Text;
            string empresa = txtEmpresa.Text;

            if (string.IsNullOrEmpty(nombre))
            {
                DisplayAlert("Abrir","Falta Completar el Nombre","Cerrar");
            }
            if (string.IsNullOrEmpty(apellido))
            {
                DisplayAlert("Abrir", "Falta Completar el Apellido", "Cerrar");
            }
            if (edad==DateTime.MinValue && edad == null)
            {
                DisplayAlert("Abrir", "Falta Completar la Edad", "Cerrar");
            }
            if (string.IsNullOrEmpty(genero))
            {
                DisplayAlert("Abrir", "Falta Completar el Genero", "Cerrar");
            }
            if (string.IsNullOrEmpty(cedula))
            {
                DisplayAlert("Abrir", "Falta Completar la Cedula", "Cerrar");
            }
            if (string.IsNullOrEmpty(telefono))
            {
                DisplayAlert("Abrir", "Falta Completar el Telefono", "Cerrar");
            }
            if (string.IsNullOrEmpty(ciudad))
            {
                DisplayAlert("Abrir", "Falta Completar la Ciudad", "Cerrar");
            }
            if (string.IsNullOrEmpty(empresa))
            {
                DisplayAlert("Abrir", "Falta Completar la Empresa", "Cerrar");
            }

            UsuarioModelo usuario=new UsuarioModelo();
            usuario.nombreuser = nombre;
            usuario.apellidouser=apellido;
            usuario.edaduser=edad;
            usuario.generouser=genero;
            usuario.cedulauser=cedula;
            usuario.telefonouser=telefono;
            usuario.ciudaduser=ciudad;
            //usuario.roleuser=

            var guardar=await usuariodb.GuardarUsuario(usuario);
            if(guardar)
            {
                await DisplayAlert("Información", "Registro guardado correctamente", "Cerrar");
            }
            else
            {
                await DisplayAlert("Error", "El registro no se guardo correctamente", "Cerrar");

            }
        }
    }
}