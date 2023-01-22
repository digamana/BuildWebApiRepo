using BuildWebAPI.Model;
using BuildWebAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BuildWebAPI.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        protected APIResponse _response;
        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _response = new APIResponse();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var logiResponse = await _userRepo.Login(model);

            _response.HttpStatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result=logiResponse;
            return Ok(_response);
        }
    }
}
