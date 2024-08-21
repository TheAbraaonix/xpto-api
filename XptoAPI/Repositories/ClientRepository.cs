using Microsoft.EntityFrameworkCore;
using XptoAPI.Context;
using XptoAPI.Models;

namespace XptoAPI.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Client> GetClientByCpfAsync(string cpf)
        {
            Client? client = await _context.clients.FirstOrDefaultAsync(c => c.Cpf == cpf);
            return client;
        }
    }
}
