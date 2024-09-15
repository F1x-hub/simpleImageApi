using WebApplication8.Model;

namespace WebApplication8.Service.Abstractions
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);

        Task<User> AddUser(User user);
    }
}
