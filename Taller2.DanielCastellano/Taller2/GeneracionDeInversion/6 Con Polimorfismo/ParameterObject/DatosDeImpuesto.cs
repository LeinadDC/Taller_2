using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.Poliformismo
{
    public class DatosDeImpuesto: DatosDeLaInversion
    {
        public decimal ValorTransadoBruto
        {
            get
            {
                if (TratamientoFiscal)
                {
                    return DetermineValorTransadoBruto(this);
                }
                else
                {
                    return ValorTransadoNeto;
                }
            }
        }

        private decimal DetermineValorTransadoBruto(DatosDeLaInversion losDatos)
        {
            if (DateTime.IsLeapYear(FechaActual.Year))
            {
                return ValorFacial / (1 + ((new TasaBruta(this).ComoNumero()) / 100) * ((decimal)PlazoEnDias / 366));
            }
            else
            {
                return ValorFacial / (1 + ((new TasaBruta(this).ComoNumero()) / 100) * ((decimal)PlazoEnDias / 365));
            }

        }

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
