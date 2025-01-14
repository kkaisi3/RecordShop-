using Microsoft.EntityFrameworkCore;
using RecordShop.Data;

namespace RecordShop
{
    public class RecordShopDbContext : DbContext
    {
        public RecordShopDbContext(DbContextOptions<RecordShopDbContext> options)
     : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
    }
}
