using API.DatabaseContext;
using API.DbEntities;
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
    }
}
