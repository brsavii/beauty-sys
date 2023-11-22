using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Objects.Reponses;
using Domain.Objects.Requests;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public LogInResponse LogIn(LogInRequest logInRequest)
        {
            var userId = _userRepository.GetUserIdByNameAndPass(logInRequest.UserName, logInRequest.Password);

            if (!userId.HasValue)
                throw new InvalidCredentialException("Usuário ou senha inválidos");

            var authToken = GenerateAuthToken(userId.Value.ToString());

            return new LogInResponse
            {
                UserName = logInRequest.UserName,
                AuthToken = authToken,
            };
        }

        private static string GenerateAuthToken(string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("secretPass2k23Backend");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId)
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
