using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StoreManager.Facade.Interfaces.Services;
using StoreManager.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StoreManager.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class AuthorizationController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IConfiguration _configuration;

    public AuthorizationController(IAccountService accountService, IConfiguration configuration)
    {
        _accountService = accountService;
        _configuration = configuration;
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login(LoginModel model)
    {
        if (model.Username == "Admin" && model.Password == "admin")
        {
            var stringToken = GetToken(model.Username);

            return Ok(stringToken);
        }
        return Unauthorized();
    }

    [HttpPost]
    [Route("register")]
    public IActionResult Register(RegisterModel model) // In progress.
    {
        var serviceProvider = HttpContext.RequestServices;
        var customerController = serviceProvider.GetService<CustomerController>();

        int customerId = customerController!.Insert(new CustomerModel(0, model.FirstName, model.LastName));
        _accountService.Register(customerId, model.FirstName, model.LastName);

        return Ok();
    }

    private string GetToken(string username)
    {
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Email, username),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
            Expires = DateTime.UtcNow.AddMinutes(30),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);

        return tokenHandler.WriteToken(token);
    }
}
