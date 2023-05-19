using Microsoft.EntityFrameworkCore;

namespace Producer
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly OrderDbContext _dbContext;
        public GenericRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> GetById(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public T Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return entity;
        }
    }
}
