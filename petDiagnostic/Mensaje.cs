using System;
using System.Collections.Generic;
using System.Text;

namespace petDiagnostic
{
    public interface Mensaje
    {
        void longAlert(string mensaje);

        void shortAlert(string mensaje);

    }
}
