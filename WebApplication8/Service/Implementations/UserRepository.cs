using Microsoft.EntityFrameworkCore;
using WebApplication8.Data;
using WebApplication8.Model;
using WebApplication8.Service.Abstractions;

namespace WebApplication8.Service.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ImageContext _imageContext;

        public UserRepository(ImageContext imageContext) 
        {
            _imageContext = imageContext;
        }
        public async Task<User> AddUser(User user)
        {
            await _imageContext.Users.AddAsync(user);
            await _imageContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var user = await _imageContext.Users.Include(p => p.UserImages).ToListAsync();
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _imageContext.Users.Include(p => p.UserImages).FirstOrDefaultAsync(p=> p.Id == id);
            return user;
        }
    }
}
