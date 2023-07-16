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
    public partial class Rol : ContentPage
    {
        public Rol()
        {
            InitializeComponent();
        }

        private void pRol_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (pRol.SelectedIndex == 1)
            {

                App.Current.MainPage = new NavigationPage(new DetallesTicket());

            }
            else
            {
                App.Current.MainPage = new NavigationPage(new DetallesUsuario());
            }
        }
    }
}