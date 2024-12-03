using APIBackend.Core;
using APIBackend.DTOModels;
using APIBackend.Interface;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace APIBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemFacade _itemfacade;

        public ItemController(IItemFacade itemfacade)
        {
            _itemfacade = itemfacade;
        }

        [HttpGet("/items")]
        public async Task<ActionResult> LoadItemList()
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

            var result = await _itemfacade.LoadItemList(auth);

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

        [HttpGet("/items/{id}")]
        public async Task<ActionResult> LoadItemDetail(string id)
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

            var result = await _itemfacade.LoadItemDetail(auth, id);

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

        [HttpPost("/items")]
        public async Task<ActionResult> SaveItem(SaveItemRequest request)
        {
            string username = string.Empty;
            string token = string.Empty;
            var header = Request.Headers;

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

            var result = await _itemfacade.SaveItem(auth, request);

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

        [HttpPut("/items/{id}")]
        public async Task<ActionResult> UpdateItem(string id, SaveItemRequest request)
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

            var result = await _itemfacade.UpdateItem(auth, id, request);

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

        [HttpDelete("/items/{id}")]
        public async Task<ActionResult> DeleteItem(string id)
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

            var result = await _itemfacade.DeleteItem(auth, id);

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

        [HttpGet("/items/category")]
        public async Task<ActionResult> LoadItemCategoryList()
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

            var result = await _itemfacade.LoadItemCategory(auth);

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

        [HttpGet("/items/stock")]
        public async Task<ActionResult> LoadItemStock()
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

            var result = await _itemfacade.LoadItemStock(auth);

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
