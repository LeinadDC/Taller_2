using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller2.ParameterObject;

namespace Taller2_UnitTests.GeneracionDeInversion.ParameterObject
{
    public class Escenarios
    {
        private DatosDeLaInversion losDatos;

        public NuevaInversion NuevaInversionConTratamientoFiscalYAñoBisiesto()
        {
            losDatos = new DatosDeLaInversion();
            losDatos.ValorFacial = 320500;
            losDatos.ValorTransadoNeto = 300000;
            losDatos.TasaDeImpuesto = 0.08M;
            losDatos.FechaActual = new DateTime(2016, 03, 03);
            losDatos.PlazoEnDias = 221;
            losDatos.TratamientoFiscal = true;

            return new NuevaInversion(losDatos);

        }

        public NuevaInversion NuevaInversionConTratamientoFiscalYAñoNormal()
        {
            losDatos = new DatosDeLaInversion();
            losDatos.ValorFacial = 320500;
            losDatos.ValorTransadoNeto = 300000;
            losDatos.TasaDeImpuesto = 0.08M;
            losDatos.FechaActual = new DateTime(2014, 03, 03);
            losDatos.PlazoEnDias = 221;
            losDatos.TratamientoFiscal = true;

            return new NuevaInversion(losDatos);

        }

        public NuevaInversion NuevaInversionSinTratamientoFiscalYAñoBisiesto()
        {
            losDatos = new DatosDeLaInversion();
            losDatos.ValorFacial = 320500;
            losDatos.ValorTransadoNeto = 300000;
            losDatos.TasaDeImpuesto = 0.08M;
            losDatos.FechaActual = new DateTime(2016, 03, 03);
            losDatos.PlazoEnDias = 221;
            losDatos.TratamientoFiscal = false;

            return new NuevaInversion(losDatos);

        }

        public NuevaInversion NuevaInversionSinTratamientoFiscalYAñoNormal()
        {
            losDatos = new DatosDeLaInversion();
            losDatos.ValorFacial = 320500;
            losDatos.ValorTransadoNeto = 300000;
            losDatos.TasaDeImpuesto = 0.08M;
            losDatos.FechaActual = new DateTime(2014, 03, 03);
            losDatos.PlazoEnDias = 221;
            losDatos.TratamientoFiscal = false;

            return new NuevaInversion(losDatos);

        }
    }
}
