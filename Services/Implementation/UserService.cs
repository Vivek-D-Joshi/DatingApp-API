using API.DbEntities;
using API.DbEntities.DTOs;
using API.Repository.Definition;
using API.Services.Definition;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;

namespace API.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }
        public async Task<List<AppUser>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return users;      
        }

        public async Task<UserResponseDTO> Register(UserDTO request)
        {
            var response = new UserResponseDTO();
            if (await _userRepository.IsUserExist(request))
            {
                response.Status = "400";
                response.Description = "Record already exist";
            }
            else
            {
                //Summary:
                //   HMACSHA512 generates a random key for salt
                //   using keyword is used when we have to dispose an object from a memory
                using var hmac = new HMACSHA512();

                var user = new AppUser
                {
                    Name = request.Username,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
                    PasswordSalt = hmac.Key
                };
                var result = await _userRepository.AddUser(user);
                if (result > 0)
                {
                    response.Status = "200";
                    response.Description = "Record added successfully";
                    response.Token = _tokenService.CreateToken(user);
                }
                else
                {
                    response.Status = "400";
                    response.Description = "Failed to add record";
                }
            }
            return response;
        }

        public async Task<UserResponseDTO> Login(LoginDTO request)
        {
            var response = new UserResponseDTO();
            var user = await this._userRepository.GetUser(request);
            if(user == null)
            {
                response.Status = "400";
                response.Description = "Invalid Username";
            }
            else
            {
                //Password Salt is pass as a key to generate same password
                var hmac = new HMACSHA512(user.PasswordSalt);
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
                for(int i = 0; i < computedHash.Length; i++)
                {
                    if (user.PasswordHash[i] != computedHash[i])
                    {
                        response.Status = "400";
                        response.Description = "Invalid Password";
                        return response;
                    }
                }
                response.Status = "200";
                response.Description = "Login successful";
                response.Token = _tokenService.CreateToken(user);
            }
            return response;
        }
    }
}
