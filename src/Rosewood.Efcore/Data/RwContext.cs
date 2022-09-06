namespace Rosewood.Efcore.Data;

public class RwContext : DbContext
{
    public RwContext(DbContextOptions<RwContext> options) : base(options) 
    {

    }

    protected override void OnModelCreating(ModelBuilder builder) 
    {
        builder.Entity<User>().HasKey(x => x.Id);
        builder.Entity<Issue>().HasKey(x => x.Id);
        builder.Entity<Project>().HasKey(x => x.Id);

        builder.Entity<User>().HasMany(x => x.Projects).WithOne(x => x.CreatedBy);
        builder.Entity<User>().HasMany(x => x.Issues).WithOne(x => x.DiscoveredBy);
        builder.Entity<Issue>().HasOne(x => x.Project).WithMany(x => x.Issues);
        builder.Entity<Issue>().HasOne(x => x.DiscoveredBy).WithMany(x => x.Issues);
        builder.Entity<Project>().HasOne(x => x.CreatedBy).WithMany(x => x.Projects);
        builder.Entity<Project>().HasMany(x => x.Issues).WithOne(x => x.Project);
    }

    public DbSet<User> users { get; set; } = default!;
    public DbSet<Issue> issues { get; set; } = default!;
    public DbSet<Project> projects { get; set; } = default!;
}
