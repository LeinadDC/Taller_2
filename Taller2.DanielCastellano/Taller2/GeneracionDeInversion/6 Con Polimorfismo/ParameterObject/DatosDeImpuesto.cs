using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.PolimorfismoYHerencia
{
    public abstract class DatosDeImpuesto : DatosDeLaInversion
    {
        public abstract decimal ValorTransadoBruto { get; }

        public abstract decimal ImpuestoPagado { get; }

        public decimal Rendimiento { get { return (ValorFacial - ValorTransadoBruto); } }
    }
}
