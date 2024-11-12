using JustInTime.Auth.JustInTime.Application.Services.Cryptography;
using JustInTime.Auth.JustInTime.Domain.Repositories.User;
using JustInTime.Auth.Shared.Communication.Requests;
using JustInTime.Auth.Shared.Communication.Responses;
using JustInTime.Auth.Shared.Exceptions;
using JustInTime.Auth.Shared.Exceptions.ExceptionsBase;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JustInTime.Auth.JustInTime.Application.Services.Auth;

public class AuthService
{
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly PasswordEncripter _passwordEncripter;
    private readonly string _jwtSecretKey;

    public AuthService(IUserReadOnlyRepository userReadOnlyRepository, PasswordEncripter passwordEncripter, IConfiguration configuration)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _passwordEncripter = passwordEncripter;
        _jwtSecretKey = configuration["JwtSettings:SecretKey"];
    }

    public async Task<ResponseTokenJson> Authenticate(RequestLoginJson request)
    {
        var user = await _userReadOnlyRepository.GetUserByEmailAsync(request.Email);

        var encriptedPassword = _passwordEncripter.Encrypt(request.Password);

        if (user == null || user.Password != encriptedPassword)
        {
            throw new ErrorOnLoginException();
        }

        var token = GenerateJwtToken(user);

        var sender = new RabbitMqSender();
        sender.SendMessage($"User authenticate: {user.Name}");
        sender.Close();

        return new ResponseTokenJson { Token = token };
    }

    private string GenerateJwtToken(Domain.Entities.User user)
    {
        var claims = new[]
        {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "JustInTime",
            audience: "JustInTimeUsers",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
