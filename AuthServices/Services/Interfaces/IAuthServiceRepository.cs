using AuthServices.Models;

namespace AuthServices.Services.Interfaces;

public interface IAuthServiceRepository
{
    UserModel login(LoginModel login);
    bool CreateUser(SignUpModel signUp);
}
