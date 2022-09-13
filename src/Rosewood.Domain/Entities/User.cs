using System.ComponentModel.DataAnnotations;
namespace Rosewood.Domain.Entities;

public class User : BaseEntity
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;
    [Required]
    public string Password { get; set; } = default!;
    [Required]
    [MaxLength(255)]
    public string FirstName { get; set; } = default!;
    [Required]
    [MaxLength(255)]
    public string LastName { get; set; } = default!;
    [Required]
    public string Role { get; set; } = "USER";
    public Project[] Projects { get; set; } = default!;
    public Issue[] Issues { get; set; } = default!;
    [Required]
    public DateTime RegDate { get; set; } = DateTime.Now;
    public List<Comment> Comments { get; set; } = default!;
}
