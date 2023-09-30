
namespace InjecaoDependenciaNelio.Services
{
    //realiza a interface
    class EUATaxService : ITaxService
    {
        public double Tax(double amount)
        {
            if (amount <= 100.0)
            {
                return amount * 0.3;
            }
            else
            {
                return amount * 0.16;
            }
        }
    }
}
