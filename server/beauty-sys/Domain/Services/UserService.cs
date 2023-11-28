using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Objects.Reponses;
using Domain.Objects.Requests;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public string LogIn(LogInRequest logInRequest)
        {
            var userId = _userRepository.GetUserIdByNameAndPass(logInRequest.UserName, DecryptString(logInRequest.Password, "beauty-key"));

            if (!userId.HasValue)
                throw new InvalidCredentialException("Usuário ou senha inválidos");

            return GenerateAuthToken(userId.Value.ToString());
        }

        public async Task SaveUser(CreateUserRequest createUserRequest)
        {
            createUserRequest.Password = EncryptString(createUserRequest.Password, "beauty-key");

            await _userRepository.SaveAsync(_mapper.Map<User>(createUserRequest));
        }

        public async Task UpdateUser(UpdateUserRequest updateUserRequest)
        {
            if (updateUserRequest.Name == null && updateUserRequest.Password == null)
                throw new InvalidOperationException("Nenhuma modificação foi realizada!");

            var user = await _userRepository.GetById(updateUserRequest.UserId) ?? throw new InvalidOperationException("Nenhum usuário encontrado");

            if (updateUserRequest.Name != null)
                user.Name = updateUserRequest.Name;

            if (updateUserRequest.Password != null)
                user.Password = updateUserRequest.Password;

            user.UpdatedAt = DateTime.Now;

            await _userRepository.UpdateAsync(user);
        }

        public ICollection<UserResponse> GetUsers(int? id, string? name, int currentPage, int takeQuantity)
        {
            var users = _userRepository.GetUsers(id, name, currentPage, takeQuantity);

            if (!users.Any())
                throw new InvalidOperationException("Nenhum usuário encontrado");

            return users;
        }

        public async Task DeleteUser(int id) => await _userRepository.Delete(id);

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

        public static string EncryptString(string text, string keyString)
        {
            var key = Encoding.UTF8.GetBytes(keyString);

            using var aesAlg = Aes.Create();
            using var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV);
            using var msEncrypt = new MemoryStream();

            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            using (var swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(text);
            }

            var iv = aesAlg.IV;
            var decryptedContent = msEncrypt.ToArray();
            var result = new byte[iv.Length + decryptedContent.Length];

            Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
            Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

            return Convert.ToBase64String(result);
        }

        public static string DecryptString(string cipherText, string keyString)
        {
            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Encoding.UTF8.GetBytes(keyString);

            using var aesAlg = Aes.Create();
            using var decryptor = aesAlg.CreateDecryptor(key, iv);
            string result;

            using (var msDecrypt = new MemoryStream(cipher))
            {
                using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using var srDecrypt = new StreamReader(csDecrypt);

                result = srDecrypt.ReadToEnd();
            }

            return result;
        }
    }
}
