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
                usuario.PrimerNombre = txtPrimerNombre.Text.Trim();
                usuario.PrimerApellido = txtPrimerApellido.Text.Trim();
                usuario.SegundoNombre = txtSegundoNombre.Text;
                usuario.SegundoApellido = txtSegundoApellido.Text;

                //usuario.FechaNacimiento = (Date)Date.Parse(dateFechaNacimiento.Date.ToString("dd/MM/yyyy"));
                usuario.Identificacion = txtIdentificacion.Text.Trim();
                usuario.Email = txtEmail.Text.Trim();
                usuario.NumeroTelefono = txtNroContacto.Text.Trim();
                usuario.CallePrincipal = txtCallePrincipal.Text.Trim();
                usuario.CalleSecundaria = txtCalleSecundaria.Text;
                usuario.NickName = txtNickName.Text.Trim();
                usuario.Clave = txtClave.Text.Trim();


                string jsonData = JsonConvert.SerializeObject(usuario);
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                byte[] response = client.UploadData(url, "POST", Encoding.UTF8.GetBytes(jsonData));
                string responseString = Encoding.UTF8.GetString(response);

                DisplayAlert("Exito", "Usuario creado exitosamente", "Aceptar");

            }
            else
            {
                var mensajeError = "Los siguientes campos son requeridos: "+ String.Join(",\n", errors);
                DisplayAlert("Error",mensajeError, "Ok");
            }

        }

        private List<String> validarCamposrequeridos()
        {
            List<String> errores = new List<string>();

            if (String.IsNullOrWhiteSpace(txtPrimerNombre.Text))
            {
                errores.Add("Primer nombre");
            }
            if (String.IsNullOrWhiteSpace(txtPrimerApellido.Text))
            {
                errores.Add("Primer apellido");
            }
            if (String.IsNullOrWhiteSpace(dateFechaNacimiento.Date.ToString()))
            {
                errores.Add("Fecha nacimiento");
            }
            if (String.IsNullOrWhiteSpace(txtIdentificacion.Text))
            {
                errores.Add("Nro identificacion");
            }
            if (String.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errores.Add("Correo electronico");
            }
            if (String.IsNullOrWhiteSpace(txtNroContacto.Text))
            {
                errores.Add("Nro contacto");
            }
            if (String.IsNullOrWhiteSpace(txtCallePrincipal.Text))
            {
                errores.Add("Calle principal");
            }
            if (String.IsNullOrWhiteSpace(txtNickName.Text))
            {
                errores.Add("Usuario");
            }

            if (String.IsNullOrWhiteSpace(txtClave.Text))
            {
                errores.Add("Clave");
            }

            if (String.IsNullOrWhiteSpace(txtPrimerNombre.Text) &&
                txtClave.Text != txtClaveConfirmar.Text)
            {
                errores.Add("Las claves deben coincidir");
            }
            return errores;
        }
    }
}