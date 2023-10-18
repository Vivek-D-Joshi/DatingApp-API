using API.DbEntities;
using API.DbEntities.DTOs;
using API.Services.Definition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetUsers")]
        [AllowAnonymous]
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

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<UserResponseDTO> Register([FromBody] UserDTO user)
        {
            var taskResult = await _userService.Register(user);
            return taskResult;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<UserResponseDTO> Login([FromBody] LoginDTO login)
        {
            var taskResult = await _userService.Login(login);
            return taskResult;
        }
    }
}
 