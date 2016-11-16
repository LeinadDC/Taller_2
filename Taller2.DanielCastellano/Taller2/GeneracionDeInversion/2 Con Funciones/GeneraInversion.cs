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

            DateTime FechaDeVencimiento = CalculeFechaVencimiento(FechaActual, PlazoEnDias);
            nuevaInversion.FechaDeVencimiento = FechaDeVencimiento;

            decimal TasaBruta = ObtengaTasaBruta(ValorTransadoNeto, ValorFacial, TasaDeImpuesto, FechaActual, PlazoEnDias);
            nuevaInversion.TasaBruta = TasaBruta;

            decimal ValorTransadoBruto = DetermineValorTransadoBruto(ValorTransadoNeto, ValorFacial, FechaActual, PlazoEnDias, TratamientoFiscal, TasaBruta);
            nuevaInversion.ValorTransadoBruto = ValorTransadoBruto;

            decimal ImpuestoPagado = DetermineImpuestoPagado(ValorTransadoNeto, TratamientoFiscal, ValorTransadoBruto);
            nuevaInversion.ImpuestoPagado = ImpuestoPagado;

            decimal RendimientoRedondeado = ObtengaRendimientoPorDescuento(ValorFacial, ValorTransadoBruto);
            nuevaInversion.RendimientoPorDescuento = RendimientoRedondeado;

            return nuevaInversion;

        }

        private static DateTime CalculeFechaVencimiento(DateTime FechaActual, int PlazoEnDias)
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

        private static decimal DetermineValorTransadoBruto(decimal ValorTransadoNeto, decimal ValorFacial, DateTime FechaActual, int PlazoEnDias, bool TratamientoFiscal, decimal TasaBruta)
        {
            if (TratamientoFiscal)
            {
                return DetermineValorTransado(ValorFacial, FechaActual, PlazoEnDias, TasaBruta);
            }
            else
            {
                return ValorTransadoNeto;
            }
        }

        private static decimal DetermineValorTransado(decimal ValorFacial, DateTime FechaActual, int PlazoEnDias, decimal TasaBruta)
        {
            if (DateTime.IsLeapYear(FechaActual.Year))
            {
                return  ValorFacial / (1 + ((TasaBruta) / 100) * ((decimal)PlazoEnDias / 366));
            }
            else
            {
                return ValorFacial / (1 + ((TasaBruta) / 100) * ((decimal)PlazoEnDias / 365));
            }
        }

        private static decimal DetermineImpuestoPagado(decimal ValorTransadoNeto, bool TratamientoFiscal, decimal ValorTransadoBruto)
        {
            if (TratamientoFiscal)
            {
                return ObtengaImpuestoPagado(ValorTransadoNeto, ValorTransadoBruto);

            }
            else
            {
                return 0;
            }
        }

        private static decimal ObtengaImpuestoPagado(decimal ValorTransadoNeto, decimal ValorTransadoBruto)
        {
            decimal Impuesto = CalculeImpuestoPagado(ValorTransadoNeto, ValorTransadoBruto);
            return RedondeeImpuestoPagado(Impuesto);
        }

        private static decimal CalculeImpuestoPagado(decimal ValorTransadoNeto, decimal ValorTransadoBruto)
        {
            return (ValorTransadoNeto - ValorTransadoBruto);
        }

        private static decimal RedondeeImpuestoPagado(decimal Impuesto)
        {
            return Math.Round(Impuesto, 4);
        }

        private static decimal ObtengaRendimientoPorDescuento(decimal ValorFacial, decimal ValorTransadoBruto)
        {
            decimal RendimientoPorDescuento = CalculeRendimientoPorDescuento(ValorFacial, ValorTransadoBruto);
            return RedondeeRendimiento(RendimientoPorDescuento);
        }

        private static decimal CalculeRendimientoPorDescuento(decimal ValorFacial, decimal ValorTransadoBruto)
        {
            return (ValorFacial - ValorTransadoBruto);
        }

        private static decimal RedondeeRendimiento(decimal RendimientoPorDescuento)
        {
            return Math.Round(RendimientoPorDescuento, 4);
        }
    }
}
