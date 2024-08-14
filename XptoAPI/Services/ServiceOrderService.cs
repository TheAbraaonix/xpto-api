using XptoAPI.Models;
using XptoAPI.Repositories;

namespace XptoAPI.Services
{
    public class ServiceOrderService : IServiceOrderService
    {
        private readonly IServiceOrderRepository _repository;

        public ServiceOrderService(IServiceOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ServiceOrder>> GetAllServiceOrders()
        {
            IEnumerable<ServiceOrder> serviceOrders = await _repository.GetAllServiceOrderAsync();
            return serviceOrders;
        }

        public async Task<ServiceOrder> GetServiceOrderById(Guid id)
        {
            ServiceOrder? serviceOrder = await _repository.GetServiceOrderByIdAsync(id);

            if (serviceOrder == null) return null;

            return serviceOrder;
        }

        public async Task<ServiceOrder> CreateServiceOrder(ServiceOrder orderService)
        {
            if (orderService == null) return null;

            ServiceOrder createdServiceOrder = await _repository.CreateServiceOrderAsync(orderService);
            return createdServiceOrder;
        }

        public async Task<ServiceOrder> UpdateServiceOrder(Guid id, ServiceOrder orderService)
        {
            ServiceOrder? foundServiceOrder = await _repository.GetServiceOrderByIdAsync(id);

            if (foundServiceOrder == null) return null;

            ServiceOrder updatedServiceOrder = await _repository.UpdateServiceOrderAsync(id, orderService);
            return updatedServiceOrder;
        }

        public async Task<ServiceOrder> DeleteServiceOrder(Guid id)
        {
            ServiceOrder? foundServiceOrder = await _repository.GetServiceOrderByIdAsync(id);

            if (foundServiceOrder == null) return null;

            ServiceOrder deletedServiceOrder = await _repository.DeleteServiceOrderAsync(foundServiceOrder);
            return deletedServiceOrder;
        } 
    }
}
