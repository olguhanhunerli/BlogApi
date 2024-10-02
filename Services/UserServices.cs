using Entities.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Repositories.Contract;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHasher<Users> _passwordHasher;  // Generic olarak güncelledik

        public UserServices(IUserRepository repository, IPasswordHasher<Users> passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var user = await _repository.GetUserByEmail(email);
            if (user == null || _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed)  // Doğru kullanımı
            {
                throw new Exception("Kullanıcı adı veya şifreniz yanlış.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("YourVerySecretKeyThatIsLongerThanUsual");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task RegisterAsync(string userName, string email, string password)
        {
            var userExisting = await _repository.GetUserByEmail(email);
            if (userExisting != null)
            {
                throw new Exception("Kullanıcı zaten mevcut");
            }

           

            var user = new Users
            {
                Username = userName,
                Email = email,
               
                CreatedAt = DateTime.UtcNow
            };
            
            user.PasswordHash = _passwordHasher.HashPassword(user,password);
            await _repository.AddUser(user);
        }
    }
}
