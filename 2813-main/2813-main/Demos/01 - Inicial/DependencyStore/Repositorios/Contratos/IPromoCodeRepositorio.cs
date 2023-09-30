using DependencyStore.Models;
using Microsoft.Extensions.Primitives;

namespace DependencyStore.Repositorios.Contratos
{
    public interface IPromoCodeRepositorio
    {
        Task<PromoCode?> ObterPromoCodeAsync(string promoCode);
    }
}
