using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.Objetos
{
    public class TasaBruta
    {
        decimal TasaNeta;
        decimal TasaDeImpuesto;

        public TasaBruta(decimal ValorTransadoNeto, decimal ValorFacial, decimal TasaDeImpuesto, DateTime FechaActual, int PlazoEnDias)
        {

            TasaNeta = DetermineTasaNeta(ValorTransadoNeto, ValorFacial, FechaActual, PlazoEnDias);
            this.TasaDeImpuesto = TasaDeImpuesto;
        }

        private static decimal DetermineTasaNeta(decimal ValorTransadoNeto, decimal ValorFacial, DateTime FechaActual, int PlazoEnDias)
        {
            if (DateTime.IsLeapYear(FechaActual.Year))
            {
                return (ValorFacial - ValorTransadoNeto) / (ValorTransadoNeto * ((decimal)PlazoEnDias / 366)) * 100;

            }
            else
            {
                return (ValorFacial - ValorTransadoNeto) / (ValorTransadoNeto * ((decimal)PlazoEnDias / 365)) * 100;
            }

        }

        public decimal ComoNumero()
        {
            return TasaNeta / (1 - TasaDeImpuesto);
        }
    }

}
