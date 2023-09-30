using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjecaoDependenciaSozinho.Entities
{
    class Tenis
    {
        public string Marca { get; set; }

        public Tenis(string marca)
        {
            Marca = marca;
        }
    }
}
