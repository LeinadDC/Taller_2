using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.Poliformismo
{
    public class RendimientoPorDescuento
    {
        decimal RendimientoSinRedondear;

        public RendimientoPorDescuento(DatosDeImpuesto losDatos)
        {
            RendimientoSinRedondear = CalculeRendimiento(losDatos);
        }

        private static decimal CalculeRendimiento(DatosDeImpuesto losDatos)
        {
            return (losDatos.ValorFacial - losDatos.ValorTransadoBruto);
        }

        public decimal ComoNumero()
        {
            return Math.Round(RendimientoSinRedondear, 4);
        }
    }
}
