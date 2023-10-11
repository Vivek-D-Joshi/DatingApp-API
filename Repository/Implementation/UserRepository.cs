using API.DatabaseContext;
using API.DbEntities;
using API.DbEntities.DTOs;
using API.Repository.Definition;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dbContext;
        public UserRepository(DataContext DbContext)
        {
            _dbContext = DbContext;
        }
        public async Task<List<AppUser>> GetUsers()
        {
            var users = await _dbContext.AppUsers.ToListAsync();
            return users;
        }

        public async Task<int> AddUser(AppUser user)
        {
            var users = await _dbContext.AppUsers.AddAsync(user);
            var i = await this._dbContext.SaveChangesAsync();
            return i >= 1 ? 1 : 0;
        }

        public async Task<bool> IsUserExist(UserDTO user)
        {
            return await _dbContext.AppUsers.AnyAsync(x => x.Name.ToLower() == user.Username.ToLower());
        }

        public async Task<AppUser> GetUser(LoginDTO login)
        {
            return await _dbContext.AppUsers.SingleOrDefaultAsync(x => x.Name.ToLower() == login.Username.ToLower());
        }
    }
}
