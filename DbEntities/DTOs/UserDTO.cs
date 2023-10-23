using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace API.DbEntities.DTOs
{
    public class UserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 4)]
        public string Password { get; set; }
    }

    public class UserResponseDTO
    {
        public HttpStatusCode Status { get; set; }
        public string Description { get; set; }
        public string Token { get; set; }
    }
}
