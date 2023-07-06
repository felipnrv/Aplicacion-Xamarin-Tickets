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
    public partial class DetallesCompletos : ContentPage
    {
        public DetallesCompletos(TicketModelo ticket)
        {
            InitializeComponent();
            txtID.Text = ticket.Id;
            txtNombre.Text = ticket.NombreTick;
            txtFecha.Text = ticket.fecha.ToString();
            txtMarca.Text = ticket.marca.ToString();
            txtModelo.Text = ticket.modelo.ToString();
            txtSerie.Text = ticket.serie.ToString();
            txtdirecciontick.Text=ticket.direcciontick;
            detalletick.Text= ticket.detalletick;
            actsolucion.Text=ticket.actsolucion;
            detsolucion.Text = ticket.detsolucion;

        }
    }
}