using XptoAPI.Models;

namespace XptoAPI.Repositories
{
    public interface IServiceOrderRepository
    {
        Task<IEnumerable<ServiceOrder>> GetAllServiceOrderAsync();
        Task<ServiceOrder> GetServiceOrderByIdAsync(Guid id);
        Task<ServiceOrder> CreateServiceOrderAsync(ServiceOrder orderService);
        Task<ServiceOrder> UpdateServiceOrderAsync(Guid id, ServiceOrder orderService);
        Task<ServiceOrder> DeleteServiceOrderAsync(ServiceOrder orderService);
    }
}
