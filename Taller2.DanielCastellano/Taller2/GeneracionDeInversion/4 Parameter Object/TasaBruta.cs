using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.ParameterObject
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
            if (DateTime.IsLeapYear(losDatos.FechaActual.Year))
            {
                return (losDatos.ValorFacial - losDatos.ValorTransadoNeto) / (losDatos.ValorTransadoNeto * ((decimal)losDatos.PlazoEnDias / 366)) * 100;

            }
            else
            {
                return (losDatos.ValorFacial - losDatos.ValorTransadoNeto) / (losDatos.ValorTransadoNeto * ((decimal)losDatos.PlazoEnDias / 365)) * 100;
            }

        }

        public decimal ComoNumero()
        {
            return TasaNeta / (1 - TasaDeImpuesto);
        }
    }

}
