using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.PolimorfismoYHerencia
{
    public abstract class DatosDeLaInversion
    {
        public bool TratamientoFiscal { get; set; }
        public int PlazoEnDias { get; set; }
        public DateTime FechaActual { get; set; }
        public decimal TasaDeImpuesto { get; set; }
        public decimal ValorFacial { get; set; }
        public decimal ValorTransadoNeto { get; set; }

        public decimal TasaNeta
        {
            get
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
        }

        public DateTime FechaDeVencimiento
        {
            get
            {
                return FechaActual.AddDays(PlazoEnDias);
            }
        }
    }
}


