using CallWebAPI.Model;

namespace CallWebAPI.Services.IServices
{
    public interface IDatabaseServices
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(string id, string token);
        Task<T> CreatAsync<T>(CreatDevicesDto creatDevicesDto, string token);
        Task<T> UpdateAsync<T>(UpdataDevicesDto updataDevicesDto, string token);
        Task<T> Delete<T>(int id, string token);

    }
}
