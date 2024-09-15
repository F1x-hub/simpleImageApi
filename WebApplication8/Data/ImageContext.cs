using Microsoft.EntityFrameworkCore;
using WebApplication8.Model;

namespace WebApplication8.Data
{
    public class ImageContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserImage> UserImages { get; set; }

        public ImageContext(DbContextOptions options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserImages)
                .WithOne(ui => ui.User)
                .HasForeignKey(ui => ui.UserId);
        }
    }
}
