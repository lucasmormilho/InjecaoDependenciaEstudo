using Dapper;
using DependencyStore.Models;
using DependencyStore.Repositorios.Contratos;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Primitives;

namespace DependencyStore.Repositorios
{
    public class CustumerRepositorio : ICustomerRepositorio
    {
        //imutavel
        //readonly só pode ser atribuida dentro do construtor
        private readonly SqlConnection _connection;

        //construtor
        public CustumerRepositorio(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<Customer?> ObterIdAsync(string customerId)
        {
            const string query = "SELECT [Id], [Name], [Email] FROM CUSTOMER WHERE ID=@id";
            return await _connection.QueryFirstOrDefaultAsync<Customer>(query, new 
            { 
                id = customerId 
            });
        }
    }
}
