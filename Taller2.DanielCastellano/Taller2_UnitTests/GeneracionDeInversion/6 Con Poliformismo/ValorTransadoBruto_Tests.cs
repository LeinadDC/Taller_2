using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taller2.Poliformismo;

namespace Taller2_UnitTests.GeneracionDeInversion.Poliformismo
{
    [TestClass]
    public class ValorTransadoBruto_Tests:Escenarios
    {

        private decimal resultadoEsperado;
        private decimal resultadoObtenido;
        private NuevaInversion nuevaInversion;

        [TestMethod]
        public void ValorTransadoBruto_AñoBisiesto_ConTratamientoFiscal()
        {
            resultadoEsperado = 298340.64080944350758853288365M;

            nuevaInversion = NuevaInversionConTratamientoFiscalYAñoBisiesto();
            resultadoObtenido = nuevaInversion.ValorTransadoBruto;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void ValorTransadoBruto_AñoNormal_ConTratamientoFiscal()
        {
            resultadoEsperado = 298340.64080944350758853288362M;

            nuevaInversion = NuevaInversionConTratamientoFiscalYAñoNormal();
            resultadoObtenido = nuevaInversion.ValorTransadoBruto;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void ValorTransadoBruto_AñoBisiesto_SinTratamientoFiscal()
        {
            resultadoEsperado = 300000;

            nuevaInversion = NuevaInversionSinTratamientoFiscalYAñoBisiesto();
            resultadoObtenido = nuevaInversion.ValorTransadoBruto;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void ValorTransadoBruto_AñoNormal_SinTratamientoFiscal()
        {
            resultadoEsperado = 300000;

            nuevaInversion = NuevaInversionSinTratamientoFiscalYAñoNormal();
            resultadoObtenido = nuevaInversion.ValorTransadoBruto;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
