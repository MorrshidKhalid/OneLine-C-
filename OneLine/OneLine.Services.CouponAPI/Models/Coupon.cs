namespace OneLine.Services.CouponAPI.Models
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public string Code { get; set; } = null!;
        public int DiscountAmount { get; set; }
        public DateOnly ExpirationDate { get; set; }
    }
}
