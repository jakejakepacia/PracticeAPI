using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PracticeAPI.Data;
using PracticeAPI.Models.Api;
using PracticeAPI.Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PracticeAPI.Services
{
    public class JwtService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly PasswordHasher<User> _hasher;

        public JwtService(ApplicationDBContext dBContext, IConfiguration configuration)
        {
            _dbContext = dBContext;
            _configuration = configuration;
            _hasher = new PasswordHasher<User>();
        }

        public async Task<LoginResponseModel?> Authenticate(LoginRequestModel loginRequest)
        {
            if (string.IsNullOrWhiteSpace(loginRequest.UserName) || string.IsNullOrWhiteSpace(loginRequest.Password))
                return null;

            var userAccount = _dbContext.userAccount.FirstOrDefault(x => x.username == loginRequest.UserName);

            if (userAccount is null)
                return null;

            var result = _hasher.VerifyHashedPassword(userAccount, userAccount.hashedPassword, loginRequest.Password);

            if (result == PasswordVerificationResult.Failed)
                return null;

            var issuer = _configuration["JwtSettings:Issuer"];
            var audience = _configuration["JwtSettings:Audience"];
            var key = _configuration["JwtSettings:SecretKey"];
            var tokenValidityMins = _configuration.GetValue<int>("JwtSettings:ExpiresInMinutes");
            var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(tokenValidityMins);
          
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                  new Claim(ClaimTypes.NameIdentifier, userAccount.userId.ToString()),
                  new Claim(ClaimTypes.Name, userAccount.username),
                }),

                Expires = tokenExpiryTimeStamp,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    SecurityAlgorithms.HmacSha256
                )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);

            return new LoginResponseModel
            {
                Id = userAccount.userId,
                AccessToken = accessToken,
                Username = loginRequest.UserName,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.UtcNow).TotalSeconds
            };

        }
    }
}
