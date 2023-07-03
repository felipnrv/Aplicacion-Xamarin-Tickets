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
        public DetallesTicket()
        {
            InitializeComponent();
        }

        private void AddNuevoTicket_Clicked(object sender, EventArgs e)
        {

        }

        private void TicketsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}