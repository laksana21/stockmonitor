using APIBackend.DTOModels;
using APIBackend.Interface;

namespace APIBackend.Core
{
    public class UserFacade : IUserFacade
    {
        private readonly IUserService _userservice;
        private readonly GeneralService _generalservice;

        public UserFacade(IUserService userservice, GeneralService generalservice)
        {
            _userservice = userservice;
            _generalservice = generalservice;
        }

        public async Task<ResultBase<LoadUserResponse>> GetUserData(LoadUserRequest request)
        {
            bool checkLogin = _generalservice.LoginCheck(request.username, request.token);
            var response = new ResultBase<LoadUserResponse>();

            if (checkLogin)
            {
                var result = await _userservice.GetUserData(request);

                if (!string.IsNullOrEmpty(result.token))
                {
                    response.code = (int)HTTPCode.OK;
                    response.Success = true;
                    response.Message = MessageConstants.S_SUCCESSFULLY;
                    response.Model = result;
                }
            }
            else
            {
                response.Success = false;
                response.Message = MessageConstants.S_NOT_AUTHORIZE;
                response.code = (int)HTTPCode.Unauthorized;
            }

            return response;
        }

        public async Task<ResultBase<LoadUserResponse>> Login(LoadLoginRequest request)
        {
            var result = await _userservice.Login(request);
            var response = new ResultBase<LoadUserResponse>();

            if (!string.IsNullOrEmpty(result.token))
            {
                response.code = (int)HTTPCode.OK;
                response.Success = true;
                response.Message = MessageConstants.S_SUCCESSFULLY;
                response.Model = result;
            }
            else
            {
                response.code = (int)HTTPCode.Accepted;
                response.Success = false;
                response.Message = MessageConstants.S_LOGIN_ERROR;
            }

            return response;
        }

        public async Task<ResultBase> Logout(LoadUserRequest request)
        {
            var result = await _userservice.Logout(request);

            return result;
        }
    }
}
