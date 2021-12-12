using CoreApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.Data;

public class CoreAppDbContext : DbContext
{
    public CoreAppDbContext(DbContextOptions<CoreAppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>()
            .Property(p => p.Title)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<Project>()
            .Property(p => p.SectionId)
            .IsRequired();

        modelBuilder.Entity<Section>()
            .Property(s => s.Title)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<Student>()
            .Property(s => s.Indeks)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<Student>()
            .Property(s => s.FirstName)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<Student>()
            .Property(s => s.LastName)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<Student>()
            .Property(s => s.DiscordName)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<Role>()
            .Property(r => r.Title)
            .HasMaxLength(255)
            .IsRequired();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("DefaultDatabase");
        }
    }
}