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

        public async Task<ServiceOrder> UpdateServiceOrderAsync(ServiceOrder orderService)
        {
            _context.Set<ServiceOrder>().Update(orderService);
            await _context.SaveChangesAsync();
            return orderService;
        }

        public async Task<ServiceOrder> DeleteServiceOrderAsync(ServiceOrder orderService)
        {
            _context.Remove(orderService);
            await _context.SaveChangesAsync();
            return orderService;
        }
    }
}
