using Logbook.Models;
using Logbook.ServiceLayer.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Logbook.ServiceLayer.Services
{
    public class RabbitMQPublisher : IRabbitMQPublisher
    {
        public void PublishEventMessage(Jumper createdUser)
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
                channel.ExchangeDeclare(exchange: "user_events", type: "fanout");

                var user = new { UserId = createdUser.UserId, Username = createdUser.Username, FirstName = createdUser.FirstName, LastName = createdUser.LastName, EmailAddress = createdUser.EmailAddress };
                var message = JsonConvert.SerializeObject(user);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "user_events", routingKey: "", basicProperties: null, body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

        }
    }
}
