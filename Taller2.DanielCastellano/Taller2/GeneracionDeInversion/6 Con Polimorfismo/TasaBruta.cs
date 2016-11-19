using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.PolimorfismoYHerencia
{
    public class TasaBruta
    {
        decimal TasaNeta;
        decimal TasaDeImpuesto;

        public TasaBruta(DatosDeImpuesto losDatos)
        {

            TasaNeta = DetermineTasaNeta(losDatos);
            TasaDeImpuesto = losDatos.TasaDeImpuesto;
        }

        private static decimal DetermineTasaNeta(DatosDeImpuesto losDatos)
        {
            return losDatos.TasaNeta;
        }

        public decimal ComoNumero()
        {
            return TasaNeta / (1 - TasaDeImpuesto);
        }
    }

}
