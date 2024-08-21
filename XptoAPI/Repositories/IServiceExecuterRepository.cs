using XptoAPI.Models;

namespace XptoAPI.Repositories
{
    public interface IServiceExecuterRepository
    {
        Task<ServiceExecuter> GetServiceExecuterByCnpjAsync(string cnpj);
    }
}
