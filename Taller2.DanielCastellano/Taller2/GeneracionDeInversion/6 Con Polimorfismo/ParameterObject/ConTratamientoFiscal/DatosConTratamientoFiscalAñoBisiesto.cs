using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.PolimorfismoYHerencia
{
    public class DatosConTratamientoFiscalAñoBisiesto : DatosConTratamientoFiscal
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
                return ValorFacial / (1 + ((new TasaBruta(this).ComoNumero()) / 100) * ((decimal)PlazoEnDias / 366));
            }
        }
    }
}
