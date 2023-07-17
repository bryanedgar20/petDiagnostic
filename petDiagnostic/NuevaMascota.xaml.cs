using Newtonsoft.Json;
using petDiagnostic.ObjetosVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace petDiagnostic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevaMascota : ContentPage
    {
        private HttpClient client = new HttpClient();
        EspecieMascota especieMascota = new EspecieMascota();
        Usuario usuarioGlobal = new Usuario();
        public NuevaMascota(Usuario usuario)
        {
            InitializeComponent();
            usuarioGlobal = usuario;
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            //try
            //{
                WebClient client = new WebClient();
                string url = "http://192.168.56.1:8081/mascota/crearActualizarMascota";

                ObjetosVO.Mascota mascota = new ObjetosVO.Mascota();

                mascota.nombre = txtNombre.Text;
                mascota.peso = Double.Parse(txtPeso.Text);
                mascota.razaMascota = (RazaMascota) pickerRaza.SelectedItem;
                mascota.colorPelaje = txtColor.Text;
                mascota.descripcion = txtInfoGeneral.Text;
                mascota.especieMascota = especieMascota;
                //mascota.fechaNacimiento = dateFechaNacimiento;
                 mascota.usuario = usuarioGlobal;



                string jsonData = JsonConvert.SerializeObject(mascota);
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                Console.WriteLine(jsonData);
                string response = client.UploadString(url, "POST", jsonData);
                Navigation.PushAsync(new MisMascotas(usuarioGlobal));
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

        }

        private async void tapGato_Tapped(object sender, EventArgs e)
        {
            Label lblGato = (Label)FindByName("lblGato");
            lblGato.FontAttributes = FontAttributes.Bold;
            Label lblPerro = (Label)FindByName("lblPerro");
            lblPerro.FontAttributes = FontAttributes.None;

            string url = $"http://192.168.56.1:8081/raza/obtenerRazaPorEspecie/2";
            var content = await client.GetStringAsync(url);
            List<RazaMascota> listRaza = JsonConvert.DeserializeObject<List<RazaMascota>>(content);

            pickerRaza.ItemsSource = listRaza;
            pickerRaza.ItemDisplayBinding = new Binding("nombre");

            especieMascota.idEspecieMascota =2;
        }

        private async void tapPerro_Tapped(object sender, EventArgs e)
        {
            Label lblGato = (Label)FindByName("lblGato");
            lblGato.FontAttributes = FontAttributes.Bold;
            Label lblPerro = (Label)FindByName("lblPerro");
            lblPerro.FontAttributes = FontAttributes.None;

            string url = $"http://192.168.56.1:8081/raza/obtenerRazaPorEspecie/1";
            var content = await client.GetStringAsync(url);
            List<RazaMascota> listRaza = JsonConvert.DeserializeObject<List<RazaMascota>>(content);

            pickerRaza.ItemsSource = listRaza;
            pickerRaza.ItemDisplayBinding = new Binding("nombre");
            especieMascota.idEspecieMascota = 1;
        }
    }
}