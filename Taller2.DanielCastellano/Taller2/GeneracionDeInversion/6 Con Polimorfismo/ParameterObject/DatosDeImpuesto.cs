using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.Poliformismo
{
    public abstract class DatosDeImpuesto : DatosDeLaInversion
    {
        public abstract decimal ValorTransadoBruto { get; }

        public abstract decimal ImpuestoPagado { get; }
    }
}
