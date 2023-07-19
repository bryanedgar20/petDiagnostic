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

        public string fechaDiagnosticoStr { get; set; }

        public string lblInformacion { get; set; }

        public string lblFechaRegistro { get; set; }

        public Mascota mascota { get; set; }

        public List<Sintoma> sintomasDiagnostico { get; set; }
    }
}
