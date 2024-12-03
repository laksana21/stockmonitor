using APIBackend.DTOModels;
using APIBackend.Interface;
using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APIBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserFacade _userfacade;

        public UserController(IUserFacade userfacade)
        {
            _userfacade = userfacade;
        }

        [HttpPost("/login")]
        public async Task<ActionResult> Login(LoadLoginRequest request)
        {
            var result = await _userfacade.Login(request);

            switch (result.code)
            {
                case (int)HTTPCode.OK:
                    return Ok(result);
                case (int)HTTPCode.Unauthorized:
                    return Unauthorized(result);
                case (int)HTTPCode.Bad_Request:
                    return BadRequest(result);
                default:
                    return Accepted(result);
            }
        }

        [HttpPost("/logout")]
        public async Task<ActionResult> Logout(LoadUserRequest request)
        {
            var result = await _userfacade.Logout(request);

            switch (result.code)
            {
                case (int)HTTPCode.OK:
                    return Ok(result);
                case (int)HTTPCode.Unauthorized:
                    return Unauthorized(result);
                case (int)HTTPCode.Bad_Request:
                    return BadRequest(result);
                default:
                    return Accepted(result);
            }
        }

        [HttpPost("/user/getdata")]
        public async Task<ActionResult> GetData(LoadUserRequest request)
        {
            var result = await _userfacade.GetUserData(request);

            switch (result.code)
            {
                case (int)HTTPCode.OK:
                    return Ok(result);
                case (int)HTTPCode.Unauthorized:
                    return Unauthorized(result);
                case (int)HTTPCode.Bad_Request:
                    return BadRequest(result);
                default:
                    return Accepted(result);
            }
        }
    }
}
