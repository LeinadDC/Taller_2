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
        decimal elValorTransadoBruto;
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

            elValorTransadoBruto = ObtengaValorTransadoBruto(losDatos);
            ValorTransadoBruto = elValorTransadoBruto;

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
            //TODO: Mas de una operacion
            return losDatos.FechaActual.AddDays(losDatos.PlazoEnDias);
        }

        private decimal ObtengaTasaBruta(DatosDeLaInversion losDatos)
        {
            return new TasaBruta(losDatos).ComoNumero();
        }

        private decimal ObtengaValorTransadoBruto(DatosDeLaInversion losDatos)
        {
            //TODO: Mas de una operación
            if (losDatos.TratamientoFiscal)
            {
                return DetermineValorTransadoBruto(losDatos);
            }
            else
            {
                return losDatos.ValorTransadoNeto;
            }

        }

        private decimal DetermineValorTransadoBruto(DatosDeLaInversion losDatos)
        {
            //TODO: Mas de una operación
            if (DateTime.IsLeapYear(losDatos.FechaActual.Year))
            {
                return losDatos.ValorFacial / (1 + ((TasaBruta) / 100) * ((decimal)losDatos.PlazoEnDias / 366));
            }
            else
            {
                return losDatos.ValorFacial / (1 + ((TasaBruta) / 100) * ((decimal)losDatos.PlazoEnDias / 365));
            }

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


