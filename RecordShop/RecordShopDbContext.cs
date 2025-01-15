using Microsoft.EntityFrameworkCore;
using RecordShop.Data;

namespace RecordShop
{
    public class RecordShopDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public RecordShopDbContext(DbContextOptions<RecordShopDbContext> options)
     : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artist>().HasData(
                new Artist { Id = 1, Name = "MF DOOM" },
                new Artist { Id = 2, Name = "The Beatles" }
            );

            modelBuilder.Entity<Album>().HasData(
                new Album
                {
                    Id = 1,
                    Title = "Madvillainy",
                    ArtistId = 1,
                    ReleaseDate = new DateTime(2004, 3, 23),
                },

                new Album
                {
                    Id = 2,
                    Title = "Abbey Road",
                    ArtistId = 2,
                    ReleaseDate = new DateTime(1969, 9, 26),
                }
            );


        }
    }
}
