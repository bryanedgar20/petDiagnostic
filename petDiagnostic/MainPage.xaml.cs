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
        private const string url = "http://192.168.56.1/ws_uisrael/moviles/post.php";
        private HttpClient client = new HttpClient();
        private ObservableCollection<petDiagnostic.Datos> _post;


        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnMostrar_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(url);
            List<petDiagnostic.Datos> listPost = JsonConvert.DeserializeObject<List<petDiagnostic.Datos>>(content);
            _post = new ObservableCollection<petDiagnostic.Datos>(listPost);

            MyListView.ItemsSource = _post;

        }
    }
}
