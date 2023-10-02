using AutoMapper;
using Coupon.Api.Models.Dto;

namespace Coupon.Api.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CouponDto, Models.Coupon>().ReverseMap();            
        }
    }
}
