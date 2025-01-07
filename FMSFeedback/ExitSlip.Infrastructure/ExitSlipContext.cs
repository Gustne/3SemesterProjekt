using ExitSlip.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExitSlip.Infrastructure;

public class ExitSlipContext : DbContext
{
    public ExitSlipContext(DbContextOptions<ExitSlipContext> options) : base(options)
    {
    }
    public DbSet<Exit> Exits { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }

}

