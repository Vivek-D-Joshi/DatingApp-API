using API.DbEntities;
using API.Repository.Definition;
using API.Services.Definition;
using Newtonsoft.Json.Linq;

namespace API.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<AppUser>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return users;      
        }
    }
}
