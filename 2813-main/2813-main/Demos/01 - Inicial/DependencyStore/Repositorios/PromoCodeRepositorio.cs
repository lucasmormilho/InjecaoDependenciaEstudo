using Dapper;
using DependencyStore.Models;
using DependencyStore.Repositorios.Contratos;
using Microsoft.Data.SqlClient;

namespace DependencyStore.Repositorios
{
    public class PromoCodeRepositorio : IPromoCodeRepositorio
    {
        private readonly SqlConnection _connection;

        public PromoCodeRepositorio(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<PromoCode?> ObterPromoCodeAsync(string promoCode)
        {
            var query = $"SELECT * FROM PROMO_CODES WHERE CODE={promoCode}";
            return await _connection.QueryFirstOrDefaultAsync<PromoCode>(query);
        }
    }
}
