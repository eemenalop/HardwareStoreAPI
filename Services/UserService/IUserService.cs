using billingSystem.Dtos.ItemDtos;
using billingSystem.Models;
using System.Security.Cryptography;
using System.Text;


namespace billingSystem.Services.UserService
{
    public interface IUserService
    {
        Task<List<Users>> GetAllUsers();

        Task<Users?> GetUserById(int id);

        Task<Users> CreateUser(Users newItem);

        Task<Users?> UpdateUser(int id, Users updatedItem);

        Task DeleteUser(int id);

        Task <string?> Authenticate(string username, string password);

        Task<(Users user, string token)> Register(string username, string password);
    }
}
