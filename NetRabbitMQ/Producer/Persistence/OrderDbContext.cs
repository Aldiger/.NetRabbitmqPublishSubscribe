using Microsoft.EntityFrameworkCore;

namespace Producer
{
    public class OrderDbContext: DbContext
    {
        public OrderDbContext( DbContextOptions<OrderDbContext> contextOptions): base(contextOptions)
        {
            
        }

        public DbSet<Order> Orders { get; set;}

    }
}
