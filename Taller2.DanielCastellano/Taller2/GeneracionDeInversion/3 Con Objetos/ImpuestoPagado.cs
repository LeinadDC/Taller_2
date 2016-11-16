using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.Objetos
{
    public class ImpuestoPagado
    {
        decimal Impuesto;

        public ImpuestoPagado(decimal ValorTransadoNeto, bool TratamientoFiscal, decimal ValorTransadoBruto)
        {
            Impuesto = DetermineImpuestoPagado(ValorTransadoNeto, TratamientoFiscal, ValorTransadoBruto);

        }

        private static decimal DetermineImpuestoPagado(decimal ValorTransadoNeto, bool TratamientoFiscal, decimal ValorTransadoBruto)
        {
            if (TratamientoFiscal)
            {
                return (ValorTransadoNeto - ValorTransadoBruto);

            }
            else
            {
                return 0;
            }
        }

        public decimal ComoNumero()
        {
            return Math.Round(Impuesto, 4);
        }
    }
}
