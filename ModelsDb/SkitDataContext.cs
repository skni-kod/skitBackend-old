using Microsoft.EntityFrameworkCore;

namespace ModelsDb
{
    public class SkitDataContext : DbContext
    {
        public SkitDataContext(DbContextOptions<SkitDataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyTechnology> CompaniesTechnologies { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("SkitDb");
            }
        }
    }

}
