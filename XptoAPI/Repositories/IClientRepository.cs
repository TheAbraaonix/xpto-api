using XptoAPI.Models;

namespace XptoAPI.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetClientByCpfAsync(string cpf);
    }
}
