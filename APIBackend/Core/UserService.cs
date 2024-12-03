using System.Text.RegularExpressions;
using APIBackend.DBModels;
using APIBackend.DTOModels;
using APIBackend.Interface;

namespace APIBackend.Core
{
    public class UserService : IUserService
    {
        private readonly IDomainService _domainService;
        private readonly Regex rgx = new Regex("[^a-zA-Z0-9 -]");
        private readonly GeneralService _generalservice;

        public UserService(IDomainService domainService, GeneralService generalService)
        {
            _domainService = domainService;
            _generalservice = generalService;
        }

        public async Task<LoadUserResponse> Login(LoadLoginRequest request)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = new LoadUserResponse();

                    string tmpUser = rgx.Replace(request.username, "");
                    string tmpPass = rgx.Replace(request.password, "");

                    if(!string.IsNullOrEmpty(tmpUser) && !string.IsNullOrEmpty(tmpPass))
                    {
                        var queryChk = _domainService.GetAllUsers().Where(x => x.Username == tmpUser && x.Password == tmpPass).FirstOrDefault();

                        if (queryChk != null)
                        {
                            var transaction = _domainService.BeginTransaction();
                            var sessChk = _domainService.GetAllSessions().OrderByDescending(x => x.Id).FirstOrDefault();
                            DateTime now = DateTime.Now;
                            string token = _generalservice.SHA256Generator(tmpUser + now.ToString());

                            var newSession = new TbSession
                            {
                                Id = _generalservice.IDGenerator(sessChk != null ? sessChk.Id : string.Empty),
                                DateAdd = now,
                                UserId = queryChk.Id,
                                DateExpired = now.AddHours(AppConstant.extSessionHours),
                                Token = token
                            };

                            _domainService.InsertSession(newSession);

                            result.username = tmpUser;
                            result.token = token;
                            result.name = queryChk.Name;

                            _domainService.SaveChanges();
                            transaction.Commit();
                        }
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Method: Login(), Message: {ex.Message}");
                }
            }).ConfigureAwait(false);
        }

        public async Task<ResultBase> Logout(LoadUserRequest request)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = new ResultBase()
                    {
                        Success = false
                    };

                    string tmpUser = rgx.Replace(request.username, "");
                    string tmpToken = rgx.Replace(request.token, "");

                    if (!string.IsNullOrEmpty(tmpUser) && !string.IsNullOrEmpty(tmpToken))
                    {
                        var queryChk = _domainService.GetAllUsers().Where(x => x.Username == tmpUser).FirstOrDefault();

                        if (queryChk != null)
                        {
                            var sessChk = _domainService.GetAllSessions().Where(x => x.UserId == queryChk.Id && x.Token == tmpToken).FirstOrDefault();

                            if(sessChk != null)
                            {
                                var transaction = _domainService.BeginTransaction();

                                _domainService.DeleteSession(sessChk);
                                result.code = (int)HTTPCode.OK;
                                result.Success = true;

                                _domainService.SaveChanges();
                                transaction.Commit();
                            }
                            else
                            {
                                result.code = (int)HTTPCode.Unauthorized;
                                result.Message = MessageConstants.S_LOGOUT_ERROR;
                            }
                        }
                        else
                        {
                            result.code = (int)HTTPCode.Not_Found;
                            result.Message = MessageConstants.S_LOGOUT_ERROR;
                        }
                    }
                    else
                    {
                        result.code = (int)HTTPCode.Bad_Request;
                        result.Message = MessageConstants.S_REQUEST_INVALID;
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Method: Logout(), Message: {ex.Message}");
                }
            }).ConfigureAwait(false);
        }

        public async Task<LoadUserResponse> GetUserData(LoadUserRequest request)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = new LoadUserResponse();

                    string tmpUser = rgx.Replace(request.username, "");
                    string tmpToken = rgx.Replace(request.token, "");

                    if (!string.IsNullOrEmpty(tmpUser) && !string.IsNullOrEmpty(tmpToken))
                    {
                        var queryChk = _domainService.GetAllUsers().Where(x => x.Username == tmpUser).FirstOrDefault();

                        if (queryChk != null)
                        {
                            var sessChk = _domainService.GetAllSessions().Where(x => x.UserId == queryChk.Id && x.Token == tmpToken).FirstOrDefault();

                            if(sessChk != null)
                            {
                                result.username = tmpUser;
                                result.token = tmpToken;
                                result.name = queryChk.Name;
                            }
                        }
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Method: Login(), Message: {ex.Message}");
                }
            }).ConfigureAwait(false);
        }
    }
}
