namespace Producer
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<IList<T>> GetAll();
        Task<T> Add(T entity);
        T Update(T entity);
        void Delete(T id);
    }
}
