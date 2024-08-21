using XptoAPI.DTOs;

namespace XptoAPI.Services
{
    public interface IServiceOrderService
    {
        Task<IEnumerable<ServiceOrderViewModel>> GetAllServiceOrders();
        Task<ServiceOrderViewModel> GetServiceOrderById(Guid id);
        Task<ServiceOrderViewModel> CreateServiceOrder(ServiceOrderInputModel input);
        Task<ServiceOrderViewModel> UpdateServiceOrder(Guid id, ServiceOrderUpdateInputModel input);
        Task<ServiceOrderViewModel> DeleteServiceOrder(Guid id);
        Task<bool> ExistsClient(string cpf);
    }
}
