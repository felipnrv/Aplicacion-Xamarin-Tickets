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
    public partial class DetalleCompltUser : ContentPage
    {
        public DetalleCompltUser(UsuarioModelo usuario)
        {
            InitializeComponent();
            
            txtNombreUser.Text = usuario.nombreuser;
            txtApellido.Text = usuario.apellidouser;
            txtedad.Text = usuario.edaduser.ToString();
            txtgenero.Text = usuario.generouser;
            txtcedula.Text = usuario.cedulauser;
            txtciudad.Text = usuario.ciudaduser;
            txttelefono.Text=usuario.telefonouser;
        }
    }
}