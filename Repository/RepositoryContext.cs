using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {

    }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);

    //    modelBuilder.ApplyConfiguration(new RoleConfiguration());

    //}
    public DbSet<User> Users { get; set; }
    public DbSet<Skills> Skills { get; set; }
    public DbSet<Characters> Characters { get; set; }
    public DbSet<Mission> Missions { get; set; }
    public DbSet<Weapon> Weapons { get; set; }


}