using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Producer
{
    public class RabbitMqService : IRabbitMqService
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare("orders", exclusive: false);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "orders", body: body);
        }
    }
}
