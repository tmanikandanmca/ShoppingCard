using AuthServices.Models;
using AuthServices.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthServices.Services.Implementations;

public class AuthServiceRepository(AccountContext db, IConfiguration config) : IAuthServiceRepository
{
    public bool CreateUser(SignUpModel signUp)
    {
        try
        {
            string HashPassword = BCrypt.Net.BCrypt.HashPassword(signUp.Password);
            User user = new User
            {
                Name = signUp.Name,
                Email = signUp.Email,
                Password = HashPassword,
                PhoneNumber = signUp.PhoneNumber
            };
            db.Users.Add(user);
            db.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public UserModel login(LoginModel login)
    {

        var data = db.Users.Where(e => e.Email == login.email).FirstOrDefault();
        if (data is null) return null;
        var res = BCrypt.Net.BCrypt.Verify(login.password, data.Password);
        if (!res) return null;
        var user= new UserModel
        {
            Id = data.Id,
            Name = data.Name,
            Email = data.Email,
            PhoneNumber = data.PhoneNumber,
         
            Roles = ["Test", "Test1"]
        };

        user.Token = GenerateJsonToken(user);

        return user;
    }


    private string GenerateJsonToken(UserModel user)
    {

        var _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        var credentials = new SigningCredentials(key: _securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
             new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                             new Claim(JwtRegisteredClaimNames.Email, user.Email),
                             new Claim("Roles", string.Join(",",user.Roles)),
                             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(config["Jwt:Issuer"],
                                                   config["Jwt:Audience"],
                                                   claims,
                                                   expires: DateTime.UtcNow.AddMinutes(60), //token expiry minutes
                                                   signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
