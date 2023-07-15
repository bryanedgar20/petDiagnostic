using Java.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace petDiagnostic.ObjetosVO
{
    public class RazaMascota
    {

        private int idTRazaMascota;
        private string nombre;
        private string descripcion;
        private string estado;
        private Date fechaRegistro;

        public int IdTRazaMascota { get => idTRazaMascota; set => idTRazaMascota = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Estado { get => estado; set => estado = value; }
        public Date FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
    }
}
