﻿using AutoMapper;
using XptoAPI.DTOs;
using XptoAPI.Exceptions;
using XptoAPI.Models;
using XptoAPI.Repositories;

namespace XptoAPI.Services
{
    public class ServiceOrderService : IServiceOrderService
    {
        private readonly IServiceOrderRepository _repository;
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ServiceOrderService(IServiceOrderRepository repository, IClientRepository clientRepository, IMapper mapper)
        {
            _repository = repository;
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ServiceOrderViewModel>> GetAllServiceOrders()
        {
            IEnumerable<ServiceOrder> serviceOrders = await _repository.GetAllServiceOrderAsync();
            IEnumerable<ServiceOrderViewModel> serviceOrderViewModels = _mapper.Map<IEnumerable<ServiceOrderViewModel>>(serviceOrders);
            return serviceOrderViewModels;
        }

        public async Task<ServiceOrderViewModel> GetServiceOrderById(Guid id)
        {
            ServiceOrder? serviceOrder = await _repository.GetServiceOrderByIdAsync(id);

            if (serviceOrder == null) return null;

            ServiceOrderViewModel serviceOrderViewModel = _mapper.Map<ServiceOrderViewModel>(serviceOrder);
            return serviceOrderViewModel;
        }

        public async Task<ServiceOrderViewModel> CreateServiceOrder(ServiceOrderInputModel input)
        {
            if (input == null) return null;
            
            if (await ExistsClient(input.Client.Cpf))
            {
                throw new RecordAlreadyExistsException("This CPF already exists in the database.");
            }

            ServiceOrder serviceOrder = _mapper.Map<ServiceOrder>(input);
            await _repository.CreateServiceOrderAsync(serviceOrder);
            return _mapper.Map<ServiceOrderViewModel>(serviceOrder);
        }

        public async Task<ServiceOrderViewModel> UpdateServiceOrder(Guid id, ServiceOrderUpdateInputModel input)
        {
            ServiceOrder? foundServiceOrder = await _repository.GetServiceOrderByIdAsync(id);

            if (foundServiceOrder == null) return null;

            ServiceOrder serviceOrder = _mapper.Map<ServiceOrder>(input);
            ServiceOrder updatedServiceOrder = await _repository.UpdateServiceOrderAsync(id, serviceOrder);
            ServiceOrderViewModel serviceOrderViewModel = _mapper.Map<ServiceOrderViewModel>(updatedServiceOrder);
            return serviceOrderViewModel;
        }

        public async Task<ServiceOrderViewModel> DeleteServiceOrder(Guid id)
        {
            ServiceOrder? foundServiceOrder = await _repository.GetServiceOrderByIdAsync(id);

            if (foundServiceOrder == null) return null;

            ServiceOrder deletedServiceOrder = await _repository.DeleteServiceOrderAsync(foundServiceOrder);
            ServiceOrderViewModel deletedServiceOrderViewModel = _mapper.Map<ServiceOrderViewModel>(deletedServiceOrder);
            return deletedServiceOrderViewModel;
        }

        public async Task<bool> ExistsClient(string cpf)
        {
            Client client = await _clientRepository.GetClientByCpfAsync(cpf);

            if (client == null) return false;

            return true;
        }
    }
}
