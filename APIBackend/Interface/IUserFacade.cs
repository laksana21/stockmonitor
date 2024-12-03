using APIBackend.DTOModels;

namespace APIBackend.Interface
{
    public interface IUserFacade
    {
        Task<ResultBase<LoadUserResponse>> Login(LoadLoginRequest request);
        Task<ResultBase> Logout(LoadUserRequest request);
        Task<ResultBase<LoadUserResponse>> GetUserData(LoadUserRequest request);
    }
}
