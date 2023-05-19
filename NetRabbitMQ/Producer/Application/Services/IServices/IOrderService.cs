namespace Producer
{
    public interface IOrderService
    {
        Task<Guid> ProcessOrder(OrderDto order);
    }

}
