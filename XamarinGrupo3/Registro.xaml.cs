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
                lblEmpresa.IsVisible = true;
                fEmpresa.IsVisible = true;
                fEmpresa.ForceLayout();
              
                
            }
            else
            {
               
                txtEmpresa.IsVisible = false;
                lblEmpresa.IsVisible = false;
                fEmpresa.IsVisible = false;
                fEmpresa.ForceLayout();




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
            string contrasena = txtContrasena.Text;

            if (pUsuarios.SelectedIndex == 1)
            {
                TecnicoModelo tecnico = new TecnicoModelo();
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || edad == DateTime.MinValue || edad == null || string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(ciudad) || string.IsNullOrEmpty(empresa))
                {
                   await DisplayAlert("Error", "Complete toda la Información", "Cerrar");
                }
                else
                { 
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
                    await Navigation.PushAsync(new DetallesUsuario());
                    }
                  else
                    {
                    await DisplayAlert("Error", "El registro no se guardo correctamente", "Cerrar");
                    await Navigation.PushAsync(new DetallesUsuario());
                    }

                }
            }
            else
            {
                UsuarioModelo usuario = new UsuarioModelo();
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || edad == DateTime.MinValue || edad == null || string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(ciudad))
                {
                    await DisplayAlert("Abrir", "Complete toda la Información", "Cerrar");
                }
                else
                {
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
                    await Navigation.PushAsync(new DetallesUsuario());
                }
                else
                {
                    await DisplayAlert("Error", "El registro no se guardo correctamente", "Cerrar");
                    await Navigation.PushAsync(new DetallesUsuario());
                    }
                }
            }
           await Navigation.PushAsync(new Login(nombre, contrasena));

        }

        private void pGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


    }
}