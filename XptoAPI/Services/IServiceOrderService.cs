using XptoAPI.Models;

namespace XptoAPI.Services
{
    public interface IServiceOrderService
    {
        Task<IEnumerable<ServiceOrder>> GetAllServiceOrders();
        Task<ServiceOrder> GetServiceOrderById(Guid id);
        Task<ServiceOrder> CreateServiceOrder(ServiceOrder orderService);
        Task<ServiceOrder> UpdateServiceOrder(Guid id, ServiceOrder orderService);
        Task<ServiceOrder> DeleteServiceOrder(Guid id);
    }
}
