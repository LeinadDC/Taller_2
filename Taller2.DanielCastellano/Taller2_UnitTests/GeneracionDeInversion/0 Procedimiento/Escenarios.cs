using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller2.Procedimiento;

namespace Taller2_UnitTests.GeneracionDeInversion.Procedimiento
{
    public class Escenarios
    {
        private decimal ValorTransadoNeto;
        private decimal ValorFacial;
        private decimal TasaDeImpuesto;
        private DateTime FechaActual;
        private int PlazoEnDias;
        private bool TratamientoFiscal;

        public NuevaInversion NuevaInversionConTratamientoFiscalYAñoBisiesto()
        {
            ValorFacial = 320500;
            ValorTransadoNeto = 300000;
            TasaDeImpuesto = 0.08M;
            FechaActual = new DateTime(2016,03,03);
            PlazoEnDias = 221;
            TratamientoFiscal = true;

            return GeneraInversion.GeneraNuevaInversion(ValorTransadoNeto, ValorFacial, TasaDeImpuesto, FechaActual, PlazoEnDias, TratamientoFiscal);

        }
    }
}
