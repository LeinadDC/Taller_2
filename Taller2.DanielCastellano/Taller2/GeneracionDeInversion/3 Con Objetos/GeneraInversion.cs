using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.Objetos
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

            decimal ImpuestoPagado = ObtieneImpuestoPagado(ValorTransadoNeto, TratamientoFiscal, ValorTransadoBruto);
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

        private static decimal ObtieneImpuestoPagado(decimal ValorTransadoNeto, bool TratamientoFiscal, decimal ValorTransadoBruto)
        {
            return new ImpuestoPagado(ValorTransadoNeto, TratamientoFiscal, ValorTransadoBruto).ComoNumero();
        }


        private static decimal ObtengaRendimientoPorDescuento(decimal ValorFacial, decimal ValorTransadoBruto)
        {

            return new RendimientoPorDescuento(ValorFacial,ValorTransadoBruto).ComoNumero();
        }

    }
}
