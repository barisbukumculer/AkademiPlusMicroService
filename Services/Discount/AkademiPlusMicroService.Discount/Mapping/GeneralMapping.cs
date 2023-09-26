using AkademiPlusMicroService.Discount.DTO_s;
using AkademiPlusMicroService.Discount.Models;
using AutoMapper;

namespace AkademiPlusMicroService.Discount.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<DiscountCoupon,ResultDiscountCouponDTO>().ReverseMap();
            CreateMap<DiscountCoupon,CreateDiscountCouponDTO>().ReverseMap();
            CreateMap<DiscountCoupon,UpdateDiscountCouponDTO>().ReverseMap();
        }
    }
}
