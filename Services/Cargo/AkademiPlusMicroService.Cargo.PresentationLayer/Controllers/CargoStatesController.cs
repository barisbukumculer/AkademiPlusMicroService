using AkademiPlusMicroService.Cargo.BusinessLayer.Abstract;
using AkademiPlusMicroService.Cargo.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AkademiPlusMicroService.Cargo.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoStatesController : ControllerBase
    {
        private readonly ICargoStateService _cargoStateService;

        public CargoStatesController(ICargoStateService cargoStateService)
        {
            _cargoStateService = cargoStateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCargoState()
        {
            var value = await _cargoStateService.TGetAllAsync();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoState(CargoState cargoState)
        {
            await _cargoStateService.TCreateAsync(cargoState);
            return Ok("Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoState(CargoState cargoState)
        {
            await _cargoStateService.TUpdateAsync(cargoState);
            return Ok("Başarıyla Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCargoState(int id)
        {
            var value = await _cargoStateService.TGetByIdAsync(id);
            await _cargoStateService.TDeleteAsync(value);
            return Ok("Başarılı bir şekilde silindi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCatgoStateById(int id)
        {
            var value = await _cargoStateService.TGetByIdAsync(id);
            return Ok(value);
        }
    }
}
