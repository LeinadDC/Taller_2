﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.ParameterObject
{
    public class ImpuestoPagado
    {
        decimal Impuesto;

        public ImpuestoPagado(DatosDeImpuesto losDatos)
        {
            Impuesto = DetermineImpuestoPagado(losDatos);
        }

        private static decimal DetermineImpuestoPagado(DatosDeImpuesto losDatos)
        {
            //TODO: Mas de una operacion
            if (losDatos.TratamientoFiscal)
            {
                return (losDatos.ValorTransadoNeto - losDatos.ValorTransadoBruto);
            }
            else
            {
                return 0;
            }

        }

        public decimal ComoNumero()
        {
            return Math.Round(Impuesto, 4);
        }
    }
}
