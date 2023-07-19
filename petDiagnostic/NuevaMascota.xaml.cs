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
        private Boolean selectPerro = false;
        private Boolean selectGato = false;
        public NuevaMascota(Usuario usuario)
        {
            InitializeComponent();
            usuarioGlobal = usuario;
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            //try
            //{
                List<string> errores = this.validarCamposRequeridos();
                if (errores.Count == 0) {
                    WebClient client = new WebClient();
                    string url = "http://192.168.56.1:8081/mascota/crearActualizarMascota";
                    ObjetosVO.Mascota mascota = new ObjetosVO.Mascota();
                    mascota.nombre = txtNombre.Text;
                    mascota.peso = Double.Parse(txtPeso.Text);
                    mascota.razaMascota = (RazaMascota)pickerRaza.SelectedItem;
                    mascota.colorPelaje = txtColor.Text;
                    mascota.descripcion = txtInfoGeneral.Text;
                    mascota.especieMascota = especieMascota;
                    mascota.genero = pickerGenero.SelectedItem as string;
                    mascota.fechaNacimientoStr = dateFechaNacimiento.Date.ToString("dd/MM/yyyy");
                    mascota.usuario = usuarioGlobal;
                    string jsonData = JsonConvert.SerializeObject(mascota);
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    Console.WriteLine(jsonData);
                    string response = client.UploadString(url, "POST", jsonData);
                    Navigation.PushAsync(new MisMascotas(usuarioGlobal));
                }
                else
                {
                    string lblMensaje = "Los siguientes campos son requeridos: \n" + String.Join("\n",errores);
                    DisplayAlert("Advertencia!", lblMensaje, "Ok");
                }
            //}catch (Exception)
            //{
            //    throw;
            //}

        }

        private List<string> validarCamposRequeridos()
        {
            List<string> errores = new List<string>();

            if (this.selectGato == false && this.selectPerro == false)
            {
                errores.Add("-Especie");
            }

            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                errores.Add("-Nombre");
            }

            if (String.IsNullOrEmpty(dateFechaNacimiento.Date.ToString("dd/MM/yyyy")))
            {
                errores.Add("-Fecha, nacimiento");
            }

            if (String.IsNullOrEmpty(pickerGenero.SelectedItem as string ))
            {
                errores.Add("-Género");
            }

            if (null == (RazaMascota)pickerRaza.SelectedItem)
            {
                errores.Add("-Raza");
            }

            if (String.IsNullOrEmpty(txtColor.Text))
            {
                errores.Add("-Color pelaje");
            }

            if (String.IsNullOrEmpty(txtPeso.Text))
            {
                errores.Add("-Peso");
            }

            if (String.IsNullOrEmpty(txtInfoGeneral.Text))
            {
                errores.Add("-Información adicional");
            }
            return errores;
        }


        private async void tapGato_Tapped(object sender, EventArgs e)
        {
            this.selectGato = true;
            this.selectPerro = false;

            Label lblGato = (Label)FindByName("lblGato");
            lblGato.FontAttributes = FontAttributes.Bold;
            lblGato.TextColor = Color.Red;
            lblGato.FontSize = 25;

            Label lblPerro = (Label)FindByName("lblPerro");
            lblPerro.FontAttributes = FontAttributes.None;
            lblPerro.TextColor = Color.Default;
            lblPerro.FontSize = 20;

            string url = $"http://192.168.56.1:8081/raza/obtenerRazaPorEspecie/2";
            var content = await client.GetStringAsync(url);
            List<RazaMascota> listRaza = JsonConvert.DeserializeObject<List<RazaMascota>>(content);

            pickerRaza.ItemsSource = listRaza;
            pickerRaza.ItemDisplayBinding = new Binding("nombre");
            especieMascota.idEspecieMascota =2;
        }

        private async void tapPerro_Tapped(object sender, EventArgs e)
        {
            this.selectPerro = true;
            this.selectGato = false;

            Label lblPerro = (Label)FindByName("lblPerro");
            lblPerro.FontAttributes = FontAttributes.Bold;
            lblPerro.TextColor = Color.Red;
            lblPerro.FontSize = 25;

            Label lblGato = (Label)FindByName("lblGato");
            lblGato.FontAttributes = FontAttributes.None;
            lblGato.TextColor = Color.Default;
            lblGato.FontSize = 20;

            string url = $"http://192.168.56.1:8081/raza/obtenerRazaPorEspecie/1";
            var content = await client.GetStringAsync(url);
            List<RazaMascota> listRaza = JsonConvert.DeserializeObject<List<RazaMascota>>(content);

            pickerRaza.ItemsSource = listRaza;
            pickerRaza.ItemDisplayBinding = new Binding("nombre");
            especieMascota.idEspecieMascota = 1;
        }
    }
}