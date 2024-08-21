using Microsoft.EntityFrameworkCore;
using XptoAPI.Context;
using XptoAPI.Models;

namespace XptoAPI.Repositories
{
    public class ServiceExecuterRepository : IServiceExecuterRepository
    {
        private readonly AppDbContext _context;

        public ServiceExecuterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceExecuter> GetServiceExecuterByCnpjAsync(string cnpj)
        {
            ServiceExecuter? serviceExecuter = await _context.serviceExecuters.FirstOrDefaultAsync(c => c.Cnpj == cnpj);
            return serviceExecuter;
        }
    }
}
