using System.ComponentModel.DataAnnotations;
namespace Rosewood.Domain.Entities;

public class Issue : BaseEntity
{
    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = default!;
    public string? Description { get; set; } = null!;
    [Required]
    public User DiscoveredBy { get; set; } = default!;
    [Required]
    public Project Project { get; set;} = default!;
    public string[] Tags { get; set; } = default!;
    [Required]
    public bool Active { get; set; } = true;
    [Required]
    public DateTime Date { get; set; } = DateTime.Now;
}
