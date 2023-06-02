using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Logbook.ServiceLayer.Services
{
    public class RabbitMQPublisher : IRabbitMQPublisher
    {
        public void PublishError(ExceptionDTO dto)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 0000,
                UserName = "Username",
                Password = "Password"
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "user_events", type: "direct");

                var message = JsonConvert.SerializeObject(dto);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "user_events", routingKey: "Error", basicProperties: null, body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }
    }
}
