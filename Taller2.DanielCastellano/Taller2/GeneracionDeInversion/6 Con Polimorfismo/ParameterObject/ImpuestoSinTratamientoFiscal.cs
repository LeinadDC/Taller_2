﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.Poliformismo
{
    public class ImpuestoSinTratamientoFiscal : DatosDeImpuesto
    {
        public override decimal ImpuestoPagado
        {
            get
            {
                return 0;
            }
        }
    }
}
