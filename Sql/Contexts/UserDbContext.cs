using Microsoft.EntityFrameworkCore;
using Sql.Entities;

namespace Sql.Contexts
{
    internal class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> UserEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("Users");

            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }
    }
}
