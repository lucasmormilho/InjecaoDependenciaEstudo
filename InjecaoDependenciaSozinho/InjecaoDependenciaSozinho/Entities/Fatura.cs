using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjecaoDependenciaSozinho.Entities
{
    class Fatura
    {
        public double PagamentoBasico { get; set; }
        public double Taxa { get; set; }

        public Fatura(double pagamento, double taxa)
        {
            PagamentoBasico = pagamento;
            Taxa = taxa;
        }

        public double TotalPagamento { 
            get { return PagamentoBasico + Taxa; }
        }

        public override string ToString()
        {
            return "Pagamento basico: "
                + PagamentoBasico.ToString()
                + "\nTaxa: "
                + Taxa.ToString()
                + "\nTotal: "
                + TotalPagamento.ToString();
        }
    }
}
