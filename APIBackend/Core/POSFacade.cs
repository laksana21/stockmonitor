using APIBackend.DTOModels;
using APIBackend.Interface;

namespace APIBackend.Core
{
    public class POSFacade : IPOSFacade
    {
        private readonly IPOSService _posService;
        private readonly GeneralService _generalservice;

        public POSFacade(IPOSService posService, GeneralService generalservice)
        {
            _posService = posService;
            _generalservice = generalservice;
        }

        public async Task<ResultBase> SaveTransaction(LoadUserRequest auth, SaveTransactionRequest request)
        {
            bool checkLogin = _generalservice.LoginCheck(auth.username, auth.token);
            var response = new ResultBase();

            if (checkLogin)
            {
                var saveParam = new SaveTransactionParam
                {
                    Id = string.Empty,
                    Item_id = request.Item_id,
                    Pcs = request.Pcs,
                    User_id = auth.username
                };

                var result = await _posService.SaveTransaction(saveParam);

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

        public async Task<ResultBase<LoadTransactionResponse>> LoadTransaction(LoadUserRequest auth)
        {
            bool checkLogin = _generalservice.LoginCheck(auth.username, auth.token);
            var response = new ResultBase<LoadTransactionResponse>();

            if (checkLogin)
            {
                var result = await _posService.LoadTransaction();

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

        public async Task<ResultBase<LoadTransactionReportResponse>> LoadReportTransaction(LoadUserRequest auth)
        {
            bool checkLogin = _generalservice.LoginCheck(auth.username, auth.token);
            var response = new ResultBase<LoadTransactionReportResponse>();

            if (checkLogin)
            {
                var result = await _posService.LoadReportTransaction();

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
