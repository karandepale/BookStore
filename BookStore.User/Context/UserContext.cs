using BookStore.User.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.User.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<UserEntity> User { get; set; }
    }
}
