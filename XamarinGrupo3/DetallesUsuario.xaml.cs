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
    public partial class DetallesUsuario : ContentPage
    {
        UsuarioDB usuarioDB = new UsuarioDB();
        public DetallesUsuario()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            //se obtiene el metodo
            var tecnico = await usuarioDB.GetAll();
            //Vacia la lista
            UsuarioLista.ItemsSource = null;
            //asigna a la lista los datos
            UsuarioLista.ItemsSource = tecnico;
        }

        private void AddNuevoUsuario_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }

        private void UsuarioLista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }
            //Intentar conversion al modelo,falla es null
            var usuario = e.Item as UsuarioModelo;
            Navigation.PushAsync(new DetalleCompltUser(usuario));
            //Se quita la seleccion del objeto
            ((ListView)sender).SelectedItem = null;
        }

        private async void TapEditar_Tapped(object sender, EventArgs e)
        {
            string id = ((TappedEventArgs)e).Parameter.ToString();
            var usuario = await usuarioDB.GetById(id);
            if (usuario == null)
            {
                await DisplayAlert("Alerta", "Datos no encontrados", "Cerrar");

            }
            usuario.Id = id;
            await Navigation.PushModalAsync(new EditarUser(usuario));
        }

        private async void TapBorrar_Tapped(object sender, EventArgs e)
        {
            string id = ((TappedEventArgs)e).Parameter.ToString();
            bool isDelete = await usuarioDB.Borrar(id);
            if (isDelete)
            {
                await DisplayAlert("Información", "El registro ha sido borrado", "Cerrar");
                OnAppearing();
            }
            else
            {
                await DisplayAlert("Error", "El Registro no se elimino correctamente", "Cerrar");
            }
        }
    }
}