using MyApp.CrudApi.Domain.Models;
using MyApp.CrudApi.Services.DTOs;

namespace MyApp.CrudApi.Services.IServices
{
    public interface IAuthenticationServices
    {
        UserDto Login(LoginUserDto user);
        void RegisterNewUser(RegisterUserDto user);
    }
}
