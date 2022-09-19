using Microsoft.EntityFrameworkCore;
using ModelsLayer;

namespace APILayer
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        public DbSet<Product>Products { get; set; }
    }
}
