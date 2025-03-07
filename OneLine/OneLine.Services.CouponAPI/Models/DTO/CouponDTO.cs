namespace OneLine.Services.CouponAPI.Models.DTO
{
    public class CouponDTO
    {
        public string Code { get; set; } = null!;
        public int DiscountAmount { get; set; }
        public DateOnly ExpirationDate { get; set; }
    }
}
