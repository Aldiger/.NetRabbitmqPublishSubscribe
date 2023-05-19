namespace Producer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderDbContext _dbContext;
        public IOrderRespository Order { get; }


        public UnitOfWork(OrderDbContext dbContext, IOrderRespository orderRespository)
        {
            _dbContext = dbContext;
            Order = orderRespository;
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
