using Microsoft.EntityFrameworkCore;

namespace BlazorApp3
{
    public class ArtHubContext : DbContext
    {
        public ArtHubContext(DbContextOptions<ArtHubContext> options) : base(options) { }

        public DbSet<Artwork> Artworks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure default values for double properties
            modelBuilder.Entity<Artwork>().Property(a => a.Height).HasDefaultValue(0.0);
            modelBuilder.Entity<Artwork>().Property(a => a.Width).HasDefaultValue(0.0);
            modelBuilder.Entity<Artwork>().Property(a => a.Depth).HasDefaultValue(0.0);
        }
    }
}
