using Microsoft.EntityFrameworkCore;
using XptoAPI.Context;
using XptoAPI.Models;

namespace XptoAPI.Repositories
{
    public class ServiceOrderRepository : IServiceOrderRepository
    {
        private readonly AppDbContext _context;

        public ServiceOrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceOrder>> GetAllServiceOrderAsync()
        {
            IEnumerable<ServiceOrder> serviceOrders = await _context.serviceOrders.Include(so => so.Client).Include(so => so.ServiceExecuter).ToListAsync();
            return serviceOrders;
        }

        public async Task<ServiceOrder> GetServiceOrderByIdAsync(Guid id)
        {
            ServiceOrder? serviceOrder = await _context.serviceOrders.Include(so => so.Client).Include(so => so.ServiceExecuter).FirstOrDefaultAsync(so => so.Id == id);
            return serviceOrder;
        }

        public async Task<ServiceOrder> CreateServiceOrderAsync(ServiceOrder orderService)
        {
            _context.serviceOrders.Add(orderService);
            await _context.SaveChangesAsync();
            return orderService;
        }

        public async Task<ServiceOrder> UpdateServiceOrderAsync(Guid id, ServiceOrder orderService)
        {
            ServiceOrder foundServiceOrder = await GetServiceOrderByIdAsync(id);
            Client? foundClient = await _context.clients.FindAsync(orderService.Client.Id);
            ServiceExecuter? foundServiceExecuter = await _context.serviceExecuters.FindAsync(orderService.ServiceExecuter.Id);

            if (foundServiceOrder == null || foundClient == null || foundServiceExecuter == null) return null;

            foundClient.Name = orderService.Client.Name;
            foundClient.Cpf = orderService.Client.Cpf;

            foundServiceExecuter.Name = orderService.ServiceExecuter.Name;
            foundServiceExecuter.Cnpj = orderService.ServiceExecuter.Cnpj;

            foundServiceOrder.Client = foundClient;
            foundServiceOrder.ServiceExecuter = foundServiceExecuter;
            foundServiceOrder.ServiceValue = orderService.ServiceValue;
            foundServiceOrder.ServiceDate = orderService.ServiceDate;
            foundServiceOrder.ServiceTitle = orderService.ServiceTitle;
            foundServiceOrder.ServiceNumber = orderService.ServiceNumber;

            await _context.SaveChangesAsync();
            return foundServiceOrder;
        }

        public async Task<ServiceOrder> DeleteServiceOrderAsync(ServiceOrder orderService)
        {
            _context.Remove(orderService);
            _context.serviceExecuters.Remove(orderService.ServiceExecuter);
            _context.clients.Remove(orderService.Client);
            await _context.SaveChangesAsync();
            return orderService;
        }
    }
}
