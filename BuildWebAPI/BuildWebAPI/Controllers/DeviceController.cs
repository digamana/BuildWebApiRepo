using AutoMapper;
using BuildWebAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BuildWebAPI.Controllers
{
    [Route("api/Device")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        protected APIResponse _response;

        public DeviceController()
        {
            this._response = new APIResponse();
        }




        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<APIResponse>> GetDevices() 
        {
            try
            {
                var result = await new DeviceList().GetDevices();
                _response.Result = result;
                _response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess= false;
                _response.ErrMessage =new List<string>() { ex.ToString()};
            }
            return _response;
        }

        [HttpGet("ItemName",Name = "GetDevices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<DevicesDto>> GetDevices(string ItemName)
        {
            var Reuslt = DeviceStore.GetDevices.Where(c => c.ItemName.Contains(ItemName)).FirstOrDefault();
            _response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(Reuslt);
        }

        [HttpPost]
        public async Task<ActionResult<CreatDevicesDto>> CreatDevices([FromBody] CreatDevicesDto devicesDto)
        {
            if (devicesDto == null) return BadRequest(devicesDto);
            var myDB = new MyDatabase();
            await myDB.GetDevices();
            //var Model = new Devices()
            //{
            //Id= devicesDto.Id,
            //DeviceTypeId=devicesDto.DeviceTypeId,
            //ItemDescription=devicesDto.ItemDescription,
            //ItemName    =devicesDto.ItemName,
            //};
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreatDevicesDto, Devices>());
            IMapper mapper = config.CreateMapper();
            var Model = mapper.Map<Devices>(devicesDto);
            myDB.Add(Model);
            return CreatedAtRoute("GetDevices",new { ItemName= devicesDto.ItemName }, devicesDto);
        }
    }

}
