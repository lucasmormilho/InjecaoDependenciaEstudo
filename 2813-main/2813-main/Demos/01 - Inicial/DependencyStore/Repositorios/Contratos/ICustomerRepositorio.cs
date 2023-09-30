using DependencyStore.Models;

namespace DependencyStore.Repositorios.Contratos
{
    public interface ICustomerRepositorio
    {
        Task<Customer?> ObterIdAsync(string custumerId);
    }
}
