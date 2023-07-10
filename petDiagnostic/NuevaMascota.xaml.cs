using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace petDiagnostic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevaMascota : ContentPage
    {
        public NuevaMascota()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Label lblGato = (Label)FindByName("lblGato");
            lblGato.FontAttributes = FontAttributes.Bold;
            Label lblPerro = (Label)FindByName("lblPerro");
            lblPerro.FontAttributes = FontAttributes.None;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Label lblGato = (Label)FindByName("lblGato");
            lblGato.FontAttributes = FontAttributes.None;
            Label lblPerro = (Label)FindByName("lblPerro");
            lblPerro.FontAttributes = FontAttributes.Bold;

        }
    }
}