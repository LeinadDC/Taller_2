using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.Poliformismo
{
    public abstract class DatosDeLaInversion
    {
        public bool TratamientoFiscal { get; set; }
        public int PlazoEnDias { get; set; }
        public DateTime FechaActual { get; set; }
        public decimal TasaDeImpuesto { get; set; }
        public decimal ValorFacial { get; set; }
        public decimal ValorTransadoNeto { get; set; }

        public abstract decimal TasaNeta { get; }

        public DateTime FechaDeVencimiento
        {
            get
            {
                return FechaActual.AddDays(PlazoEnDias);
            }
        }
    }
}


