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
    public partial class MntMascota : ContentPage
    {
        private HttpClient client = new HttpClient();
        ObjetosVO.Mascota mascotaGlobal = new ObjetosVO.Mascota();
        public MntMascota(ObjetosVO.Mascota mascotaVO)
        {
            InitializeComponent();
            List<Diagnostico> listDiagnostic = ObtenerDiagnosticoPorMascota(mascotaVO.idMascota);
            mascotaGlobal = mascotaVO;
            txtNombre.Text = mascotaVO.nombre;
            txtGenero.Text = mascotaVO.genero;
            txtEspecie.Text = mascotaVO.especieMascota.nombre;
            txtRaza.Text = mascotaVO.razaMascota.nombre;
            txtEdad.Text = "Edad: " + Utilitario.CalcularEdadConMesesYDias(mascotaVO.fechaNacimientoStr);
            txtColorPelaje.Text = mascotaVO.colorPelaje;
            txtInformacion.Text = mascotaVO.descripcion;
            txtAlergias.Text = mascotaVO.alergias;

            if (mascotaVO.especieMascota.idEspecieMascota ==1)
            {
                imgProfile.Source = "dogHeader.png";
            }
            else
            {
                imgProfile.Source = "catHeader.png";
            }


            txtPeso.Text = mascotaVO.peso.ToString() + " Kg.";

            listDiagnostic.ForEach(item =>
            {
                item.lblFechaRegistro = (string)Optional.OfNullable(item.fechaDiagnosticoStr).OrElse("-");
                item.lblInformacion = item.tratamiento.Trim();
            });
            myListView.ItemsSource = listDiagnostic;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarConsulta(mascotaGlobal));
        }

        private List<ObjetosVO.Diagnostico> ObtenerDiagnosticoPorMascota(int idmascota)
        {
            string url = $"http://192.168.56.1:8081/diagnostico/obtenerDiagnosticoPorMascota/{idmascota}";
            var contentTask = client.GetStringAsync(url);
            string content = contentTask.Result;
            List<Diagnostico> listDiagnostico = JsonConvert.DeserializeObject<List<Diagnostico>>(content);
            return listDiagnostico;
        }

        private void myListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Diagnostico selectDiagnostico = (Diagnostico)e.Item;

            string strDiagnostico = "Los síntomas son los siguientes: " + String.Join(",",
                selectDiagnostico.sintomasDiagnostico.Select(value=>value.nombreSintoma).ToList())
                + "\n La información adicional es la siguiente: " + selectDiagnostico.informacionAdicional + " "
                + "\n El Diagnóstico es el siguiente: " + selectDiagnostico.tratamiento + "\n";

            DisplayAlert("Diagnostico", strDiagnostico, "Aceptar");

        }
    }
}
