﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.PolimorfismoYHerencia
{
    public abstract class DatosDeImpuesto : DatosDeLaInversion
    {
        public decimal ValorTransadoBruto
        {
            get
            {
                if (TratamientoFiscal)
                {
                    return DetermineValorTransadoBruto(this);
                }
                else
                {
                    return ValorTransadoNeto;
                }
            }
        }

        private decimal DetermineValorTransadoBruto(DatosDeLaInversion losDatos)
        {
            if (DateTime.IsLeapYear(FechaActual.Year))
            {
                return ValorFacial / (1 + ((new TasaBruta(this).ComoNumero()) / 100) * ((decimal)PlazoEnDias / 366));
            }
            else
            {
                return ValorFacial / (1 + ((new TasaBruta(this).ComoNumero()) / 100) * ((decimal)PlazoEnDias / 365));
            }

        }

        public abstract decimal ImpuestoPagado { get; }

        public decimal Rendimiento { get { return (ValorFacial - ValorTransadoBruto); } }
    }
}
