using System.ComponentModel.DataAnnotations;
using System.Xml.Schema;

namespace PublicApi.DTO.v2.Identity
{
    public class LoginDTO
    {
        [MaxLength(256)]
        [EmailAddress]
        public string Email { get; set; } = default!;
        [MinLength(6)]
        [MaxLength(100)]
        public string Password { get; set; } = default!;
    }
}