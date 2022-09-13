namespace Rosewood.Domain.Entities;

public class Comment : BaseEntity
{
    public string Text { get; set; } = default!;
    public User Author { get; set; } = default!;
    public Issue Issue { get; set; } = default!;
    public bool IsChanged { get; set; } = false; 
    public DateTime Date { get; set; } = default!;
}
