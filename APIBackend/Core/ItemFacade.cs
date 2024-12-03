using APIBackend.DTOModels;
using APIBackend.Interface;
using Azure.Core;

namespace APIBackend.Core
{
    public class ItemFacade : IItemFacade
    {
        private readonly IItemService _itemservice;
        private readonly GeneralService _generalservice;

        public ItemFacade(IItemService itemservice, GeneralService generalservice)
        {
            _itemservice = itemservice;
            _generalservice = generalservice;
        }

        public async Task<ResultBase<LoadItemResponse>> LoadItemList(LoadUserRequest auth)
        {
            bool checkLogin = _generalservice.LoginCheck(auth.username, auth.token);
            var response = new ResultBase<LoadItemResponse>();

            if (checkLogin)
            {
                var result = await _itemservice.LoadItemList();

                if (result.Multiform.Any())
                {
                    response.code = (int)HTTPCode.OK;
                    response.Success = true;
                    response.Message = MessageConstants.S_SUCCESSFULLY;
                    response.Model = result;
                }

                _generalservice.ExtendSession(auth.username, auth.token);
            }
            else
            {
                response.Success = false;
                response.Message = MessageConstants.S_NOT_AUTHORIZE;
                response.code = (int)HTTPCode.Unauthorized;
            }

            return response;
        }

        public async Task<ResultBase<LoadItemResponseData>> LoadItemDetail(LoadUserRequest auth, string id)
        {
            bool checkLogin = _generalservice.LoginCheck(auth.username, auth.token);
            var response = new ResultBase<LoadItemResponseData>();

            if (checkLogin)
            {
                var result = await _itemservice.LoadItemDetail(id);

                if (!string.IsNullOrEmpty(result.Id))
                {
                    response.code = (int)HTTPCode.OK;
                    response.Success = true;
                    response.Message = MessageConstants.S_SUCCESSFULLY;
                    response.Model = result;
                }

                _generalservice.ExtendSession(auth.username, auth.token);
            }
            else
            {
                response.Success = false;
                response.Message = MessageConstants.S_NOT_AUTHORIZE;
                response.code = (int)HTTPCode.Unauthorized;
            }

            return response;
        }

        public async Task<ResultBase> SaveItem(LoadUserRequest auth, SaveItemRequest request)
        {
            bool checkLogin = _generalservice.LoginCheck(auth.username, auth.token);
            var response = new ResultBase();

            if (checkLogin)
            {
                var saveParam = new SaveItemParam
                {
                    Id = string.Empty,
                    category = request.category,
                    image = request.image,
                    name = request.name,
                    price = request.price,
                    stock = request.stock,
                    user_id = auth.username
                };

                var result = await _itemservice.SaveItem(saveParam);

                _generalservice.ExtendSession(auth.username, auth.token);

                return result;
            }
            else
            {
                response.Success = false;
                response.Message = MessageConstants.S_NOT_AUTHORIZE;
                response.code = (int)HTTPCode.Unauthorized;
            }

            return response;
        }

        public async Task<ResultBase> UpdateItem(LoadUserRequest auth, string id, SaveItemRequest request)
        {
            bool checkLogin = _generalservice.LoginCheck(auth.username, auth.token);
            var response = new ResultBase();

            if (checkLogin)
            {
                var saveParam = new SaveItemParam
                {
                    Id = id,
                    category = request.category,
                    image = request.image,
                    name = request.name,
                    price = request.price,
                    stock = request.stock,
                    user_id = auth.username
                };

                var result = await _itemservice.UpdateItem(saveParam);

                _generalservice.ExtendSession(auth.username, auth.token);

                return result;
            }
            else
            {
                response.Success = false;
                response.Message = MessageConstants.S_NOT_AUTHORIZE;
                response.code = (int)HTTPCode.Unauthorized;
            }

            return response;
        }

        public async Task<ResultBase> DeleteItem(LoadUserRequest auth, string id)
        {
            bool checkLogin = _generalservice.LoginCheck(auth.username, auth.token);
            var response = new ResultBase();

            if (checkLogin)
            {
                var result = await _itemservice.DeleteItem(id);

                _generalservice.ExtendSession(auth.username, auth.token);

                return result;
            }
            else
            {
                response.Success = false;
                response.Message = MessageConstants.S_NOT_AUTHORIZE;
                response.code = (int)HTTPCode.Unauthorized;
            }

            return response;
        }

        public async Task<ResultBase<LoadItemCategoryResponse>> LoadItemCategory(LoadUserRequest auth)
        {
            bool checkLogin = _generalservice.LoginCheck(auth.username, auth.token);
            var response = new ResultBase<LoadItemCategoryResponse>();

            if (checkLogin)
            {
                var result = await _itemservice.LoadItemCategory();

                if (result.Multiform.Any())
                {
                    response.code = (int)HTTPCode.OK;
                    response.Success = true;
                    response.Message = MessageConstants.S_SUCCESSFULLY;
                    response.Model = result;
                }

                _generalservice.ExtendSession(auth.username, auth.token);
            }
            else
            {
                response.Success = false;
                response.Message = MessageConstants.S_NOT_AUTHORIZE;
                response.code = (int)HTTPCode.Unauthorized;
            }

            return response;
        }

        public async Task<ResultBase<LoadItemResponse>> LoadItemStock(LoadUserRequest auth)
        {
            bool checkLogin = _generalservice.LoginCheck(auth.username, auth.token);
            var response = new ResultBase<LoadItemResponse>();

            if (checkLogin)
            {
                var result = await _itemservice.LoadItemList();

                if (result.Multiform.Any())
                {
                    response.code = (int)HTTPCode.OK;
                    response.Success = true;
                    response.Message = MessageConstants.S_SUCCESSFULLY;
                    response.Model = result;
                }

                _generalservice.ExtendSession(auth.username, auth.token);
            }
            else
            {
                response.Success = false;
                response.Message = MessageConstants.S_NOT_AUTHORIZE;
                response.code = (int)HTTPCode.Unauthorized;
            }

            return response;
        }
    }
}
