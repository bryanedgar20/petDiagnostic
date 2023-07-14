using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace petDiagnostic
{
    public partial class MainPage : ContentPage
    {
        private const string url = "http://192.168.100.21/ws_uisrael/post.php";
        private HttpClient client = new HttpClient();
        private ObservableCollection<petDiagnostic.Datos> _post;


        public MainPage()
        {
            InitializeComponent();
            this.loadDataStuden();
        }

        private void btnMostrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insertar());

        }

        private async void loadDataStuden(){
         var content = await client.GetStringAsync(url);
        List<petDiagnostic.Datos> listPost = JsonConvert.DeserializeObject<List<petDiagnostic.Datos>>(content);
        _post = new ObservableCollection<petDiagnostic.Datos>(listPost);

            MyListView.ItemsSource = _post;
        }

        private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoEstudiante = (Datos) e.SelectedItem;
            Navigation.PushAsync(new Editar(objetoEstudiante));
        }
    }
}
