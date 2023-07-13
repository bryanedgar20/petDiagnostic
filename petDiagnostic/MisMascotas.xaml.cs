using Android.Content.Res;
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
    public partial class MisMascotas : ContentPage
    {
        public MisMascotas()
        {
            InitializeComponent(); 
            List<Item> items = new List<Item>
            {
                new Item { Imagen = "huella.png", Texto = "Elemento 1" },
                new Item { Imagen = "huella.png", Texto = "Elemento 1" },
                new Item { Imagen = "huella.png", Texto = "Elemento 1" }
            };

            myListView.ItemsSource = items;
        }

        private async void myListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new Mascota());
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NuevaMascota());
        }
    }
}

public class Item
{
    public string Imagen { get; set; }
    public string Texto { get; set; }
}