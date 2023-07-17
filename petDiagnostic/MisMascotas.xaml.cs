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
            usuarioGlobal = usuario;
            lblNombreUsuario.Text = usuario.primerNombre.Trim()+ " "+ usuario.primerApellido.Trim();

            List<ObjetosVO.Mascota> mascotas = ObtenerMascotaPorUsuario(usuario);

            mascotas.ForEach(pet =>
            {
                pet.lblInformacion =pet.especieMascota.nombre +"-"+ pet.nombre +"-"+ pet.razaMascota.nombre;
                pet.imagen = "huella.png";

            });

            

            myListView.ItemsSource = mascotas;
        }

        private async void myListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ObjetosVO.Mascota selectMascota = (ObjetosVO.Mascota)e.Item;
            await Navigation.PushAsync(new MntMascota(selectMascota));
            
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NuevaMascota(usuarioGlobal));
        }

        private List<ObjetosVO.Mascota> ObtenerMascotaPorUsuario(Usuario usuario)
        {
            string url = $"http://192.168.56.1:8081/mascota/obtenerMascotaPorIdusuario/{usuario.idUsuario}";
            var contentTask = client.GetStringAsync(url);
            string content = contentTask.Result;
            List<ObjetosVO.Mascota> listMascota = JsonConvert.DeserializeObject<List<ObjetosVO.Mascota>>(content);
            return listMascota;
        }
    }
}

public class Item
{
    public string Imagen { get; set; }
    public string Texto { get; set; }
}