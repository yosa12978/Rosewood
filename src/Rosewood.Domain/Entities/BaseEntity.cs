using System.ComponentModel.DataAnnotations;

namespace Rosewood.Domain.Entities;

public class BaseEntity
{
    [Required]
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
}
