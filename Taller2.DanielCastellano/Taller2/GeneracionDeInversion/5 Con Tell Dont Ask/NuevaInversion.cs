﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.TellDontAsk
{
    public class NuevaInversion
    {
        decimal TasaNeta;

        public NuevaInversion(DatosDeLaInversion losDatos)
        {

            FechaDeValor = losDatos.FechaActual;

            FechaDeVencimiento = CalculeFechaVencimiento(losDatos.FechaActual, losDatos.PlazoEnDias);

            TasaNeta = DetermineTasaNeta(losDatos.ValorTransadoNeto, losDatos.ValorFacial, losDatos.FechaActual, losDatos.PlazoEnDias);

            TasaBruta = CalculeTasaBruta(losDatos.TasaDeImpuesto, TasaNeta);

            ValorTransadoBruto = DetermineValorTransadoBruto(losDatos.ValorTransadoNeto, losDatos.ValorFacial, losDatos.FechaActual, losDatos.PlazoEnDias, losDatos.TratamientoFiscal, TasaBruta);

            ImpuestoPagado = DetermineImpuestoPagado(losDatos.ValorTransadoNeto, losDatos.TratamientoFiscal, ValorTransadoBruto);

            RendimientoPorDescuento = CalculeRendimientoPorDescuento(losDatos.ValorFacial, ValorTransadoBruto);
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

        public decimal TasaBruta { get; set; }
        public decimal ValorTransadoBruto { get; set; }
        public decimal ImpuestoPagado { get; set; }
        public decimal RendimientoPorDescuento { get; set; }
        public DateTime FechaDeValor { get; set; }
        public DateTime FechaDeVencimiento { get; set; }
    }

}
