using API.DbEntities;
using API.DbEntities.DTOs;

namespace API.Repository.Definition
{
    public interface IUserRepository
    {
        public Task<List<AppUser>> GetUsers();
        public Task<int> AddUser(AppUser user);
        public Task<bool> IsUserExist(UserDTO user);
        public Task<AppUser> GetUser(LoginDTO login);
    }
}
