using AuthServices.Models;
using AuthServices.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace AuthServices.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthServiceRepository _repo;
    public AuthController(IAuthServiceRepository repo)
    {
        _repo = repo;
    }

    [HttpPost]
    public async Task<bool> CreateUser(SignUpModel signUp)
    {
        return _repo.CreateUser(signUp);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginModel login)
    {
        return Ok(_repo.login(login));
    }
}
