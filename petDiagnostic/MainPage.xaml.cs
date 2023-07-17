using Android.Database;
using Java.Util;
using Newtonsoft.Json;
using petDiagnostic.ObjetosVO;
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
        
        private HttpClient client = new HttpClient();
        //private ObservableCollection<petDiagnostic.Datos> _post;
        //private Usuario _posts;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string url = $"http://192.168.56.1:8081/usuario/obtenerUsuarioLogin/{txtUsuario.Text}/{txtClave.Text}";
            var content = await client.GetStringAsync(url);
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(content);
          

            if (null != usuario)
            {

                await Navigation.PushAsync(new MisMascotas(usuario));
            }
            else
            {
                await DisplayAlert("Error", "Credenciales Incorrectas", "Ok");
            }
        }

        private void btbRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MntUsuario());
        }
    }
}
