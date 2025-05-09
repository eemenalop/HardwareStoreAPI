using billingSystem.Data;
using billingSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace billingSystem.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public UserService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
        public async Task<List<Users>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<Users?> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<Users> CreateUser(Users newUser)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == newUser.Username);
            if (existingUser != null)
                throw new Exception("Username already exists");
            newUser.PasswordHash = HashPassword(newUser.PasswordHash);
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }
        public async Task<Users?> UpdateUser(int id, Users updatedUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u=> u.Id == id);
            if (user == null) return null;

            user.Username = updatedUser.Username;
            user.PasswordHash = HashPassword(updatedUser.PasswordHash);
            user.Role = updatedUser.Role;

            await _context.SaveChangesAsync();
            return user;
        }
        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<(Users user, string token)> Register(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null || !VerifyPassword(password, user.PasswordHash) )
                throw new Exception("Incorrect credentials");

            var token = GenerateJwtToken(user);
            return (user, token);
        }
        public async Task<string?> Authenticate(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null || !VerifyPassword(password, user.PasswordHash))
                return null;

            return GenerateJwtToken(user);

        }
        private static bool VerifyPassword(string password, string hashedPassword)
        {
            return HashPassword(password) == hashedPassword;
        }

        private string GenerateJwtToken(Users user)
        {
            var key = Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _config["JwtSettings:Issuer"],
                _config["JwtSettings:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
