using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taller2.Procedimiento;

namespace Taller2_UnitTests.GeneracionDeInversion.Procedimiento
{
    [TestClass]
    public class TasaBruta_Tests : Escenarios
    {

        private decimal resultadoEsperado;
        private decimal resultadoObtenido;
        private NuevaInversion nuevaInversion;

        [TestMethod]
        public void TasaBruta_CasoUnico()
        {
            resultadoEsperado = 12.3008M;
            nuevaInversion = NuevaInversionConTratamientoFiscalYAñoBisiesto();

            resultadoObtenido = nuevaInversion.TasaBruta;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);


        }
    }
}
