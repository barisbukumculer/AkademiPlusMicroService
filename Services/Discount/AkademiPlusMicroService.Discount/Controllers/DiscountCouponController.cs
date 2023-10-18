using AkademiPlusMicroService.Discount.DTO_s;
using AkademiPlusMicroService.Discount.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AkademiPlusMicroService.Discount.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCouponController : ControllerBase
    {
        private readonly IDiscountCouponService _discountCouponService;

        public DiscountCouponController(IDiscountCouponService discountCouponService)
        {
            _discountCouponService = discountCouponService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDTO createDiscountCouponDTO)
        {
          await  _discountCouponService.CreateDiscountCoupon(createDiscountCouponDTO);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountCouponService.DeleteDiscountCoupon(id);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDiscountCoupon()
        {
          var values=  await _discountCouponService.GetListAll();
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDTO updateDiscountCouponDTO)
        {
            await _discountCouponService.UpdateDiscountCoupon(updateDiscountCouponDTO);
            return Ok();
        }
    }
}
