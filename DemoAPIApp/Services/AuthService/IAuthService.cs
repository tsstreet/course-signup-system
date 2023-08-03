using DemoAPIApp.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPIApp.Services.AuthService
{
    public interface IAuthService
    {
        //Task<User> Login(LoginRequest request);

        Task<string> Login(LoginRequest request);
    }
}
