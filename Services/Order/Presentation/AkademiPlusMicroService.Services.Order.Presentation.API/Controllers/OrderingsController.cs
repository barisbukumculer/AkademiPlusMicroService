using AkademiPlusMicroService.Services.Order.Core.Application.Features.CQRS.Commands;
using AkademiPlusMicroService.Services.Order.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AkademiPlusMicroService.Services.Order.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderingList()
        {
            var values = await _mediator.Send(new GetAllOrderingQueryRequest());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommandRequest createOrderingCommandRequest)
        {
            await _mediator.Send(createOrderingCommandRequest);
            return Ok("Sipariş eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommandRequest(id));
            return Ok("Sipariş silindi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            var value = await _mediator.Send(new GetOrderingQueryRequest(id));
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommandRequest updateOrderingCommandRequest)
        {
            await _mediator.Send(updateOrderingCommandRequest);
            return Ok("Sipariş başarıyla güncellendi.");
        }
    }
}
   