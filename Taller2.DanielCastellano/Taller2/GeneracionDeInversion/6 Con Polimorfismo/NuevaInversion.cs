using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.Poliformismo
{
    public class NuevaInversion
    {

        public NuevaInversion(DatosDeImpuesto losDatos)
        {
            FechaDeValor = losDatos.FechaActual;

            FechaDeVencimiento = CalculeFechaDeVencimiento(losDatos);

            TasaBruta = ObtengaTasaBruta(losDatos);

            ValorTransadoBruto = losDatos.ValorTransadoBruto;

            ImpuestoPagado = ObtengaImpuestoPagado(losDatos);

            RendimientoPorDescuento = ObtengaRendimientoPorDescuento(losDatos);
        }


        private DateTime CalculeFechaDeVencimiento(DatosDeImpuesto losDatos)
        {
            return losDatos.FechaDeVencimiento;
        }

        private decimal ObtengaTasaBruta(DatosDeImpuesto losDatos)
        {
            return new TasaBruta(losDatos).ComoNumero();
        }

        private decimal ObtengaImpuestoPagado(DatosDeImpuesto losDatos)
        {
            return new ImpuestoPagado(losDatos).ComoNumero();
        }

        private decimal ObtengaRendimientoPorDescuento(DatosDeImpuesto losDatos)
        {
            return new RendimientoPorDescuento(losDatos).ComoNumero();
        }

        public decimal TasaBruta { get; set; }
        public decimal ValorTransadoBruto { get; set; }
        public decimal ImpuestoPagado { get; set; }
        public decimal RendimientoPorDescuento { get; set; }
        public DateTime FechaDeValor { get; set; }
        public DateTime FechaDeVencimiento { get; set; }

    }

}


