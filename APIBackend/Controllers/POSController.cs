using APIBackend.Core;
using APIBackend.DTOModels;
using APIBackend.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIBackend.Controllers
{
    public class POSController : Controller
    {
        private readonly IPOSFacade _posfacade;

        public POSController(IPOSFacade posfacade)
        {
            _posfacade = posfacade;
        }

        [HttpPost("/pos/transaction")]
        public async Task<ActionResult> SaveTransaction(SaveTransactionRequest request)
        {
            string username = string.Empty;
            string token = string.Empty;

            if (Request.Headers.TryGetValue("username", out _) && Request.Headers.TryGetValue("token", out _))
            {
                username = Request.Headers["username"].FirstOrDefault();
                token = Request.Headers["token"].FirstOrDefault();
            }

            var auth = new LoadUserRequest
            {
                username = username,
                token = token,
            };

            var result = await _posfacade.SaveTransaction(auth, request);

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

        [HttpGet("/pos/transaction")]
        public async Task<ActionResult> LoadTransaction()
        {
            string username = string.Empty;
            string token = string.Empty;

            if (Request.Headers.TryGetValue("username", out _) && Request.Headers.TryGetValue("token", out _))
            {
                username = Request.Headers["username"].FirstOrDefault();
                token = Request.Headers["token"].FirstOrDefault();
            }

            var auth = new LoadUserRequest
            {
                username = username,
                token = token,
            };

            var result = await _posfacade.LoadTransaction(auth);

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

        [HttpGet("/pos/reports")]
        public async Task<ActionResult> LoadReportTransaction()
        {
            string username = string.Empty;
            string token = string.Empty;

            if (Request.Headers.TryGetValue("username", out _) && Request.Headers.TryGetValue("token", out _))
            {
                username = Request.Headers["username"].FirstOrDefault();
                token = Request.Headers["token"].FirstOrDefault();
            }

            var auth = new LoadUserRequest
            {
                username = username,
                token = token,
            };

            var result = await _posfacade.LoadReportTransaction(auth);

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
