using Microsoft.EntityFrameworkCore;
using RoomRentalBank.Models;

namespace RoomRentalBank.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet cho các thực thể
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Feature> PostFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mối quan hệ 1-n giữa User và Posts
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Mối quan hệ 1-1 giữa Post và PostFeature
            modelBuilder.Entity<Feature>()
                .HasOne(pf => pf.Post)
                .WithOne(p => p.Feature)
                .HasForeignKey<Feature>(pf => pf.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
