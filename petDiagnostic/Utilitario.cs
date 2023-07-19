using System;
using System.Collections.Generic;
using System.Text;

namespace petDiagnostic
{
    public class Utilitario
    {
        public static string CalcularEdadConMesesYDias(string fechaNacimientoStr)
        {
            Console.WriteLine("FechaIngresad" + fechaNacimientoStr);
            DateTime fechaNacimiento = DateTime.ParseExact(fechaNacimientoStr, "dd/MM/yyyy", null);
            DateTime fechaActual = DateTime.Now;

            TimeSpan tiempoTranscurrido = fechaActual - fechaNacimiento;

            int años = (int)(tiempoTranscurrido.Days / 365.25);
            int meses = (int)((tiempoTranscurrido.Days % 365.25) / 30.44);
            int dias = (int)((tiempoTranscurrido.Days % 365.25) % 30.44);

            return $"{años} años, {meses} meses y {dias} días";
        }
    }
}
