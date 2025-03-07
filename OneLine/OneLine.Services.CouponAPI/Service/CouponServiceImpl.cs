using Microsoft.EntityFrameworkCore;
using OneLine.Services.CouponAPI.Data;
using OneLine.Services.CouponAPI.Models;
using OneLine.Services.CouponAPI.Models.DTO;

namespace OneLine.Services.CouponAPI.Service
{
    public class CouponServiceImpl : ICouponService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ResponseDTO _responseDTO;
        public CouponServiceImpl(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _responseDTO = new ResponseDTO();
        }


        public async Task<ResponseDTO> AllCouponsAsync()
        {
            
            if (!_appDbContext.Coupons.Any())
                return Return();

            _responseDTO.Result = await _appDbContext
                .Coupons.Select(coupon => new CouponDTO
                {
                    Code = coupon.Code,
                    DiscountAmount = coupon.DiscountAmount,
                    ExpirationDate = coupon.ExpirationDate,

                }).ToListAsync();

            return _responseDTO;
        }

        public async Task<ResponseDTO> FindCouponByCodeAsync(string code)
        {
            Coupon? result = await _appDbContext.Coupons.FirstOrDefaultAsync(coupon => coupon.Code == code);

            if (result == null)
                return Return();

            _responseDTO.Result = result;

            return _responseDTO;
        }

        public async Task<ResponseDTO> InsertAsync(InsertUpdateCoupon coupon)
        {

            var isExists = await FindCouponByCodeAsync(coupon.Code);
            if (isExists.IsSuccess)
                return Return(msg: "Coupon already exists");

            Coupon newCoupon = NewCoupon(coupon);

            await _appDbContext.Coupons.AddAsync(newCoupon);
            await _appDbContext.SaveChangesAsync();


            _responseDTO.Result = newCoupon;
            _responseDTO.Message = "New coupon was added";
            _responseDTO.IsSuccess = true;

            return _responseDTO;
        }

        public async Task<ResponseDTO> UpdateAsync(int id, InsertUpdateCoupon coupon)
        {

            if (id <= 0) 
                return Return(msg: $"Invalid id ({id})");

            var isExists = await FindCouponByIdAsync(id);
            if (!isExists)
                return Return(msg: "Coupon is not exists");

            var updatedCoupon = await _appDbContext
                .Coupons.SingleAsync(c => c.CouponId == id);

            updatedCoupon.Code = coupon.Code;
            updatedCoupon.DiscountAmount = coupon.DiscountAmount;

            await _appDbContext.SaveChangesAsync();

            _responseDTO.Result = updatedCoupon;
            _responseDTO.Message = "New info has been updated";
            _responseDTO.IsSuccess = true;

            return _responseDTO;
        }
        
        public async Task<ResponseDTO> RenewCoupon(int id, DateOnly date)
        {

            if (id <= 0)
                return Return(msg: $"Invalid id ({id})");

            var isExists = await FindCouponByIdAsync(id);
            if (!isExists)
                return Return(msg: "Coupon is not exists");


            var updatedCoupon = await _appDbContext
                .Coupons.SingleAsync(c => c.CouponId == id);

            updatedCoupon.ExpirationDate = date;
            await _appDbContext.SaveChangesAsync();

            _responseDTO.Result = updatedCoupon;
            _responseDTO.Message = "Coupon renew don";
            _responseDTO.IsSuccess = true;

            return _responseDTO;
        }

        public async Task<ResponseDTO> DeleteAsync(int id)
        {
            if (id <= 0)
                return Return(msg: $"Invalid id ({id})");

            var isExists = await FindCouponByIdAsync(id);
            if (!isExists)
                return Return(msg: "Coupon is not exists");


            Coupon coupon = await _appDbContext.Coupons
                .SingleAsync(coupon => coupon.CouponId == id);

            _appDbContext.Remove(coupon);
            await _appDbContext.SaveChangesAsync();

            _responseDTO.Result = null;
            _responseDTO.Message = $"Coupon with id ({id}) deleted successfully";
            _responseDTO.IsSuccess = true;

            return _responseDTO;
        }
        
        public async Task<ResponseDTO> DeleteAsync(string code)
        {
            

            var isExists = await FindCouponByCodeAsync(code);
            if (isExists == null)
                return Return(msg: "Coupon is not exists");


            Coupon coupon = await _appDbContext.Coupons
                .SingleAsync(coupon => coupon.Code == code);

            _appDbContext.Remove(coupon);
            await _appDbContext.SaveChangesAsync();

            _responseDTO.Result = null;
            _responseDTO.Message = $"Coupon with CODE ({code}) deleted successfully";
            _responseDTO.IsSuccess = true;

            return _responseDTO;
        }


        private ResponseDTO Return(bool flag = false, string msg = "No data to show")
        {
            _responseDTO.IsSuccess = flag;
            _responseDTO.Message = msg;

            return _responseDTO;
        }

        private async Task<bool> FindCouponByIdAsync(int id)
            => await _appDbContext.Coupons.SingleOrDefaultAsync(c => c.CouponId == id) != null;


        // To Create new Coupon Object.
        private static Coupon NewCoupon(InsertUpdateCoupon coupon) =>
            new()
            {
                Code = coupon.Code,
                DiscountAmount = coupon.DiscountAmount,
                ExpirationDate = coupon.ExpirationDate
            };
    }
}
