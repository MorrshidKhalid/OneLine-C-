using OneLine.Wep.Models;

namespace OneLine.Wep.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDTO?> AllCouponsAsync();
        Task<ResponseDTO?> FindCouponByCodeAsync(string code);
        Task<ResponseDTO?> InsertAsync(InsertUpdateCoupon coupon);
        Task<ResponseDTO?> UpdateAsync(int id, InsertUpdateCoupon coupon);
        Task<ResponseDTO?> RenewCoupon(int id, DateOnly date);
        Task<ResponseDTO?> DeleteAsync(int id);
        Task<ResponseDTO?> DeleteAsync(string code);

    }
}
