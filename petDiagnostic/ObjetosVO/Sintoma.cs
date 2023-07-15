using Java.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace petDiagnostic.ObjetosVO
{
    public class Sintoma
    {
        private int idSintoma;
        private string nombreSintoma;
        private string descripcion;
        private string gravedad;
        private string duracion;
        private string intensidad;
        private string organoAfecta;

        private string estado;
        private Date fechaRegistro;

        public int IdSintoma { get => idSintoma; set => idSintoma = value; }
        public string NombreSintoma { get => nombreSintoma; set => nombreSintoma = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Gravedad { get => gravedad; set => gravedad = value; }
        public string Duracion { get => duracion; set => duracion = value; }
        public string Intensidad { get => intensidad; set => intensidad = value; }
        public string OrganoAfecta { get => organoAfecta; set => organoAfecta = value; }
        public string Estado { get => estado; set => estado = value; }
        public Date FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
    }
}
