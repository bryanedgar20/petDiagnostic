using Java.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace petDiagnostic.ObjetosVO
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public Date fechaNacimiento { get; set; }
        public string identificacion { get; set; }
        public string email { get; set; }
        public string numeroTelefono { get; set; }
        public string callePrincipal { get; set; }
        public string calleSecundaria { get; set; }
        public string nickName { get; set; }
        public string clave { get; set; }
        public string estado { get; set; }
        public Date fechaRegistro { get; set; }

        public List<Mascota> listaMascotas { get; set; }
    }
}
