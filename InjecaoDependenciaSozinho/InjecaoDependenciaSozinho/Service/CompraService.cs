using InjecaoDependenciaSozinho.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjecaoDependenciaSozinho.Service
{
    internal class CompraService
    {
        public double ValorTenis { get; set; }
        private ITaxaService _taxaService;

        public CompraService(double valorTenis, ITaxaService taxaService)
        {
            ValorTenis = valorTenis;
            _taxaService = taxaService;
        }

        public void ProcessarFatura(Pagamento pagamento)
        {
            double valorBasico = 0.0;

            if (ValorTenis >= 1000) 
            {
                valorBasico = ValorTenis + 5.00;
            }
            else
            {
                valorBasico = ValorTenis + 10.00;
            }

            double taxa = _taxaService.Taxa(valorBasico);
            
            pagamento.Fatura = new Fatura(valorBasico,taxa);
        }
    }
}
