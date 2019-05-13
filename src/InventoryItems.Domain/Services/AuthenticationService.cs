using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.Interfaces.Infastructure;
using InventoryItems.Domain.Interfaces.Repositories;
using InventoryItems.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventoryItems.Domain.Services {
    public class AuthenticationService : IAuthenticationService {
        public IUserRepository UserRepository { get; set; }
        public ISettings Settings { get; set; }
        public User ValidateLogin(string username, string password) {

            var user = UserRepository.GetUser(username);
            if (user == null) return null;

            string hashedInputPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.UTF8.GetBytes(user.Salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return user.Password == hashedInputPassword ? user : null;
        }

        public string GenerateToken(User user) {
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.TokenSecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: Settings.Domain,
                audience: Settings.Domain,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
