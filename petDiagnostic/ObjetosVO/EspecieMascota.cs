using Java.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace petDiagnostic.ObjetosVO
{
    public class EspecieMascota
    {
        private int idEspecieMascota;
        private string nombre;
        private string descripcion;
        private string estado;
        private Date fechaRegistro;

        public int IdEspecieMascota { get => idEspecieMascota; set => idEspecieMascota = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Estado { get => estado; set => estado = value; }
        public Date FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
    }
}
