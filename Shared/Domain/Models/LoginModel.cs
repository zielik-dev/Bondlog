using System.ComponentModel.DataAnnotations;

namespace Bondlog.Shared.Domain.Models
{
    public class LoginModel
    {
        [EmailAddress]
        [Required]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
