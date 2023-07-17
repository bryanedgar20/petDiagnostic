using Java.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace petDiagnostic.ObjetosVO
{
    public class Mascota
    {
        public int idMascota { get; set; }
        public string nombre { get; set; }
        public Date fechaNacimiento { get; set; }
        public string contextura { get; set; }
        public string descripcion { get; set; }
        public string colorPelaje { get; set; }
        public Double peso { get; set; }
        public string estado { get; set; }
        public Date fechaRegistro { get; set; }

        public string imagen { get; set; }

        public string lblInformacion { get; set; }
        public Usuario usuario { get; set; }

        public EspecieMascota especieMascota { get; set; }

        public RazaMascota razaMascota { get; set; }



    }
}
