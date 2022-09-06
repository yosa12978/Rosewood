using System.ComponentModel.DataAnnotations;
namespace Rosewood.Domain.Entities;

public class Project : BaseEntity
{
    [Required]
    [MaxLength(255)]
    public string Title { get; set; } = default!;
    [MaxLength(255)]
    public string? Description { get; set; } = null!;
    public Issue[] Issues { get; set; } = default!;
    public User CreatedBy { get; set; } = default!;
}
