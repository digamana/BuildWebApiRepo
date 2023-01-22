using CallWebAPI.Model;
using CallWebAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CallWebAPI.Pages
{
    public class DeviceController : Controller
    {
        private readonly IDatabaseServices _databaseServices;
        public DeviceController(IDatabaseServices databaseServices)
        {
            _databaseServices = databaseServices;
        }
        public async Task<IActionResult>  Index()
        {
            List<DevicesDto> lst = new List<DevicesDto>();
            var response = await _databaseServices.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                lst = JsonConvert.DeserializeObject<List<DevicesDto>>(Convert.ToString(response.Result));
            }
            return View(lst);
        }
    }
}
