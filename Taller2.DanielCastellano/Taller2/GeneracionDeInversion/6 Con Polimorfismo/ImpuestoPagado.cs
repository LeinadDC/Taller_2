using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.Poliformismo
{
    public class ImpuestoPagado
    {
        decimal Impuesto;

        public ImpuestoPagado(DatosDeImpuesto losDatos)
        {
            Impuesto = DetermineImpuestoPagado(losDatos);
        }

        private static decimal DetermineImpuestoPagado(DatosDeImpuesto losDatos)
        {
            return losDatos.ImpuestoPagado;
        }

        public decimal ComoNumero()
        {
            return Math.Round(Impuesto, 4);
        }
    }
}
