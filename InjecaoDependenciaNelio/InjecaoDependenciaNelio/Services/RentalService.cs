using InjecaoDependenciaNelio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjecaoDependenciaNelio.Services
{

    //Agora temos um serviço de aluguel
    //que depende de um objeto de um serviço de interface
    //esse serviço não sabe qual a implementação (tax do brasil, EUA, japan...etc)
    //desaclopamento

    internal class RentalService
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        //não é a melhor forma
        //serviço de imposto
        //ruim pois fica dependente da taxa brasil
        //private BrazilTaxService _brasilTaxService = new BrazilTaxService();

        //interface
        //recebe qualquer servico de taxa
        private ITaxService _TaxService;

        //upcasting
        //injeção de dependencia
        //no construtor
        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            //inversão de controle por meio de injeção de dependencia
            _TaxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            //duração da locação
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

            double basicPayment = 0.0;

            if (duration.TotalHours <= 12.0)
            {
                //arredonda para cima
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            //processa taxa
            double tax = _TaxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax); 
        }
    }
}
