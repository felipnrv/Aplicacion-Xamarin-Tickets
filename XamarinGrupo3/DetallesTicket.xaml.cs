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
    public partial class DetallesTicket : ContentPage
    {
        TicketsDB ticketmodelo = new TicketsDB();
        public DetallesTicket()
        {
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            var tecnico = await ticketmodelo.GetAll();
            TicketLista.ItemsSource= null;
            TicketLista.ItemsSource = tecnico;
        }

        private void AddNuevoTicket_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroTicket());
        }

        private void TicketLista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(e.Item==null)
            {
                return;
            }
            var ticket = e.Item as TicketModelo;
            Navigation.PushAsync(new DetallesCompletos(ticket));
            ((ListView)sender).SelectedItem = null;
        }

        private async void TapEditar_Tapped(object sender, EventArgs e)
        {
            string id = ((TappedEventArgs)e).Parameter.ToString();
            var ticket=await ticketmodelo.GetById(id);
            if (ticket == null)
            {
                await DisplayAlert("Alerta", "Datos no encontrados", "Cerrar");

            }
            ticket.IdTicket= id;
            await Navigation.PushModalAsync(new RegistroTicketEditar(ticket));
        }

        private async void TapBorrar_Tapped(object sender, EventArgs e)
        {
            string id = ((TappedEventArgs)e).Parameter.ToString();
            bool isDelete = await ticketmodelo.Borrar(id);
            if(isDelete)
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