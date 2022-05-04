using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public abstract class CoreDb : DbContext
{
    protected CoreDb(DbContextOptions options) : base(options) { }

    public DbSet<Role> Roles => Set<Role>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>()
            .HasData(
                new Role
                {
                    Name = "root",
                    Permissions = Enum.GetValues<Permission>(),
                },
                new Role
                {
                    Name = "guest",
                    Permissions = new Permission[]
                    {
                        Permission.ReadMyProfile,
                        Permission.WriteMyProfile,
                    },
                });
    }
}
