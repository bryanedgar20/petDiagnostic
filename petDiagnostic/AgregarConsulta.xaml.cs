using Java.Text;
using Java.Util;
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
using Xamarin.Forms.Xaml;

namespace petDiagnostic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarConsulta : ContentPage
    {
        private HttpClient client = new HttpClient();
        private Mascota mascotaGlobal = new Mascota();
        private List<Sintoma> listSintomasSelect = new List<Sintoma>();

        public AgregarConsulta(ObjetosVO.Mascota mascotaVO)
        {
            InitializeComponent();

            mascotaGlobal = mascotaVO;
            List<Sintoma> listSintomas = ObtenerSintomaPorEspecie(mascotaVO.especieMascota.idEspecieMascota);
            listViewSintomas.ItemsSource = listSintomas;
            DateTime fechaActual = DateTime.Now;
            dateEntry.Text = fechaActual.ToString("dd/MM/yyyy");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DatePicker datePicker = (DatePicker)FindByName("datePicker");
            datePicker.Focus();
        }

        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            Entry dateEntry = (Entry)FindByName("dateEntry");
            dateEntry.Text = e.NewDate.ToString("dd/MM/yyyy");
            datePicker.IsVisible = false;
        }

        private List<Sintoma> ObtenerSintomaPorEspecie(int idEspecie)
        {
            string url = $"http://192.168.56.1:8081/mascota/obtenerEspecie/{idEspecie}";
            var contentTask = client.GetStringAsync(url);
            string content = contentTask.Result;
            List<ObjetosVO.Sintoma> listSintoma = JsonConvert.DeserializeObject<List<ObjetosVO.Sintoma>>(content);
            return listSintoma;
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            Sintoma item = (Sintoma)checkbox.BindingContext;

            if (checkbox.IsChecked)
            {
                listSintomasSelect.Add(item);
            }
            else
            {
                listSintomasSelect.Remove(item);
            }

        }

        private async void btnDiagnosticar_Clicked(object sender, EventArgs e)
        {
            List<string> errores = this.validarCamposRequeridos();
            if (errores.Count == 0)
            {

                btnDiagnosticar.IsEnabled = false; // Deshabilitar el botón mientras se realiza la llamada al servicio
                btnDiagnosticar.IsVisible = false;
                iconWait.IsVisible = true; // Mostrar el icono de espera

                WebClient clientWS = new WebClient();
                string url = "http://192.168.56.1:8081/diagnostico/crearDiagnostico";
                Diagnostico diagnostico = new Diagnostico();
                diagnostico.sintomasDiagnostico = listSintomasSelect;
                diagnostico.mascota = mascotaGlobal;
                diagnostico.informacionAdicional = txtInfoAdicional.Text;                
                diagnostico.fechaDiagnosticoStr = dateEntry.Text;
                string jsonData = JsonConvert.SerializeObject(diagnostico);
                clientWS.Headers[HttpRequestHeader.ContentType] = "application/json";

                try
                {
                    string response = await clientWS.UploadStringTaskAsync(url, "POST", jsonData);
                    iconWait.IsVisible = false; // Ocultar el icono de espera
                    btnDiagnosticar.IsEnabled = true; // Habilitar el botón después de recibir la respuesta del servicio
                    btnDiagnosticar.IsVisible = true;
                    await DisplayAlert("Diagnóstico", response, "Aceptar");

                    await Navigation.PushAsync(new MntMascota(mascotaGlobal));
                }
                catch (Exception ex)
                {
                    iconWait.IsVisible = false; // Ocultar el icono de espera
                    btnDiagnosticar.IsEnabled = true; // Habilitar el botón en caso de error
                    // Manejar el error según sea necesario
                    await DisplayAlert("Error", "Ocurrió un error al llamar al servicio: " + ex.Message, "Aceptar");
                }
            }
            else
            {
                await DisplayAlert("Error", "Los siguientes campos son requeridos: " + String.Join(",\n",errores), "Aceptar");
            }

            
        }

        private List<string> validarCamposRequeridos()
        {

            List<string> errores = new List<string>();

            if (dateEntry.Text == null)
            {
                errores.Add("Fecha diagnostico");
            }

            if (listSintomasSelect.Count == 0)
            {
                errores.Add("Sintomas");
            }


            return errores;
        }
    }
}