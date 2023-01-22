using CallWebAPI.Model;
using CallWebAPI.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Utility;

namespace CallWebAPI.Controllers
{
    public class DatabaseController : Controller
    {
        private IDatabaseServices _databaseServices;
        public DatabaseController(IDatabaseServices databaseServices)
        {
            _databaseServices = databaseServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> IndexDB()
        {
            List<DevicesDto> list = new List<DevicesDto>();
            var response = await _databaseServices.GetAllAsync<APIResponse>( HttpContext.Session.GetString(SD.TokenSession));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<DevicesDto>>($"{response.Result}");
            }
            return View(list);  
        }
        public async Task<IActionResult> OneDB(string id)
        {
            List<DevicesDto> list = new List<DevicesDto>();
            var response = await _databaseServices.GetAsync<APIResponse>(id,HttpContext.Session.GetString(SD.TokenSession));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<DevicesDto>>($"{response.Result}");
            }
            return View(list);
        }
        public async Task<IActionResult> CreatDB()
        {
            List<DevicesDto> list = new List<DevicesDto>();
            var aaa = new CreatDevicesDto
            {
                Id = 1
            };
            var response = await _databaseServices.CreatAsync<APIResponse>(aaa,  HttpContext.Session.GetString(SD.TokenSession));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<DevicesDto>>($"{response.Result}");
            }
            return View(list);
        }
        [Authorize(Roles = "Center")]
        public async Task<IActionResult> DeleteDB()
        {
            return View();
        }

    }
}
