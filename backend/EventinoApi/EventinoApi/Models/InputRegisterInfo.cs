using System.ComponentModel.DataAnnotations;

namespace Models
{
    public record InputRegisterInfo
    {
        [MaxLength(50)]
        [Required]
        public string UserName { get; init; }

        [EmailAddress]
        [Required]
        public string Email { get; init; }

        [MaxLength(50)]
        [Required]
        public string Password { get; init; }
    }
}
