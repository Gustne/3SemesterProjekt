using System.Text.RegularExpressions;
using Login.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Login.Infrastructure;

public class LoginContext : DbContext
{
    public LoginContext(DbContextOptions<LoginContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .Property(p => p.Id)
            .HasDefaultValueSql("NEWID()");

    }

    public DbSet<Activity> Activities { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Person> People { get; set; }


}
