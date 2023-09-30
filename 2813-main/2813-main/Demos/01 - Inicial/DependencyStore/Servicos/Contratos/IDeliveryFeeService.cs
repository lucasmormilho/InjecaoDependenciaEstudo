namespace DependencyStore.Servicos.Contratos
{
    public interface IDeliveryFeeService
    {
        Task<decimal> ObterTaxaEntregaAsync(string cep);
    }
}
