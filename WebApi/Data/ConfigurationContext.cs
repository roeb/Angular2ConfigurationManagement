using Microsoft.EntityFrameworkCore;

public class ConfigurationContext : DbContext
{
    public ConfigurationContext(DbContextOptions<ConfigurationContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
          modelBuilder.Entity<AppSettings>(entity => {
              entity.ToTable("AppSettings");
              entity.HasKey("AppSettingsId");
          });
    }

    public DbSet<AppSettings> AppSettings { get; set; }
}