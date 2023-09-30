using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjecaoDependenciaSozinho.Entities
{
    class Pagamento
    {
        public double Valor {  get; set; }
        public Tenis Tenis { get; set; }
        public Fatura Fatura { get; set; }

        public Pagamento(double valor, Tenis tenis)
        {
            Valor = valor;
            Tenis = tenis;
        }
    }
}
