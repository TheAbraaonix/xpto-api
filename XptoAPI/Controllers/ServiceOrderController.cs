using Microsoft.AspNetCore.Mvc;
using XptoAPI.Models;
using XptoAPI.Repositories;

namespace XptoAPI.Controllers
{
    [Route("api/service-order")]
    [ApiController]
    public class ServiceOrderController : ControllerBase
    {
        private readonly IServiceOrderRepository _repository;

        public ServiceOrderController(IServiceOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetAllServiceOrder")]
        public async Task<IActionResult> GetAllServiceOrder()
        {
            return Ok(await _repository.GetAllServiceOrderAsync());
        }

        [HttpGet]
        [Route("GetServiceOrderById/{id}")]
        public async Task<IActionResult> GetServiceOrderById(Guid id)
        {
            ServiceOrder serviceOrder = await _repository.GetServiceOrderByIdAsync(id);

            if (serviceOrder == null) return NotFound();

            return Ok(serviceOrder);
        }

        [HttpPost]
        [Route("CreateServiceOrder")]
        public async Task<IActionResult> CreateServiceOrder(ServiceOrder serviceOrder)
        {
            ServiceOrder createdServiceOrder = await _repository.CreateServiceOrderAsync(serviceOrder);

            if (serviceOrder == null) return BadRequest();

            return CreatedAtAction(nameof(CreateServiceOrder), new ServiceOrder { Id = createdServiceOrder.Id}, createdServiceOrder);
        }

        [HttpPut]
        [Route("UpdateServiceOrder")]
        public async Task<IActionResult> UpdateServiceOrder(ServiceOrder serviceOrder)
        {
            ServiceOrder updatedServiceOrder = await _repository.UpdateServiceOrderAsync(serviceOrder);

            if (serviceOrder == null) return BadRequest();

            return Ok(updatedServiceOrder);
        }

        [HttpDelete]
        [Route("DeleteServiceOrder")]
        public async Task<IActionResult> DeleteServiceOrder(ServiceOrder serviceOrder)
        {

           ServiceOrder deletedServiceOrder = await _repository.DeleteServiceOrderAsync(serviceOrder);

            if (serviceOrder == null) return BadRequest();

            return NoContent();
        }
    }
}