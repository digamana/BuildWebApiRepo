using CallWebAPI.Model;

namespace CallWebAPI.Services.IServices
{
    public interface IDatabaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreatAsync<T>(CreatDevicesDto creatDevicesDto);
        Task<T> UpdateAsync<T>(UpdataDevicesDto updataDevicesDto);
        Task<T> Delete<T>(int id);
    }
}
