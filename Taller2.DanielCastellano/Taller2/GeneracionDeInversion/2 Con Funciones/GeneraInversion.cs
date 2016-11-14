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

            decimal TasaNeta = DetermineTasaNeta(ValorTransadoNeto, ValorFacial, FechaActual, PlazoEnDias);

            decimal TasaBruta = CalculeTasaBruta(TasaDeImpuesto, TasaNeta);
            nuevaInversion.TasaBruta = TasaBruta;

            decimal ValorTransadoBruto = DetermineValorTransadoBruto(ValorTransadoNeto, ValorFacial, FechaActual, PlazoEnDias, TratamientoFiscal, TasaBruta);
            nuevaInversion.ValorTransadoBruto = ValorTransadoBruto;

            decimal ImpuestoPagado = DetermineImpuestoPagado(ValorTransadoNeto, TratamientoFiscal, ValorTransadoBruto);
            nuevaInversion.ImpuestoPagado = ImpuestoPagado;

            decimal RendimientoPorDescuento = CalculeRendimientoPorDescuento(ValorFacial, ValorTransadoBruto);
            nuevaInversion.RendimientoPorDescuento = RendimientoPorDescuento;

            return nuevaInversion;

        }

        private static DateTime CalculeFechaVencimiento(DateTime FechaActual, int PlazoEnDias)
        {
            return FechaActual.AddDays(PlazoEnDias);
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
                return DetermineValorTransadoNeto(ValorFacial, FechaActual, PlazoEnDias, TasaBruta);
            }
            else
            {
                return ValorTransadoNeto;
            }

        }

        private static decimal DetermineValorTransadoNeto(decimal ValorFacial, DateTime FechaActual, int PlazoEnDias, decimal TasaBruta)
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

        private static decimal DetermineImpuestoPagado(decimal ValorTransadoNeto, bool TratamientoFiscal, decimal ValorTransadoBruto)
        {
            if (TratamientoFiscal)
            {
                return Math.Round((ValorTransadoNeto - ValorTransadoBruto), 4);
            }
            else
            {
                return 0;
            }
        }

        private static decimal CalculeRendimientoPorDescuento(decimal ValorFacial, decimal ValorTransadoBruto)
        {
            return Math.Round((ValorFacial - ValorTransadoBruto), 4);
        }
    }
}
