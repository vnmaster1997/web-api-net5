using Microsoft.EntityFrameworkCore;
using RestfulAPI.Data;

namespace RestfulAPI.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions options): base(options)
        {

        }

        #region DbSet
        public DbSet<RefreshToken> RefreshTokens { get; set; } 
        public DbSet<User> Users {  get; set; }
        public DbSet<Merchandise> Merchandises { get; set; }
        public DbSet<Category> Categories { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName).IsUnique();
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
            });
        }

    }
}
