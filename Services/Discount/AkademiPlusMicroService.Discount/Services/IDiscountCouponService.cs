using AkademiPlusMicroService.Discount.DTO_s;
using AkademiPlusMicroService.Shared.DTOs;

namespace AkademiPlusMicroService.Discount.Services
{
    public interface IDiscountCouponService
    {
        Task<Response<List<ResultDiscountCouponDTO>>> GetListAll(); 
        Task<Response<NoContent>> CreateDiscountCoupon(CreateDiscountCouponDTO createDiscountCouponDTO); 
        Task<Response<NoContent>> UpdateDiscountCoupon(UpdateDiscountCouponDTO updateDiscountCouponDTO); 
        Task<Response<NoContent>> DeleteDiscountCoupon(int id); 
    }
}
