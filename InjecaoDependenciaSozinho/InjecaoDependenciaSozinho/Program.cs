// See https://aka.ms/new-console-template for more information
using InjecaoDependenciaSozinho.Entities;
using InjecaoDependenciaSozinho.Service;

Console.Write("Escolha o tenis (nike/adidas): ");
string entrada = Console.ReadLine();
Console.Write("Valor do tenis: ");
double valor = double.Parse(Console.ReadLine());

Pagamento pagamento = new Pagamento(valor, new Tenis(entrada));

if (entrada == "nike")
{
    CompraService compra = new CompraService(valor, new NikeTaxaService());
    compra.ProcessarFatura(pagamento);
    Console.WriteLine(pagamento.Fatura);
}
else if (entrada == "adidas")
{
    CompraService compra = new CompraService(valor, new AdidasTaxaService());
    compra.ProcessarFatura(pagamento);
    Console.WriteLine(pagamento.Fatura);
}




