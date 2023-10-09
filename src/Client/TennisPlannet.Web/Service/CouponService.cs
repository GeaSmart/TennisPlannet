using TennisPlannet.Web.Models.Dto;
using TennisPlannet.Web.Service.IService;
using static TennisPlannet.Web.Utils.Common;

namespace TennisPlannet.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService baseService;

        public CouponService(IBaseService baseService)
        {
            this.baseService = baseService;
        }
        public async Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return await baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.POST,
                Url = $"{CouponApiBase}api/coupon",
                Data = couponDto
            });
        }

        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.DELETE,
                Url = $"{CouponApiBase}api/coupon/{id}"
            });
        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            var x = new RequestDto
            {
                ApiType = ApiType.GET,
                Url = $"{CouponApiBase}api/coupon"
            };
            var y = await baseService.SendAsync(x);
            return y;
        }

        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.GET,
                Url = $"{CouponApiBase}api/coupon/GetByCode/{couponCode}"
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.GET,
                Url = $"{CouponApiBase}api/coupon//{id}"
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await baseService.SendAsync(new RequestDto
            {
                ApiType = ApiType.PUT,
                Url = $"{CouponApiBase}api/coupon",
                Data = couponDto
            });
        }
    }
}
