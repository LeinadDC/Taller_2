using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.Objetos
{
    public class RendimientoPorDescuento
    {
        decimal RendimientoSinRedondear;

        public RendimientoPorDescuento(decimal ValorFacial, decimal ValorTransadoBruto)
        {
            RendimientoSinRedondear = CalculeRendimiento(ValorFacial, ValorTransadoBruto);
        }

        private static decimal CalculeRendimiento(decimal ValorFacial, decimal ValorTransadoBruto)
        {
            return (ValorFacial - ValorTransadoBruto);
        }

        public decimal ComoNumero()
        {
            return Math.Round(RendimientoSinRedondear, 4);
        }
    }
}
