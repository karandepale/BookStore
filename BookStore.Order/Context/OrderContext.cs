using BookStore.Order.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Order.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<OrderEntity> Order { get; set; }
    }
}
