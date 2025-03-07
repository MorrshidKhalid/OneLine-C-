using OneLine.Wep.Models;

namespace OneLine.Wep.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDTO?> SendAsync(Request request);
    }
}
