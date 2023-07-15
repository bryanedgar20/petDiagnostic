using Java.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace petDiagnostic.ObjetosVO
{
    public class Diagnostico
    {
        private int idDiagnostico;
        private Date fechaDiagnostico;
        private string tratamiento;
        private string causasEnfermedad;
        private string informacionAdicional;
        private string duracionTratamiento;
        private string medicamentosRecetados;

        public int IdDiagnostico { get => idDiagnostico; set => idDiagnostico = value; }
        public Date FechaDiagnostico { get => fechaDiagnostico; set => fechaDiagnostico = value; }
        public string Tratamiento { get => tratamiento; set => tratamiento = value; }
        public string CausasEnfermedad { get => causasEnfermedad; set => causasEnfermedad = value; }
        public string InformacionAdicional { get => informacionAdicional; set => informacionAdicional = value; }
        public string DuracionTratamiento { get => duracionTratamiento; set => duracionTratamiento = value; }
        public string MedicamentosRecetados { get => medicamentosRecetados; set => medicamentosRecetados = value; }
    }
}
