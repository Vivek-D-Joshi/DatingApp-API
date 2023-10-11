using API.DbEntities;

namespace API.Services.Definition
{
    public interface ITokenService
    {
        public string CreateToken(AppUser user);
    }
}
