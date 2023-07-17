using Android.Content.Res;
using Java.Util;
using Newtonsoft.Json;
using petDiagnostic.ObjetosVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace petDiagnostic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MisMascotas : ContentPage
    {
        Usuario usuarioGlobal = new Usuario();
        private HttpClient client = new HttpClient();
        public MisMascotas(Usuario usuario)
        {
            
            InitializeComponent();
            this.obtenerMascotaPorusuario(usuario);
            usuarioGlobal = usuario;
            lblNombreUsuario.Text = usuario.primerNombre.Trim()+ " "+ usuario.primerApellido.Trim();

            

            //Cargar lista de mascotas del usuario

            List<Item> items = new List<Item>
            {
                new Item { Imagen = "huella.png", Texto = "Elemento 1" },
                new Item { Imagen = "huella.png", Texto = "Elemento 1" },
                new Item { Imagen = "huella.png", Texto = "Elemento 1" }
            };

            Console.WriteLine("ListaMascota:"+ usuario.listaMascotas);
            
            myListView.ItemsSource = usuario.listaMascotas;
        }

        private async void myListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new Mascota());
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NuevaMascota(usuarioGlobal));
        }

        private async void obtenerMascotaPorusuario(Usuario usuario)
        {
            string url = $"http://192.168.56.1:8081/mascota/obtenerMascotaPorIdusuario/{usuario.idUsuario}";
            var content = await client.GetStringAsync(url);
            Console.WriteLine("contentWS:" + content);
            List<ObjetosVO.Mascota> listMascota = JsonConvert.DeserializeObject<List<ObjetosVO.Mascota>>(content);
            Console.WriteLine("RespuestaWS:" + listMascota.Count);
            usuario.listaMascotas = listMascota;
        }
    }
}

public class Item
{
    public string Imagen { get; set; }
    public string Texto { get; set; }
}