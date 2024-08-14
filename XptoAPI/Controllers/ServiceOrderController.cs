using Microsoft.AspNetCore.Mvc;
using XptoAPI.Models;
using XptoAPI.Repositories;
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
            ServiceOrder serviceOrder = await _service.GetServiceOrderById(id);

            if (serviceOrder == null) return NotFound($"The service order with id {id} does not exist.");

            return Ok(serviceOrder);
        }

        [HttpPost]
        [Route("CreateServiceOrder")]
        public async Task<IActionResult> CreateServiceOrder(ServiceOrder serviceOrder)
        {
            ServiceOrder createdServiceOrder = await _service.CreateServiceOrder(serviceOrder);

            if (serviceOrder == null) return BadRequest();

            return CreatedAtAction(nameof(CreateServiceOrder), new ServiceOrder { Id = createdServiceOrder.Id}, createdServiceOrder);
        }

        [HttpPut]
        [Route("UpdateServiceOrder/{id}")]
        public async Task<IActionResult> UpdateServiceOrder(Guid id, ServiceOrder serviceOrder)
        {
            ServiceOrder updatedServiceOrder = await _service.UpdateServiceOrder(id, serviceOrder);

            if (updatedServiceOrder == null) return BadRequest($"The service order with id {id} does not exist.");

            return Ok(updatedServiceOrder);
        }

        [HttpDelete]
        [Route("DeleteServiceOrder/{id}")]
        public async Task<IActionResult> DeleteServiceOrder(Guid id)
        {

           ServiceOrder deletedServiceOrder = await _service.DeleteServiceOrder(id);

            if (deletedServiceOrder == null) return BadRequest($"The service order with id {id} does not exist.");

            return NoContent();
        }
    }
}