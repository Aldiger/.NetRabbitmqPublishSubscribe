namespace Producer
{
    public class OrderRepository : GenericRepository<Order>, IOrderRespository
    {
        public OrderRepository(OrderDbContext dbContext) : base(dbContext)
        {
        }
    }

}
