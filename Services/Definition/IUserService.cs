using API.DbEntities;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;

namespace API.Services.Definition
{
    public interface IUserService
    {
        public Task<List<AppUser>> GetUsers();
    }
}
