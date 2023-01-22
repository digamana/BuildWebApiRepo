using CallWebAPI.Model;

namespace CallWebAPI.Services.IServices
{
    public interface IBaseService
    {
        APIRequest apiRequest { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
