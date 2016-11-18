using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.TellDontAsk
{
    public class RendimientoPorDescuento
    {
        decimal RendimientoSinRedondear;

        public RendimientoPorDescuento(DatosDeRendimiento losDatos)
        {
            RendimientoSinRedondear = CalculeRendimiento(losDatos);
        }

        private static decimal CalculeRendimiento(DatosDeRendimiento losDatos)
        {
            return (losDatos.ValorFacial - losDatos.ValorTransadoBruto);
        }

        public decimal ComoNumero()
        {
            return Math.Round(RendimientoSinRedondear, 4);
        }
    }
}
