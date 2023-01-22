using CallWebAPI.Model;
using CallWebAPI.Services.IServices;
using Newtonsoft.Json.Linq;
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
        public Task<T> CreatAsync<T>(CreatDevicesDto creatDevicesDto, string token)
        {
            var result = SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.Get,
                Data = creatDevicesDto,
                URL = _databaseURL+ "/api/Device/A" ,
                Token = token

            });
            return result;
        }
        public Task<T> Delete<T>(int id, string token)
        {
            throw new NotImplementedException();
        }
        public Task<T> GetAllAsync<T>(string token)
        {
            var result = SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.Get,
                URL =  _databaseURL + "/api/Device",
                Token = token
            });
            return result;
        }
        public Task<T> GetAsync<T>(string id, string token)
        {
            var result = SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.Get,
                URL = _databaseURL + $"/api/Device/ItemName?ItemName={id}",
                Token = token
            });
            return result;
        }
        public Task<T> UpdateAsync<T>(UpdataDevicesDto updataDevicesDto, string token)
        {
            var result = SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.Put,
                Data = updataDevicesDto,
                URL = Path.Combine(_databaseURL, "api", "Device"),
                Token = token
            });
            return result;
        }
    }
}
