using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taller2.TellDontAsk;

namespace Taller2_UnitTests.GeneracionDeInversion.TellDontAsk
{
    [TestClass]
    public class ImpuestoPagado_Tests : Escenarios
    {

        private decimal resultadoEsperado;
        private decimal resultadoObtenido;
        private NuevaInversion nuevaInversion;

        [TestMethod]
        public void ImpuestoPagado_AñoBisiesto_ConTratamientoFiscal()
        {
            resultadoEsperado = 1659.3592M;

            nuevaInversion = NuevaInversionConTratamientoFiscalYAñoBisiesto();
            resultadoObtenido = nuevaInversion.ImpuestoPagado;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void ImpuestoPagado_AñoNormal_ConTratamientoFiscal()
        {
            resultadoEsperado = 1659.3592M;

            nuevaInversion = NuevaInversionConTratamientoFiscalYAñoNormal();
            resultadoObtenido = nuevaInversion.ImpuestoPagado;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void ImpuestoPagado_AñoBisiesto_SinTratamientoFiscal()
        {
            resultadoEsperado = 0;

            nuevaInversion = NuevaInversionSinTratamientoFiscalYAñoBisiesto();
            resultadoObtenido = nuevaInversion.ImpuestoPagado;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void ImpuestoPagado_AñoNormal_SinTratamientoFiscal()
        {
            resultadoEsperado = 0;

            nuevaInversion = NuevaInversionSinTratamientoFiscalYAñoNormal();
            resultadoObtenido = nuevaInversion.ImpuestoPagado;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
