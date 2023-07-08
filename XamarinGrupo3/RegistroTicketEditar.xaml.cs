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
    public partial class RegistroTicketEditar : ContentPage
    {
        TicketsDB ticketsDB = new TicketsDB();
        public RegistroTicketEditar(TicketModelo ticket)
        {
            InitializeComponent();
            txtNombreTicket.Text = ticket.NombreTick;
            txtDireccion.Text = ticket.direcciontick;
            txtdetck.Text = ticket.detalletick;
            dpFecha.Date = ticket.fecha;
            txtAct.Text = ticket.actsolucion;
            txtDetSol.Text = ticket.detsolucion;
            txtMarca.Text = ticket.marca;
            txtModelo.Text = ticket.modelo;
            txtSerie.Text = ticket.serie;
            txtId.Text = ticket.Id;
        }

        private async void btnEditar_Clicked(object sender, EventArgs e)
        {
            TicketModelo ticket = new TicketModelo();

            string nombre = txtNombreTicket.Text;
            string direccion = txtDireccion.Text;
            string detalletck = txtdetck.Text;
            DateTime fechatck = dpFecha.Date;
            string actrlz = txtAct.Text;
            string detallesol = txtDetSol.Text;
            string marca = txtMarca.Text;
            string modelo = txtModelo.Text;
            string serie = txtSerie.Text;
            string id = txtId.Text;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(direccion) || string.IsNullOrEmpty(detalletck) || fechatck == DateTime.MinValue || fechatck == null || string.IsNullOrEmpty(actrlz) || string.IsNullOrEmpty(detallesol) || string.IsNullOrEmpty(marca) || string.IsNullOrEmpty(modelo) || string.IsNullOrEmpty(serie))
            {
                await DisplayAlert("Abrir", "Complete toda la Información", "Cerrar");
                
            }
            else
            {
                ticket.NombreTick = nombre;
                ticket.direcciontick = direccion;
                ticket.detalletick = detalletck;
                ticket.marca = marca;
                ticket.modelo = modelo;
                ticket.serie = serie;
                ticket.detsolucion = detallesol;
                ticket.fecha = fechatck;
                ticket.actsolucion = actrlz;
                ticket.Id = id;

                bool isUpdate = await ticketsDB.Update(ticket);
                if (isUpdate)
                {
                    await DisplayAlert("Información", "Registro se actualizo correctamente", "Cerrar");
                    await Navigation.PushAsync(new DetallesTicket());
                }
                else
                {
                    await DisplayAlert("Error", "Fallo en la edicion no se guardo correctamente", "Cerrar");

                }

            }
        }
    }
}