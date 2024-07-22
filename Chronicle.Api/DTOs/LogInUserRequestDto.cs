using System.ComponentModel.DataAnnotations;

namespace Chronicle.Api.DTOs
{
    public class LogInUserRequestDto
    {
        [EmailAddress]
        [Required]
        [StringLength(100)]
        public required string Email { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
