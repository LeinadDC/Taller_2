﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taller2.Objetos;

namespace Taller2_UnitTests.GeneracionDeInversion.Objetos
{
    [TestClass]
    public class RendimiendoPorDescuento_Tests:Escenarios
    {
        private decimal resultadoEsperado;
        private decimal resultadoObtenido;
        private NuevaInversion nuevaInversion;

        [TestMethod]
        public void RendimientoPorDescuento_AñoBisiesto()
        {
            resultadoEsperado = 22159.3592M;

            nuevaInversion = NuevaInversionConTratamientoFiscalYAñoBisiesto();
            resultadoObtenido = nuevaInversion.RendimientoPorDescuento;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);

        }

        [TestMethod]
        public void RendimientoPorDescuento_AñoNormal()
        {
            resultadoEsperado = 22159.3592M;

            nuevaInversion = NuevaInversionConTratamientoFiscalYAñoNormal();
            resultadoObtenido = nuevaInversion.RendimientoPorDescuento;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);

        }
    }
}
