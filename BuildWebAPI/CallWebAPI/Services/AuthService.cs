using CallWebAPI.Model;
using CallWebAPI.Services.IServices;
using Microsoft.Extensions.Configuration;
using Utility;

namespace CallWebAPI.Services
{
    public class AuthService :BaseService, IAuthService
    {
        private readonly IHttpClientFactory  _authService;
        private string BaseUrl;
        public AuthService(IHttpClientFactory httpClientFactory,IConfiguration configuration):base(httpClientFactory)
        {
            _authService = httpClientFactory;
            BaseUrl = configuration.GetValue<string>("ServiceUrls:BuildWebAPI");
        }

        public Task<T> LoginAsync<T>(LoginRequestDTO loginRequestDTO)
        {
            var aaa = BaseUrl + "/api/Users/login";
            var result = new APIRequest()
            {
                ApiType = SD.ApiType.Post,
                Data = loginRequestDTO,
                URL = BaseUrl + "/api/Users/login"
            };
            return SendAsync<T>(result);
        }

        public Task<T> RegisterAsync<T>(RegisterRequestDTO registerRequestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
