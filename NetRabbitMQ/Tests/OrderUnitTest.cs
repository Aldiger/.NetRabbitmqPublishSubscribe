using Moq;
using Producer;

namespace Tests;

public class OrderUnitTest
{
    private readonly IOrderService _orderService;
    public OrderUnitTest()
    {   
        var orderRepository = new Mock<IOrderRespository>();
        var unitOfWork = new Mock<IUnitOfWork>();
        var rabbitMqService = new Mock<IRabbitMqService>();

        unitOfWork.Setup(uow => uow.Order).Returns(orderRepository.Object);

        _orderService = new OrderService(unitOfWork.Object, rabbitMqService.Object);
        
    }
    [Fact]
    public async void CreateOrder_SendMessageToRabbitMQ()
    {

        //Arrange
        var orderDto = new OrderDto
        {
            ProductName = "Test",
            Price = 10,
            Quantity = 1,
        };

        //Act
        var id = await _orderService.ProcessOrder(orderDto);

        //Assert

        Assert.True(id == Guid.Empty);
    }
 }