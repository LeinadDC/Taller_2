using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.ParameterObject
{
    public class DatosDeLaInversion
    {
        public decimal ValorTransadoNeto { get; set; }
        public decimal ValorFacial { get; set; }
        public decimal TasaDeImpuesto { get; set; }
        public DateTime FechaActual { get; set; }
        public int PlazoEnDias { get; set; }
        public bool TratamientoFiscal { get; set; }
    }
}
