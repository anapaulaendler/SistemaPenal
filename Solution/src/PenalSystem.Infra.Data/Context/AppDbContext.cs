using Microsoft.EntityFrameworkCore;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Infra.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public required DbSet<Book> Books { get; set; }
    public required DbSet<DayOfWork> DaysOfWork { get; set; }
    public required DbSet<Employee> Employees { get; set; }
    public required DbSet<Prisoner> Prisoners { get; set; }
    public required DbSet<Study> Studies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}