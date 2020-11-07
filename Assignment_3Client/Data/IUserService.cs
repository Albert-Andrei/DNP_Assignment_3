using System.Threading.Tasks;
using Assignment_3Client.Model;

namespace Assignment_3Client.Data
{
    public interface IUserService
    {
        Task<User> GetUserAsync(string? username, string? password);
    }
}