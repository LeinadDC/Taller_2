using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.TellDontAsk
{
    public class TasaBruta
    {
        decimal TasaNeta;
        decimal TasaDeImpuesto;

        public TasaBruta(DatosDeLaInversion losDatos)
        {

            TasaNeta = DetermineTasaNeta(losDatos);
            TasaDeImpuesto = losDatos.TasaDeImpuesto;
        }

        private static decimal DetermineTasaNeta(DatosDeLaInversion losDatos)
        {
            return losDatos.TasaNeta;
        }

        public decimal ComoNumero()
        {
            return TasaNeta / (1 - TasaDeImpuesto);
        }
    }

}
