using CallWebAPI.Model;
using CallWebAPI.Services.IServices;
using Utility;

namespace CallWebAPI.Services
{
    public class DatabaseServices:BaseService,IDatabaseServices
    {
        private readonly IHttpClientFactory _clientFactory;
        private string _databaseURL;
        public DatabaseServices(IHttpClientFactory clientFactory,IConfiguration configuration):base(clientFactory)
        {
            _clientFactory = clientFactory;
            _databaseURL = configuration.GetValue<string>("ServiceUrls:BuildWebAPI");
        }
        public Task<T> CreatAsync<T>(CreatDevicesDto creatDevicesDto)
        {
            var result = SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.Get,
                Data = creatDevicesDto,
                URL = Path.Combine(_databaseURL, "api", "Device")
            });
            return result;
        }
        public Task<T> Delete<T>(int id)
        {
            throw new NotImplementedException();
        }
        public Task<T> GetAllAsync<T>()
        {
            var result = SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.Get,
                URL = Path.Combine(_databaseURL, "api", "")
            });
            return result;
        }
        public Task<T> GetAsync<T>(int id)
        {
            var result = SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.Get,
                URL = Path.Combine(_databaseURL, "api", "",$"{id}")
            });
            return result;
        }
        public Task<T> UpdateAsync<T>(UpdataDevicesDto updataDevicesDto)
        {
            var result = SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.Put,
                Data = updataDevicesDto,
                URL = Path.Combine(_databaseURL, "api", "Device")
            });
            return result;
        }
    }
}
