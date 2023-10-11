using API.DbEntities;
using API.DbEntities.DTOs;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;

namespace API.Services.Definition
{
    public interface IUserService
    {
        public Task<List<AppUser>> GetUsers();
        public Task<UserResponseDTO> Register(UserDTO request);
        public Task<UserResponseDTO> Login(LoginDTO request);
    }
}
