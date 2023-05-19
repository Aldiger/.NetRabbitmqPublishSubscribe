namespace Producer
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRabbitMqService _rabbitMqService;
        public OrderService(
            IUnitOfWork unitOfWork,
            IRabbitMqService rabbitMqService
            )
        {
            _unitOfWork = unitOfWork;
            _rabbitMqService = rabbitMqService;
        }
        public async Task<Guid> ProcessOrder(OrderDto order)
        {
            var entity = new Order
            {
                Price = order.Price,
                ProductName = order.ProductName,
                Quantity = order.Quantity
            };

            await _unitOfWork.Order.Add(entity);

            if (await _unitOfWork.SaveAsync()>0)
            {
                _rabbitMqService.SendMessage(entity);
            }
            return entity.Id;
        }
    }

}
