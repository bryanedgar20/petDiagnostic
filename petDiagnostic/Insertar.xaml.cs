using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace petDiagnostic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insertar : ContentPage
    {
        public Insertar()
        {
            InitializeComponent();
        }

        private async void btbInsertar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                string url = "http://192.168.100.21/ws_uisrael/post.php";
                var parametros = new NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);

                client.UploadValues(url, "POST", parametros);
                await DisplayAlert("Alerta", "Datos ingresados correctamente", "Aceptar");
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {

                await DisplayAlert("Error","Detalle:"+ex.Message, "Aceptar");
            }
        }
    }
}