using DependencyStore.Servicos.Contratos;
using RestSharp;

namespace DependencyStore.Servicos
{
    public class DeliveryFeeService : IDeliveryFeeService
    {
        private readonly Configuration _configuration;

        public DeliveryFeeService(Configuration configuration)
        {
            _configuration = configuration;
        }

        public async Task<decimal> ObterTaxaEntregaAsync(string cep)
        {
            var client = new RestClient(_configuration.DeliveryFeeServiceUrl);
            var resquest = new RestRequest()
                .AddJsonBody(new
                {
                    ZipCode = cep
                });
            var response = await client.PostAsync<decimal>(resquest);
            return response < 5 ? 5 : response;
        }
    }
}
