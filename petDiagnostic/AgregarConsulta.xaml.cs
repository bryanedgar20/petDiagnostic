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
    public partial class AgregarConsulta : ContentPage
    {
        private HttpClient client = new HttpClient();
        public AgregarConsulta(ObjetosVO.Mascota mascotaVO)
        {
            InitializeComponent();
            List<Sintoma> listSintomas = ObtenerSintomaPorEspecie(mascotaVO.especieMascota.idEspecieMascota);
            listViewSintomas.ItemsSource = listSintomas;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DatePicker datePicker = (DatePicker)FindByName("datePicker");
            datePicker.Focus();
        }

        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            Entry dateEntry = (Entry)FindByName("dateEntry");
            dateEntry.Text = e.NewDate.ToString("d");
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

        }
    }
}