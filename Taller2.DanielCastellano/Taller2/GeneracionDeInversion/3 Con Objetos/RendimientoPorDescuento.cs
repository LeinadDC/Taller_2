using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.Objetos
{
    public class RendimientoPorDescuento
    {
        decimal Rendimiento;

        public RendimientoPorDescuento(decimal ValorFacial, decimal ValorTransadoBruto)
        {
            Rendimiento = CalculeRendimientoPorDescuento(ValorFacial, ValorTransadoBruto);

        }

        private static decimal CalculeRendimientoPorDescuento(decimal ValorFacial, decimal ValorTransadoBruto)
        {
            return (ValorFacial - ValorTransadoBruto);
        }

        public decimal ComoNumero()
        {
            return Math.Round(Rendimiento, 4);
        }
    }
}
