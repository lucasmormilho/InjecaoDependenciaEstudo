using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjecaoDependenciaSozinho.Service
{
    internal class NikeTaxaService : ITaxaService
    {
        public double Taxa(double valor)
        {
            return valor * 0.1;
        }
    }
}
