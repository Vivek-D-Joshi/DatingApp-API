using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbEntities.DTOs
{
    public class UserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class UserResponseDTO
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public string Token { get; set; }
    }
}
