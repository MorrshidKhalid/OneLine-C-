using Microsoft.AspNetCore.Mvc;
using OneLine.Services.CouponAPI.Models.DTO;
using OneLine.Services.CouponAPI.Service;

namespace OneLine.Services.CouponAPI.Controllers
{
    [Route("api/v1/coupon/")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService) => _couponService = couponService;


        [HttpGet("all", Name = "all")]
        public async Task<ResponseDTO> GetAllAsync() => await _couponService.AllCouponsAsync();


        [HttpGet("code/{code}", Name = "findByCode")]
        public async Task<ResponseDTO> GetByCodeAsync(string code) => await _couponService.FindCouponByCodeAsync(code);


        [HttpPost("insert", Name = "insert_coupon")]
        public async Task<ResponseDTO> CreateCoupon([FromBody] InsertUpdateCoupon coupon)
            => await _couponService.InsertAsync(coupon);


        [HttpPut("update/{id}")]
        public async Task<ResponseDTO> UpdateCoupon(int id, InsertUpdateCoupon wishToUpdate)
            => await _couponService.UpdateAsync(id, wishToUpdate);


        [HttpPut("renew/{id}", Name = "renew_coupun")]
        public async Task<ResponseDTO> RenewCoupon(int id, DateOnly newDate)
            => await _couponService.RenewCoupon(id, newDate);


        [HttpDelete("delete/{id}", Name = "deleteById")]
        public async Task<ResponseDTO> DeleteAsync(int id) => await _couponService.DeleteAsync(id);
        
        [HttpDelete("delete/code/{code}", Name = "deleteByCode")]
        public async Task<ResponseDTO> DeleteAsync(string code) => await _couponService.DeleteAsync(code);
    }
}
