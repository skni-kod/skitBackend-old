using Data.Models;
using Microsoft.EntityFrameworkCore;
using skitBackend.Data.Models;

namespace Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();

            #region UserEntityBuilder
            modelBuilder.Entity<User>()
                .Property(u => u.Login)
                .IsRequired();
            
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Nickname)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();
            #endregion

            #region RoleEntityBuilder
            modelBuilder.Entity<Role>()
            .Property(u => u.Name)
            .IsRequired();
            #endregion
        }
    }

}
