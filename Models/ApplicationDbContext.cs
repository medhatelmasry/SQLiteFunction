using Microsoft.EntityFrameworkCore;
using System;

namespace SQLiteFunction.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
             optionsBuilder.UseSqlite(Utils.GetSQLiteConnectionString());
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Student>().HasData(
          new
          {
              StudentId = 1,
              FirstName = "Jane",
              LastName = "Smith",
              School = "Medicine"
          }, new
          {
              StudentId = 2,
              FirstName = "John",
              LastName = "Fisher",
              School = "Engineering"
          }, new
          {
              StudentId = 3,
              FirstName = "Pamela",
              LastName = "Baker",
              School = "Food Science"
          }, new
          {
              StudentId = 4,
              FirstName = "Peter",
              LastName = "Taylor",
              School = "Mining"
          }
        );
    }
}
