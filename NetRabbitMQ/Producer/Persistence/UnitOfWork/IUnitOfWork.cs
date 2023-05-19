namespace Producer
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRespository Order { get; }

        Task<int> SaveAsync();
    }
}
