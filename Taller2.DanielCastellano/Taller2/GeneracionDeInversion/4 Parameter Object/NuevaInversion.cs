using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.ParameterObject
{
    public class NuevaInversion
    {
        DateTime laFechaDeVencimiento;
        decimal laTasaBruta;
        decimal elValorTransadoBruto;
        decimal elImpuestoPagado;
        decimal elRendimientoPorDescuento;
        DatosDeImpuesto losDatosDeImpuesto;

        public NuevaInversion(DatosDeLaInversion losDatos)
        {
            FechaDeValor = losDatos.FechaActual;

            laFechaDeVencimiento = CalculeFechaDeVencimiento(losDatos.FechaActual, losDatos.PlazoEnDias);
            FechaDeVencimiento = laFechaDeVencimiento;

            laTasaBruta = ObtengaTasaBruta(losDatos.ValorTransadoNeto, losDatos.ValorFacial, losDatos.TasaDeImpuesto, losDatos.FechaActual, losDatos.PlazoEnDias);
            TasaBruta = laTasaBruta;

            elValorTransadoBruto = ObtengaValorTransadoBruto(losDatos.ValorTransadoNeto, losDatos.ValorFacial, losDatos.FechaActual, losDatos.PlazoEnDias, losDatos.TratamientoFiscal, laTasaBruta);
            ValorTransadoBruto = elValorTransadoBruto;

            losDatosDeImpuesto = new DatosDeImpuesto();
            losDatosDeImpuesto.TratamientoFiscal = losDatos.TratamientoFiscal;
            losDatosDeImpuesto.ValorTransadoBruto = ValorTransadoBruto;
            losDatosDeImpuesto.ValorTransadoNeto = losDatos.ValorTransadoNeto;

            elImpuestoPagado = ObtengaImpuestoPagado(losDatos.ValorTransadoNeto, losDatos.TratamientoFiscal, elValorTransadoBruto);
            ImpuestoPagado = elImpuestoPagado;

            elRendimientoPorDescuento = ObtengaRendimientoPorDescuento(losDatos.ValorFacial, elValorTransadoBruto);
            RendimientoPorDescuento = elRendimientoPorDescuento;

        }


        private static DateTime CalculeFechaDeVencimiento(DateTime FechaActual, int PlazoEnDias)
        {
            return FechaActual.AddDays(PlazoEnDias);
        }

        private static decimal ObtengaTasaBruta(decimal ValorTransadoNeto, decimal ValorFacial, decimal TasaDeImpuesto, DateTime FechaActual, int PlazoEnDias)
        {
            return new TasaBruta(ValorTransadoNeto, ValorFacial, TasaDeImpuesto, FechaActual, PlazoEnDias).ComoNumero();
        }

        private static decimal ObtengaValorTransadoBruto(decimal ValorTransadoNeto, decimal ValorFacial, DateTime FechaActual, int PlazoEnDias, bool TratamientoFiscal, decimal TasaBruta)
        {
            if (TratamientoFiscal)
            {
                return DetermineValorTransadoBruto(ValorFacial, FechaActual, PlazoEnDias, TasaBruta);
            }
            else
            {
                return ValorTransadoNeto;
            }

        }

        private static decimal DetermineValorTransadoBruto(decimal ValorFacial, DateTime FechaActual, int PlazoEnDias, decimal TasaBruta)
        {
            if (DateTime.IsLeapYear(FechaActual.Year))
            {
                return ValorFacial / (1 + ((TasaBruta) / 100) * ((decimal)PlazoEnDias / 366));
            }
            else
            {
                return ValorFacial / (1 + ((TasaBruta) / 100) * ((decimal)PlazoEnDias / 365));
            }

        }

        private decimal ObtengaImpuestoPagado(decimal ValorTransadoNeto, bool TratamientoFiscal, decimal ValorTransadoBruto)
        {
            return new ImpuestoPagado(losDatosDeImpuesto).ComoNumero();
        }


        private static decimal ObtengaRendimientoPorDescuento(decimal ValorFacial, decimal ValorTransadoBruto)
        {
            return new RendimientoPorDescuento(ValorFacial, ValorTransadoBruto).ComoNumero();
        }

        public decimal TasaBruta { get; set; }
        public decimal ValorTransadoBruto { get; set; }
        public decimal ImpuestoPagado { get; set; }
        public decimal RendimientoPorDescuento { get; set; }
        public DateTime FechaDeValor { get; set; }
        public DateTime FechaDeVencimiento { get; set; }

    }

}


