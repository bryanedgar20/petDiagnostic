using Java.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace petDiagnostic.ObjetosVO
{
    public class Mascota
    {
        private int idMascota;
        private string nombre;
        private Date fechaNacimiento;
        private string contextura;
        private string descripcion;
        private string colorPelaje;

        private string estado;
        private Date fechaRegistro;

        public int IdMascota { get => idMascota; set => idMascota = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Date FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Contextura { get => contextura; set => contextura = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string ColorPelaje { get => colorPelaje; set => colorPelaje = value; }
        public string Estado { get => estado; set => estado = value; }
        public Date FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
    }
}
