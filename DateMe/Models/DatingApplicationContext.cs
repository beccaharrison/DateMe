using Microsoft.EntityFrameworkCore;

namespace DateMe.Models;

public class DatingApplicationContext : DbContext
{
    public DatingApplicationContext(DbContextOptions<DatingApplicationContext> options) : base(options)
    {
        
    }
    
    public DbSet<Application> Applications { get; set; }
    public DbSet<Major> Majors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) //seed Data
    {
        modelBuilder.Entity<Major>().HasData(
            new Major { MajorId=1, MajorName="InformationSystems"},
            new Major { MajorId=2, MajorName = "Computer Science"},
            new Major { MajorId=3, MajorName = "Magic"},
            new Major { MajorId=4, MajorName = "Banana Stand"},
            new Major { MajorId=5, MajorName = "Business Administration"}
        );
    }
}