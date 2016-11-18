using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2.Poliformismo
{
    public class TasaNetaAñoNormal : DatosDeLaInversion
    {
        public override decimal TasaNeta
        {
            get
            {
                return (ValorFacial - ValorTransadoNeto) / (ValorTransadoNeto * ((decimal)PlazoEnDias / 365)) * 100;
            }
        }
    }
}
