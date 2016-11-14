using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taller2.Objetos;

namespace Taller2_UnitTests.GeneracionDeInversion.Objetos
{
    [TestClass]
    public class ValorTransadoBruto_Tests:Escenarios
    {

        private decimal resultadoEsperado;
        private decimal resultadoObtenido;
        private NuevaInversion nuevaInversion;

        [TestMethod]
        public void ValorTransadoBruto_AñoBisiesto()
        {
            resultadoEsperado = 298340.64080944350758853288365M;

            nuevaInversion = NuevaInversionConTratamientoFiscalYAñoBisiesto();
            resultadoObtenido = nuevaInversion.ValorTransadoBruto;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void ValorTransadoBruto_AñoNormal()
        {
            resultadoEsperado = 298340.64080944350758853288362M;

            nuevaInversion = NuevaInversionConTratamientoFiscalYAñoNormal();
            resultadoObtenido = nuevaInversion.ValorTransadoBruto;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
