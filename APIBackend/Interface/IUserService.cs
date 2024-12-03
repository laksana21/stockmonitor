using APIBackend.DTOModels;
using Microsoft.AspNetCore.Identity.Data;

namespace APIBackend.Interface
{
    public interface IUserService
    {
        Task<LoadUserResponse> Login(LoadLoginRequest request);
        Task<ResultBase> Logout(LoadUserRequest request);
        Task<LoadUserResponse> GetUserData(LoadUserRequest request);
    }
}
