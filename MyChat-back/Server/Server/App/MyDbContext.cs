using Microsoft.EntityFrameworkCore;
using Server.Entities;

namespace Server.App;

public class MyDbContext:DbContext
{
    public virtual DbSet<User>Users { get; set; }
    public virtual DbSet<LoginPassword>LoginPasswords { get; set; }
    public MyDbContext(){}

    public MyDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}