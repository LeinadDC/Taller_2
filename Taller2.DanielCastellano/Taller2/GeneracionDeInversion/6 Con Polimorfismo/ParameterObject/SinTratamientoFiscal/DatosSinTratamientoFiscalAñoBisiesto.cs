using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.PolimorfismoYHerencia
{
    public class DatosSinTratamientoFiscalAñoBisiesto : DatosSinTratamientoFiscal
    {
        public override decimal TasaNeta
        {
            get
            {
                return (ValorFacial - ValorTransadoNeto) / (ValorTransadoNeto * ((decimal)PlazoEnDias / 366)) * 100;
            }
        }

        public override decimal ValorTransadoBruto
        {
            get
            {
                return ValorTransadoNeto;
            }
        }
    }
}
