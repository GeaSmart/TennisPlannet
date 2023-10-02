using AutoMapper;
using Coupon.Api.Data;
using Coupon.Api.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coupon.Api.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private ResponseDto response;

        public CouponController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                IEnumerable<Models.Coupon> listCoupons = await context.Coupons.ToListAsync();
                response.Result = mapper.Map<IEnumerable<CouponDto>>(listCoupons);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }        
        
        [HttpGet("{id:int}")]
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                var coupon = await context.Coupons.SingleAsync(x => x.CouponId == id);
                response.Result = mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet("GetByCode/{code}")]
        public async Task<ResponseDto> GetByCode(string code)
        {
            try
            {
                var coupon = await context.Coupons.SingleAsync(x => x.CouponCode.ToLower() == code.ToLower());
                response.Result = mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        public async Task<ResponseDto> Post(CouponDto couponDto)
        {
            try
            {
                var coupon = mapper.Map<Models.Coupon>(couponDto);
                context.Coupons.Add(coupon);
                await context.SaveChangesAsync();
                response.Result = mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPut]
        public async Task<ResponseDto> Put(CouponDto couponDto)
        {
            try
            {
                var coupon = mapper.Map<Models.Coupon>(couponDto);
                context.Coupons.Update(coupon);
                await context.SaveChangesAsync();

                response.Result = mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpDelete("{id:int}")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                var coupon = await context.Coupons.FirstAsync(x => x.CouponId == id);
                context.Coupons.Remove(coupon);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

    }
}
