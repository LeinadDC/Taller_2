﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.PolimorfismoYHerencia
{
    public abstract class DatosConTratamientoFiscal : DatosDeImpuesto
    {
        public override decimal ImpuestoPagado
        {
            get
            {
                return (ValorTransadoNeto - ValorTransadoBruto);
            }
        }
    }
}
