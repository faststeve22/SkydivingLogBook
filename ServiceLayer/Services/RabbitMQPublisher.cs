using Logbook.ServiceLayer.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Logbook.ServiceLayer.Services
{
    public class RabbitMQPublisher : IRabbitMQPublisher
    {
        public void PublishError(string errorMessage)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "Username",
                Password = "Password"
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "error_events", type: "fanout");

                var message = JsonConvert.SerializeObject(errorMessage);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "error_events", routingKey: "", basicProperties: null, body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }
    }
}
