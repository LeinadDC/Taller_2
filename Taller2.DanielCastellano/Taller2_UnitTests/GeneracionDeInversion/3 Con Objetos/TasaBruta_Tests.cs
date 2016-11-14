﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taller2.Objetos;

namespace Taller2_UnitTests.GeneracionDeInversion.Objetos
{
    [TestClass]
    public class TasaBruta_Tests : Escenarios
    {

        private decimal resultadoEsperado;
        private decimal resultadoObtenido;
        private NuevaInversion nuevaInversion;

        [TestMethod]
        public void TasaBruta_AñoBisiesto()
        {
            resultadoEsperado = 12.300806610269525870548888446M;

            nuevaInversion = NuevaInversionConTratamientoFiscalYAñoBisiesto();
            resultadoObtenido = nuevaInversion.TasaBruta;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void TasaBruta_AñoNormal()
        {
            resultadoEsperado = 12.267197849039281264345202967M;

            nuevaInversion = NuevaInversionConTratamientoFiscalYAñoNormal();
            resultadoObtenido = nuevaInversion.TasaBruta;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
