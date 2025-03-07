using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OneLine.Wep.Models;
using OneLine.Wep.Service.IService;

namespace OneLine.Wep.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService) => _couponService = couponService;

        public async Task<IActionResult> CouponIndex()
        {
            ResponseDTO? response = await _couponService.AllCouponsAsync();
            List<CouponDTO>? coupons = [];

            if (response != null && response.IsSuccess)
                coupons = JsonConvert
                    .DeserializeObject<List<CouponDTO>>(Convert.ToString(response.Result));
            else 
                TempData["error"] = response?.Message;

            return View(coupons);
        }

        public IActionResult CouponCreate() => View();

        [HttpPost]
        public async Task<IActionResult> CouponCreate(InsertUpdateCoupon model)
        {

            if (ModelState.IsValid)
            {
                ResponseDTO? response = await _couponService.InsertAsync(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = response?.Message;
                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                    return View(nameof(CouponCreate));
                }
                    
            }

            return View(model);
        }

        // To display coupon info before delete.
        public async Task<IActionResult> BeforeDelete(string code)
        {
            ResponseDTO? response = await _couponService.FindCouponByCodeAsync(code);

            if (response != null && response.IsSuccess)
            {
                CouponDTO? coupon = JsonConvert.DeserializeObject<CouponDTO>(Convert.ToString(response.Result));
                return View(coupon);
            }
            else
                TempData["error"] = response?.Message;

            return NotFound();
        }

        public async Task<IActionResult> CouponeDelete(string code)
        {
            ResponseDTO? response = await _couponService.DeleteAsync(code);

            return RedirectToAction(nameof(CouponIndex));
        }

    }
}
