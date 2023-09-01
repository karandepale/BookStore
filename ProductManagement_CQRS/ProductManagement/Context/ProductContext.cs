using Microsoft.EntityFrameworkCore;
using ProductManagement.Entity;

namespace ProductManagement.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
