using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinGrupo3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class RegistroTicket : ContentPage
    {
        MediaFile file;
        //Se usa para acceder a la clase TicketsDB 
        //Se inicializa como nueva instancia(objeto de una clase especifica)
        TicketsDB Guardtickets = new TicketsDB();
        public RegistroTicket()
        {
            InitializeComponent();
        }

        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            TicketModelo ticket = new TicketModelo();

            string nombre=txtNombreTicket.Text;
            string direccion = txtDireccion.Text;
            string detalletck = txtdetck.Text;
            DateTime fechatck = dpFecha.Date;
            string actrlz = txtAct.Text;
            string detallesol = txtDetSol.Text;
            string marca = txtMarca.Text;
            string modelo = txtModelo.Text;
            string serie = txtSerie.Text;

            if(string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(direccion) || string.IsNullOrEmpty(detalletck) || fechatck==DateTime.MinValue ||fechatck==null || string.IsNullOrEmpty(actrlz) || string.IsNullOrEmpty(detallesol) || string.IsNullOrEmpty(marca) || string.IsNullOrEmpty(modelo) || string.IsNullOrEmpty(serie))
            {
                await DisplayAlert("Abrir", "Complete toda la Información", "Cerrar");
            }
            else
            {
                ticket.NombreTick = nombre;
                ticket.direcciontick= direccion;
                ticket.detalletick=detalletck;
                ticket.marca = marca;
                ticket.modelo = modelo;
                ticket.serie = serie;
                ticket.detsolucion = detallesol;
                ticket.fecha = fechatck;
                ticket.actsolucion = actrlz;

                if (file != null)
                {
                    string imagen = await Guardtickets.Subir(file.GetStream(), Path.GetFileName(file.Path));
                    ticket.image = imagen;
                }

                var guardar = await Guardtickets.GuardarTicket(ticket);
                if (guardar)
                {
                    await DisplayAlert("Información", "Registro guardado correctamente", "Cerrar");
                }
                else
                {
                    await DisplayAlert("Error", "El registro no se guardo correctamente", "Cerrar");

                }
              
            }
            await Navigation.PushAsync(new DetallesTicket());
        }

        private async void btnElegImg_Clicked(object sender, EventArgs e)
        {
            var tomarfoto = await MediaPicker.CapturePhotoAsync();
            var stream = await tomarfoto.OpenReadAsync();
            imgFoto.Source = ImageSource.FromStream(() => stream);
        }

        private async void btnTakeImg_Clicked(object sender, EventArgs e)
        {
            var imagen = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Escoga una foto"

            });
            var stream = await imagen.OpenReadAsync();
            imgFoto.Source = ImageSource.FromStream(() => stream);
        }
    }
}