using CallWebAPI.Model;

namespace CallWebAPI.Services.IServices
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDTO loginRequestDTO);
        Task<T> RegisterAsync<T>(RegisterRequestDTO registerRequestDTO);
    }
}
