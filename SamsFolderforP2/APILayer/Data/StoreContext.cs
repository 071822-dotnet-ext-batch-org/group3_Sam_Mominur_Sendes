using Microsoft.EntityFrameworkCore;
using ModelsLayer;

namespace APILayer.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } //Products - name for the table
    }
}
