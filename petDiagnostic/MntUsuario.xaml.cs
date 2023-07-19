using Java.Util;
using Newtonsoft.Json;
using petDiagnostic.ObjetosVO;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace petDiagnostic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MntUsuario : ContentPage
    {
        public MntUsuario()
        {
            InitializeComponent();
        }

        private void btbGuardar_Clicked(object sender, EventArgs e)
        {
            var errors = this.validarCamposrequeridos();

            if (null != errors && errors.Count == 0)
            {
                WebClient client = new WebClient();
                string url = "http://192.168.56.1:8081/usuario/crearActualizarUsuario";

                Usuario usuario = new Usuario();
                usuario.primerNombre = txtPrimerNombre.Text.Trim();
                usuario.primerApellido = txtPrimerApellido.Text.Trim();
                usuario.segundoNombre = txtSegundoNombre.Text;
                usuario.segundoApellido = txtSegundoApellido.Text;

                //usuario.FechaNacimiento = (Date)Date.Parse(dateFechaNacimiento.Date.ToString("dd/MM/yyyy"));
                usuario.identificacion = txtIdentificacion.Text.Trim();
                usuario.email = txtEmail.Text.Trim();
                usuario.numeroTelefono = txtNroContacto.Text.Trim();
                usuario.callePrincipal = txtCallePrincipal.Text.Trim();
                usuario.calleSecundaria = txtCalleSecundaria.Text;
                usuario.nickName = txtNickName.Text.Trim();
                usuario.clave = txtClave.Text.Trim();


                string jsonData = JsonConvert.SerializeObject(usuario);
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                string response = client.UploadString(url, "POST", jsonData);

                DisplayAlert("Exito", "Usuario creado exitosamente.\n" +
                    "Ingrese a la aplicacion con las credenciales creadas", "Aceptar");
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                var mensajeError = " Revise que los siguientes tengan informacion: "+ String.Join(",\n", errors);
                DisplayAlert("Advertencia!",mensajeError, "Ok");
            }

        }

        private List<String> validarCamposrequeridos()
        {
            List<String> errores = new List<string>();

            if (String.IsNullOrWhiteSpace(txtPrimerNombre.Text))
            {
                errores.Add("-Primer nombre");
            }
            if (String.IsNullOrWhiteSpace(txtPrimerApellido.Text))
            {
                errores.Add("-Primer apellido");
            }
            if (String.IsNullOrWhiteSpace(dateFechaNacimiento.Date.ToString()))
            {
                errores.Add("-Fecha, nacimiento");
            }
            if (String.IsNullOrWhiteSpace(txtIdentificacion.Text))
            {
                errores.Add("-Nro. identificación");
            }
            if (String.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errores.Add("-Correo electrónico");
            }
            if (String.IsNullOrWhiteSpace(txtNroContacto.Text))
            {
                errores.Add("-Nro. Teléfono");
            }
            if (String.IsNullOrWhiteSpace(txtCallePrincipal.Text))
            {
                errores.Add("-Calle principal");
            }
            if (String.IsNullOrWhiteSpace(txtNickName.Text))
            {
                errores.Add("-Usuario");
            }

            if (String.IsNullOrWhiteSpace(txtClave.Text))
            {
                errores.Add("-Clave");
            }


            if (txtClave.Text != txtClaveConfirmar.Text)
            {
                errores.Add("-Las claves deben coincidir");
            }
            return errores;
        }
    }
}