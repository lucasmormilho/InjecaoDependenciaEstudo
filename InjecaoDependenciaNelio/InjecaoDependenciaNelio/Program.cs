using InjecaoDependenciaNelio.Entities;
using InjecaoDependenciaNelio.Services;
using System;
using System.Globalization;

namespace InjecaoDependenciaNelio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rental data");
            Console.Write("Car Model: ");
            string model = Console.ReadLine();
            Console.Write("Pickup (dd/MM/yyyy hh:ss): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Return (dd/MM/yyyy hh:ss): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter price per day: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //instancia aluguel
            CarRental carRental = new CarRental(start, finish, new Vehicle(model));

            //instancia um rental service do brasil
            RentalService rentalServiceBr = new RentalService(hour, day, new BrazilTaxService());
            rentalServiceBr.ProcessInvoice(carRental);
            Console.WriteLine("INVOICE BRASIL:");
            Console.WriteLine(carRental.Invoice);

            //instancia um rental service do EUA
            RentalService rentalServiceEua = new RentalService(hour, day, new EUATaxService());
            rentalServiceEua.ProcessInvoice(carRental);
            Console.WriteLine("INVOICE EUA:");
            Console.WriteLine(carRental.Invoice);

            Console.Read();

        }
    }
}
