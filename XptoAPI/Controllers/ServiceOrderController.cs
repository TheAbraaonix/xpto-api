using Microsoft.AspNetCore.Mvc;
using XptoAPI.DTOs;
using XptoAPI.Exceptions;
using XptoAPI.Models;
using XptoAPI.Services;

namespace XptoAPI.Controllers
{
    [Route("api/service-order")]
    [ApiController]
    public class ServiceOrderController : ControllerBase
    {
        private readonly IServiceOrderService _service;

        public ServiceOrderController(IServiceOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAllServiceOrder")]
        public async Task<IActionResult> GetAllServiceOrder()
        {
            return Ok(await _service.GetAllServiceOrders());
        }

        [HttpGet]
        [Route("GetServiceOrderById/{id}")]
        public async Task<IActionResult> GetServiceOrderById(Guid id)
        {
            ServiceOrderViewModel serviceOrderViewModel = await _service.GetServiceOrderById(id);

            if (serviceOrderViewModel == null) return NotFound($"The service order with id {id} does not exist.");

            return Ok(serviceOrderViewModel);
        }

        [HttpPost]
        [Route("CreateServiceOrder")]
        public async Task<IActionResult> CreateServiceOrder(ServiceOrderInputModel input)
        {
            try
            {
                ServiceOrderViewModel createdServiceOrder = await _service.CreateServiceOrder(input);

                if (createdServiceOrder == null) return BadRequest();

                return CreatedAtAction(nameof(CreateServiceOrder), new ServiceOrder { Id = createdServiceOrder.Id }, createdServiceOrder);
            }
            catch (RecordAlreadyExistsException ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateServiceOrder/{id}")]
        public async Task<IActionResult> UpdateServiceOrder(Guid id, ServiceOrderUpdateInputModel input)
        {   
            ServiceOrderViewModel updatedServiceOrder = await _service.UpdateServiceOrder(id, input);

            if (updatedServiceOrder == null) return BadRequest($"The service order with id {id} does not exist.");

            return Ok(updatedServiceOrder);
        }

        [HttpDelete]
        [Route("DeleteServiceOrder/{id}")]
        public async Task<IActionResult> DeleteServiceOrder(Guid id)
        {

            ServiceOrderViewModel deletedServiceOrder = await _service.DeleteServiceOrder(id);

            if (deletedServiceOrder == null) return BadRequest($"The service order with id {id} does not exist.");

            return NoContent();
        }
    }
}