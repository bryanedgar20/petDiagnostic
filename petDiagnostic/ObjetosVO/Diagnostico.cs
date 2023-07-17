using Java.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace petDiagnostic.ObjetosVO
{
    public class Diagnostico
    {
        public int idDiagnostico { get; set; }
        public Date fechaDiagnostico { get; set; }
        public string tratamiento { get; set; }
        public string causasEnfermedad { get; set; }
        public string informacionAdicional { get; set; }
        public string duracionTratamiento { get; set; }
        public string medicamentosRecetados { get; set; }
    }
}
