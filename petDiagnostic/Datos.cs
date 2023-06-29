using System;
using System.Collections.Generic;
using System.Text;

namespace petDiagnostic
{
    public class Datos
    {
        private int codigo;
        private string nombre;
        private string apellido;
        private string edad;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Edad { get => edad; set => edad = value; }
    }
}
