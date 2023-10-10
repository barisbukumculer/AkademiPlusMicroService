using AkademiPlusMicroService.Services.Order.Core.Application.Features.CQRS.Commands;
using AkademiPlusMicroService.Services.Order.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AkademiPlusMicroService.Services.Order.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdressesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task< IActionResult> GetAdressList()
        {
            var values = await _mediator.Send(new GetAllAdressQueryRequest());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdress(CreateAdressCommandRequest createAdressCommandRequest)
        {
            await _mediator.Send(createAdressCommandRequest);
            return Ok("Adres başarıyla eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAdress(int id)
        {
            await _mediator.Send(new RemoveAdressCommandRequest(id));
            return Ok("Adres başarıyla silindi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdressById(int id)
        {
            var value =await _mediator.Send(new GetAdressQueryRequest(id));
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAdress(UpdateAdressCommandRequest updateAdressCommandRequest) 
        {
            await _mediator.Send(updateAdressCommandRequest);
            return Ok("Adres başarıyla güncellendi.");
        }
    }
}
