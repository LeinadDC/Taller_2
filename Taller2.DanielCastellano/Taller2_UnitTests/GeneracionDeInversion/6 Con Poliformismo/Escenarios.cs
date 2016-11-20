﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller2.PolimorfismoYHerencia;

namespace Taller2_UnitTests.GeneracionDeInversion.Poliformismo
{
    public class Escenarios
    {
        private DatosDeImpuesto losDatos;

        public NuevaInversion NuevaInversionConTratamientoFiscalYAñoBisiesto()
        {
            losDatos = new DatosConTratamientoFiscal();
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
            losDatos = new DatosConTratamientoFiscal();
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
            losDatos = new DatosSinTratamientoFiscal();
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
            losDatos = new DatosSinTratamientoFiscal();
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
