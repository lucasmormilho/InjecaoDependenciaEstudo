using DependencyStore.Repositorios;
using DependencyStore.Repositorios.Contratos;
using DependencyStore.Servicos;
using DependencyStore.Servicos.Contratos;
using Microsoft.Data.SqlClient;

namespace DependencyStore.Extensions
{
    public static class DependenciesExtension
    {
        //vai registrar as dependencias
        public static void AddSqlConnection(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddScoped<SqlConnection>(x => new SqlConnection(connectionString));
        }

        public static void AddRepositories(
            this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepositorio, CustumerRepositorio>();
            services.AddTransient<IPromoCodeRepositorio, PromoCodeRepositorio>();

        }

        public static void AddServices(
            this IServiceCollection services)
        {
            services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
        }
    }
}
