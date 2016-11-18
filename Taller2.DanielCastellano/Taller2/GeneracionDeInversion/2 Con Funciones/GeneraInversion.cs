using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.Funciones
{
    public class GeneraInversion
    {
        public static NuevaInversion GeneraNuevaInversion(decimal ValorTransadoNeto,
            decimal ValorFacial,
            decimal TasaDeImpuesto,
            DateTime FechaActual,
            int PlazoEnDias,
            bool TratamientoFiscal)
        {
            NuevaInversion nuevaInversion = new NuevaInversion();

            nuevaInversion.FechaDeValor = FechaActual;

            DateTime FechaDeVencimiento = CalculeFechaDeVencimiento(FechaActual, PlazoEnDias);
            nuevaInversion.FechaDeVencimiento = FechaDeVencimiento;

            decimal TasaBruta = ObtengaTasaBruta(ValorTransadoNeto, ValorFacial, TasaDeImpuesto, FechaActual, PlazoEnDias);
            nuevaInversion.TasaBruta = TasaBruta;

            decimal ValorTransadoBruto = ObtengaValorTransadoBruto(ValorTransadoNeto, ValorFacial, FechaActual, PlazoEnDias, TratamientoFiscal, TasaBruta);
            nuevaInversion.ValorTransadoBruto = ValorTransadoBruto;

            decimal ImpuestoRedondeado = ObtengaImpuestoPagado(ValorTransadoNeto, TratamientoFiscal, ValorTransadoBruto);
            nuevaInversion.ImpuestoPagado = ImpuestoRedondeado;

            decimal RendimientoPorDescuento = ObtengaRendimientoPorDescuento(ValorFacial, ValorTransadoBruto);
            nuevaInversion.RendimientoPorDescuento = RendimientoPorDescuento;

            return nuevaInversion;

        }

        private static DateTime CalculeFechaDeVencimiento(DateTime FechaActual, int PlazoEnDias)
        {
            return FechaActual.AddDays(PlazoEnDias);
        }

        private static decimal ObtengaTasaBruta(decimal ValorTransadoNeto, decimal ValorFacial, decimal TasaDeImpuesto, DateTime FechaActual, int PlazoEnDias)
        {
            decimal TasaNeta = DetermineTasaNeta(ValorTransadoNeto, ValorFacial, FechaActual, PlazoEnDias);

            return CalculeTasaBruta(TasaDeImpuesto, TasaNeta);
        }

        private static decimal DetermineTasaNeta(decimal ValorTransadoNeto, decimal ValorFacial, DateTime FechaActual, int PlazoEnDias)
        {
            if (DateTime.IsLeapYear(FechaActual.Year))
            {
                return (ValorFacial - ValorTransadoNeto) / (ValorTransadoNeto * ((decimal)PlazoEnDias / 366)) * 100;

            }
            else
            {
                return (ValorFacial - ValorTransadoNeto) / (ValorTransadoNeto * ((decimal)PlazoEnDias / 365)) * 100;
            }

        }

        private static decimal CalculeTasaBruta(decimal TasaDeImpuesto, decimal TasaNeta)
        {
            return TasaNeta / (1 - TasaDeImpuesto);
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

        private static decimal ObtengaImpuestoPagado(decimal ValorTransadoNeto, bool TratamientoFiscal, decimal ValorTransadoBruto)
        {
            decimal ImpuestoPagado = DetermineImpuestoPagado(ValorTransadoNeto, TratamientoFiscal, ValorTransadoBruto);
            return RedondeeImpuestoPagado(ImpuestoPagado);
        }

        private static decimal DetermineImpuestoPagado(decimal ValorTransadoNeto, bool TratamientoFiscal, decimal ValorTransadoBruto)
        {
            if (TratamientoFiscal)
            {
                return (ValorTransadoNeto - ValorTransadoBruto);
            }
            else
            {
                return 0;
            }

        }

        private static decimal RedondeeImpuestoPagado(decimal ImpuestoPagado)
        {
            return Math.Round(ImpuestoPagado, 4);
        }

        private static decimal ObtengaRendimientoPorDescuento(decimal ValorFacial, decimal ValorTransadoBruto)
        {
            decimal RendimientoSinRedondear = CalculeRendimiento(ValorFacial, ValorTransadoBruto);
            return RedondeeRendimiento(RendimientoSinRedondear);
        }

        private static decimal CalculeRendimiento(decimal ValorFacial, decimal ValorTransadoBruto)
        {
            return (ValorFacial - ValorTransadoBruto);
        }

        private static decimal RedondeeRendimiento(decimal RendimientoSinRedondear)
        {
            return Math.Round(RendimientoSinRedondear, 4);
        }
    }
}
