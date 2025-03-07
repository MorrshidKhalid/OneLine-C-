using OneLine.Wep.Models;
using OneLine.Wep.Service.IService;
using static OneLine.Wep.Utility.SD;

namespace OneLine.Wep.Service
{
    public class CouponServiceImpl : ICouponService
    {
        private readonly IBaseService _baseService;
        private const string BASE_ROUTE = "/api/v1/coupon/";

        public CouponServiceImpl(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO?> AllCouponsAsync()
        {
            return await _baseService.SendAsync(
                new Request()
                {
                    ApiType = ApiType.GET,
                    Url = CouponAPIBase + BASE_ROUTE + "all"
                });
        }

        public async Task<ResponseDTO?> DeleteAsync(int id)
        {
            return await _baseService.SendAsync(
                new Request()
                {
                    ApiType = ApiType.DELETE,
                    Url = CouponAPIBase + BASE_ROUTE + "delete/" + id
                });
        }
        
        public async Task<ResponseDTO?> DeleteAsync(string code)
        {
            return await _baseService.SendAsync(
                new Request()
                {
                    ApiType = ApiType.DELETE,
                    Url = CouponAPIBase + BASE_ROUTE + "delete/code/" + code
                });
        }

        public async Task<ResponseDTO?> FindCouponByCodeAsync(string code)
        {
            return await _baseService.SendAsync(
            new Request()
            {
                ApiType = ApiType.GET,
                Url = CouponAPIBase + BASE_ROUTE + "code/" + code
            });
        }

        public async Task<ResponseDTO?> InsertAsync(InsertUpdateCoupon coupon)
        {
            return await _baseService.SendAsync(
                new Request()
                {
                    ApiType = ApiType.POST,
                    Url = CouponAPIBase + BASE_ROUTE + "insert",
                    Data = coupon
                });
        }

        public async Task<ResponseDTO?> RenewCoupon(int id, DateOnly date)
        {
            return await _baseService.SendAsync(
                new Request()
                {
                    ApiType = ApiType.PUT,
                    Url = CouponAPIBase + BASE_ROUTE + "renew/" + id,
                    Data = date
                });
        }

        public async Task<ResponseDTO?> UpdateAsync(int id, InsertUpdateCoupon coupon)
        {
            return await _baseService.SendAsync(
                new Request()
                {
                    ApiType = ApiType.PUT,
                    Url = CouponAPIBase + BASE_ROUTE + "update/" + id,
                    Data = coupon
                });
        }
    }
}
