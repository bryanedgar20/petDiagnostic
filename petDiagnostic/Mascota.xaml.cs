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
    public partial class Mascota : ContentPage
    {
        public Mascota()
        {
            InitializeComponent();
            List<Consulta> items = new List<Consulta>
            {
                new Consulta { Fecha = "2021-04-04", Texto = "Dolor Abdominal" },
                new Consulta { Fecha = "2022-05-23", Texto = "Dolor Abdominal" },
                new Consulta { Fecha = "2023-01-01", Texto = "Dolor Abdominal" }
            };

            myListView.ItemsSource = items;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarConsulta());
        }
    }
}

public class Consulta
{
    public string Fecha { get; set; }
    public string Texto { get; set; }
}