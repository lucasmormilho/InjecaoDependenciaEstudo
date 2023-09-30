using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjecaoDependenciaSozinho.Service
{
    class AdidasTaxaService : ITaxaService
    {
        public double Taxa(double valor)
        {
            return valor * 0.5;
        }
    }
}
