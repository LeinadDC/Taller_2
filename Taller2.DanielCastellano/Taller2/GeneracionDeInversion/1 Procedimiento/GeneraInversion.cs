using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.Procedimiento
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

            DateTime FechaDeVencimiento = FechaActual.AddDays(PlazoEnDias);
            nuevaInversion.FechaDeVencimiento = FechaDeVencimiento;

            decimal TasaNeta;
            if (DateTime.IsLeapYear(FechaActual.Year))
            {
                TasaNeta = (ValorFacial - ValorTransadoNeto) / (ValorTransadoNeto * ((decimal)PlazoEnDias / 366)) *100;
                
            }
            else
            {
                TasaNeta = (ValorFacial - ValorTransadoNeto) / (ValorTransadoNeto * ((decimal)PlazoEnDias / 365)) * 100;
            }

            decimal TasaBruta = TasaNeta / (1 - TasaDeImpuesto);
            nuevaInversion.TasaBruta = TasaBruta;

            decimal ValorTransadoBruto;
            if (TratamientoFiscal)
            {
                if (DateTime.IsLeapYear(FechaActual.Year))
                {
                    ValorTransadoBruto = ValorFacial / (1 + ((TasaBruta) / 100) * ((decimal)PlazoEnDias / 366));
                }
                else
                {
                    ValorTransadoBruto = ValorFacial / (1 + ((TasaBruta) / 100) * ((decimal)PlazoEnDias / 365));
                }
            }
            else
            {
                ValorTransadoBruto = ValorTransadoNeto;
            }
            nuevaInversion.ValorTransadoBruto = ValorTransadoBruto;

            decimal ImpuestoPagado;
            if (TratamientoFiscal)
            {
                ImpuestoPagado = Math.Round((ValorTransadoNeto - ValorTransadoBruto), 4);
            }
            else
            {
                ImpuestoPagado = 0;
            }
            nuevaInversion.ImpuestoPagado = ImpuestoPagado;

            decimal RendimientoPorDescuento = Math.Round((ValorFacial - ValorTransadoBruto), 4);
            nuevaInversion.RendimientoPorDescuento = RendimientoPorDescuento;

            return nuevaInversion;

        }
    }
}
