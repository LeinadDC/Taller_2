using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.TellDontAsk
{
    public class NuevaInversion
    {
        DateTime laFechaDeVencimiento;
        decimal laTasaBruta;
        decimal elImpuestoPagado;
        decimal elRendimientoPorDescuento;
        DatosDeImpuesto losDatosDeImpuesto;
        DatosDeRendimiento losDatosDeRendimiento;

        public NuevaInversion(DatosDeLaInversion losDatos)
        {
            FechaDeValor = losDatos.FechaActual;

            laFechaDeVencimiento = CalculeFechaDeVencimiento(losDatos);
            FechaDeVencimiento = laFechaDeVencimiento;

            laTasaBruta = ObtengaTasaBruta(losDatos);
            TasaBruta = laTasaBruta;

            ValorTransadoBruto = losDatos.ValorTransadoBruto;

            losDatosDeImpuesto = new DatosDeImpuesto();
            losDatosDeImpuesto.TratamientoFiscal = losDatos.TratamientoFiscal;
            losDatosDeImpuesto.ValorTransadoBruto = ValorTransadoBruto;
            losDatosDeImpuesto.ValorTransadoNeto = losDatos.ValorTransadoNeto;

            elImpuestoPagado = ObtengaImpuestoPagado(losDatosDeImpuesto);
            ImpuestoPagado = elImpuestoPagado;

            losDatosDeRendimiento = new DatosDeRendimiento();
            losDatosDeRendimiento.ValorFacial = losDatos.ValorFacial;
            losDatosDeRendimiento.ValorTransadoBruto = ValorTransadoBruto;

            elRendimientoPorDescuento = ObtengaRendimientoPorDescuento(losDatosDeRendimiento);
            RendimientoPorDescuento = elRendimientoPorDescuento;

        }


        private DateTime CalculeFechaDeVencimiento(DatosDeLaInversion losDatos)
        {
            return losDatos.FechaDeVencimiento;
        }

        private decimal ObtengaTasaBruta(DatosDeLaInversion losDatos)
        {
            return new TasaBruta(losDatos).ComoNumero();
        }

        private decimal ObtengaImpuestoPagado(DatosDeImpuesto losDatos)
        {
            return new ImpuestoPagado(losDatos).ComoNumero();
        }

        private decimal ObtengaRendimientoPorDescuento(DatosDeRendimiento losDatos)
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


