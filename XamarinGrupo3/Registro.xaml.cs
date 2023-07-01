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
        TecnicoDB guardarTecn = new TecnicoDB();
        public Registro()
        {
            InitializeComponent();
        }

        private void pUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pUsuarios.SelectedIndex == 1)
            {
                
                txtEmpresa.IsVisible = true;
                lblEmpresa.IsVisible = true;            }
            else
            {
                
                txtEmpresa.IsVisible = false;
                lblEmpresa.IsVisible = false;
            }
        }

        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            DateTime edad = dpEdad.Date;
            string cedula = txtCedula.Text;
            string telefono = txtTelefono.Text;
            string ciudad = txtCiudad.Text;
            string empresa = txtEmpresa.Text;

            if (string.IsNullOrEmpty(nombre))
            {
                DisplayAlert("Abrir", "Falta Completar el Nombre", "Cerrar");
            }
            if (string.IsNullOrEmpty(apellido))
            {
                DisplayAlert("Abrir", "Falta Completar el Apellido", "Cerrar");
            }
            if (edad == DateTime.MinValue && edad == null)
            {
                DisplayAlert("Abrir", "Falta Completar la Edad", "Cerrar");
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
            if (string.IsNullOrEmpty(empresa) && txtEmpresa.IsVisible == true)
            {
                await DisplayAlert("Abrir", "Falta Completar la Empresa", "Cerrar");
            }

            if (pUsuarios.SelectedIndex == 1)
            {
                TecnicoModelo tecnico = new TecnicoModelo();
                tecnico.nombretec = nombre;
                tecnico.apellidotec = apellido;
                tecnico.edadtecn = edad;
                tecnico.generotecn = pGenero.Items[pGenero.SelectedIndex];
                tecnico.telefonotec = telefono;
                tecnico.cedulatec = cedula;
                tecnico.ciudadtec = ciudad;
                tecnico.empresatec = empresa;
                tecnico.roletec = pUsuarios.Items[pUsuarios.SelectedIndex];

                var guardartec = await guardarTecn.GuardarTecnico(tecnico);
                if (guardartec)
                {
                    await DisplayAlert("Información", "Registro guardado correctamente", "Cerrar");
                }
                else
                {
                    await DisplayAlert("Error", "El registro no se guardo correctamente", "Cerrar");

                }


            }
            else
            {
                UsuarioModelo usuario = new UsuarioModelo();
                usuario.nombreuser = nombre;
                usuario.apellidouser = apellido;
                usuario.edaduser = edad;
                usuario.generouser = pGenero.Items[pGenero.SelectedIndex];
                usuario.cedulauser = cedula;
                usuario.telefonouser = telefono;
                usuario.ciudaduser = ciudad;
                usuario.roleuser = pUsuarios.Items[pUsuarios.SelectedIndex];

                var guardar = await usuariodb.GuardarUsuario(usuario);
                if (guardar)
                {
                    await DisplayAlert("Información", "Registro guardado correctamente", "Cerrar");
                }
                else
                {
                    await DisplayAlert("Error", "El registro no se guardo correctamente", "Cerrar");

                }

            }
        }

        private void pGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}