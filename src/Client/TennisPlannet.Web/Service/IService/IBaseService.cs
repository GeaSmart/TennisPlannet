using TennisPlannet.Web.Models.Dto;

namespace TennisPlannet.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
