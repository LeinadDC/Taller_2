using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.Objetos
{
    public class NuevaInversion
    {
        public NuevaInversion(decimal ValorTransadoNeto,
            decimal ValorFacial,
            decimal TasaDeImpuesto,
            DateTime FechaActual,
            int PlazoEnDias,
            bool TratamientoFiscal)
        {
            FechaDeValor = FechaActual;

            DateTime FechaVencimiento = CalculeFechaDeVencimiento(FechaActual, PlazoEnDias);
            FechaDeVencimiento = FechaVencimiento;

            decimal TasaBrutaCalculada = ObtengaTasaBruta(ValorTransadoNeto, ValorFacial, TasaDeImpuesto, FechaActual, PlazoEnDias);
            TasaBruta = TasaBrutaCalculada;

            decimal ValorTransado = ObtengaValorTransadoBruto(ValorTransadoNeto, ValorFacial, FechaActual, PlazoEnDias, TratamientoFiscal, TasaBrutaCalculada);
            ValorTransadoBruto = ValorTransado;

            decimal Impuesto = ObtengaImpuestoPagado(ValorTransadoNeto, TratamientoFiscal, ValorTransado);
            ImpuestoPagado = Impuesto;

            decimal RendimientoCalculado = ObtengaRendimientoPorDescuento(ValorFacial, ValorTransado);
            RendimientoPorDescuento = RendimientoCalculado;
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

        private static decimal ObtengaImpuestoPagado(decimal ValorTransadoNeto, bool TratamientoFiscal, decimal ValorTransadoBruto)
        {
            return new ImpuestoPagado(ValorTransadoNeto, TratamientoFiscal, ValorTransadoBruto).ComoNumero();
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


