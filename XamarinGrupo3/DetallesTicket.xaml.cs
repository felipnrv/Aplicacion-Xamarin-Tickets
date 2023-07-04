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
            TicketLista.ItemsSource= tecnico;
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
    }
}