using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TennisPlannet.Web.Models.Dto;
using TennisPlannet.Web.Service.IService;

namespace TennisPlannet.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService couponService;

        public CouponController(ICouponService couponService)
        {
            this.couponService = couponService;
        }
        public async Task<IActionResult> CouponIndex()
        {
            var listCoupons = new List<CouponDto>();
            ResponseDto? response = await couponService.GetAllCouponsAsync();

            if(response != null && response.IsSuccess)
            {
                listCoupons = JsonSerializer.Deserialize<List<CouponDto>>
                    (response.Result.ToString());
            }
            return View(listCoupons);
        }
    }
}
