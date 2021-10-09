using System.ComponentModel.DataAnnotations;

namespace Models
{
    public record InputLoginInfo
    {
        [EmailAddress]
        [Required]
        public string Email { get; init; }

        [MaxLength(50)]
        [Required]
        public string Password { get; set; }
    }
}
