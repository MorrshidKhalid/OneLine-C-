namespace OneLine.Wep.Models
{
    public class CouponDTO
    {
        public string Code { get; set; } = null!;
        public int DiscountAmount { get; set; }
        public DateOnly ExpirationDate { get; set; }
    }
}
