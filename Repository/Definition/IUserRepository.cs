using API.DbEntities;

namespace API.Repository.Definition
{
    public interface IUserRepository
    {
        public Task<List<AppUser>> GetUsers();
    }
}
