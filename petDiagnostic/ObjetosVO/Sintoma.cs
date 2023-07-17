using Java.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace petDiagnostic.ObjetosVO
{
    public class Sintoma
    {
        public int idSintoma { get; set; }
        public string nombreSintoma { get; set; }
        public string descripcion { get; set; }
        public string gravedad { get; set; }
        public string duracion { get; set; }
        public string intensidad { get; set; }
        public string organoAfecta { get; set; }

        public string estado { get; set; }
        public Date fechaRegistro { get; set; }
    }
}
