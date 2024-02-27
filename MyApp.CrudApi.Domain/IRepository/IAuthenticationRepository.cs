using MyApp.CrudApi.Domain.Models;

namespace MyApp.CrudApi.Domain.IRepository
{
    public interface IAuthenticationRepository
    {
        UserModel Login(UserModel user);
        void RegisterNewUser(UserModel user);
    }
}
