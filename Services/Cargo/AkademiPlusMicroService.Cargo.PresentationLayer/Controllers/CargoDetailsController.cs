using AkademiPlusMicroService.Cargo.BusinessLayer.Abstract;
using AkademiPlusMicroService.Cargo.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AkademiPlusMicroService.Cargo.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCargoDetail()
        {
            var value = await _cargoDetailService.TGetAllAsync();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoDetail(CargoDetail cargoDetail)
        {
            await _cargoDetailService.TCreateAsync(cargoDetail);
            return Ok("Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoDetail(CargoDetail cargoDetail)
        {
            await _cargoDetailService.TUpdateAsync(cargoDetail);
            return Ok("Başarıyla Güncellendi");
        }
        [HttpDelete]    
        public async Task<IActionResult> DeleteCargoDetail(int id)
        {
            var value= await _cargoDetailService.TGetByIdAsync(id);
            await _cargoDetailService.TDeleteAsync(value);
            return Ok("Başarılı bir şekilde silindi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCatgoDetailById(int id)
        {
            var value = await _cargoDetailService.TGetByIdAsync(id);
            return Ok(value);
        }
    }
}
