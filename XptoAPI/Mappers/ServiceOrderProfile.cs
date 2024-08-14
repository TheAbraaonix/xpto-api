using AutoMapper;
using XptoAPI.DTOs;
using XptoAPI.Models;

namespace XptoAPI.Mappers
{
    public class ServiceOrderProfile : Profile
    {
        public ServiceOrderProfile() 
        {
            CreateMap<ServiceOrder, ServiceOrderInputModel>().ReverseMap();
            CreateMap<ServiceOrder, ServiceOrderViewModel>().ReverseMap();
            
            CreateMap<Client, ClientInputModel>().ReverseMap();
            CreateMap<Client, ClientViewModel>().ReverseMap();
            
            CreateMap<ServiceExecuter, ServiceExecuterInputModel>().ReverseMap();
            CreateMap<ServiceExecuter, ServiceExecuterViewModel>().ReverseMap();

            CreateMap<ServiceOrder, ServiceOrderUpdateInputModel>().ReverseMap();
        }
    }
}
