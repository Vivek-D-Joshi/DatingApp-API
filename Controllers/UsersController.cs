using API.DbEntities;
using API.Services.Definition;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<AppUser>>> GetUsers()
        {
            var taskResult = await _userService.GetUsers();
            return taskResult;
        }

        [HttpGet("GetUsers/{id}")]
        public async Task<ActionResult<AppUser>> GetUsers(int id)
        {
            var taskResult = _userService.GetUsers().Result.Where(user => user.Id == id).FirstOrDefault();
            if(taskResult == null)
            {
                var emptyResult = new EmptyResult();
                return emptyResult;
            }
            else
            {
                return taskResult;
            }
        }
    }
}
