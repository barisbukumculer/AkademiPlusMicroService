namespace AkademiPlusMicroService.Discount.DTO_s
{
    public class CreateDiscountCouponDTO
    {
        public string UserId { get; set; }
        public int Rate { get; set; }
        public string Code { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
