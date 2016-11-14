using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taller2.Procedimiento;

namespace Taller2_UnitTests.GeneracionDeInversion.Procedimiento
{
    [TestClass]
    public class ImpuestoPagado_Tests : Escenarios
    {

        private decimal resultadoEsperado;
        private decimal resultadoObtenido;
        private NuevaInversion nuevaInversion;

        [TestMethod]
        public void ImpuestoPagado_AñoBisiesto()
        {
            resultadoEsperado = 1659.3592M;

            nuevaInversion = NuevaInversionConTratamientoFiscalYAñoBisiesto();
            resultadoObtenido = nuevaInversion.ImpuestoPagado;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void ImpuestoPagado_AñoNormal()
        {
            resultadoEsperado = 1659.3592M;

            nuevaInversion = NuevaInversionConTratamientoFiscalYAñoNormal();
            resultadoObtenido = nuevaInversion.ImpuestoPagado;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
