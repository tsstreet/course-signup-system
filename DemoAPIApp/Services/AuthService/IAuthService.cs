using DemoAPIApp.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPIApp.Services.AuthService
{
    public interface IAuthService
    {
        Task<UserDto> Login(LoginRequest request);
    }
}
