using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.TellDontAsk
{
    public class DatosDeImpuesto
    {
        public decimal ValorTransadoNeto { get; set; }
        public bool TratamientoFiscal { get; set; }
        public decimal ValorTransadoBruto { get; set; }

        public decimal ImpuestoPagado
        {
            get
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
        }
    }
}
