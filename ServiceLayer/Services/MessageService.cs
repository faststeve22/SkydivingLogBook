using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.ServiceLayer.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Logbook.ServiceLayer.Services
{
    public class MessageService : IMessageService
    {
        private readonly IDbUserDAO _userDAO;

        public MessageService(IDbUserDAO userDAO)
        {
            _userDAO = userDAO;
        }
        public void ConsumeMessage()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "user_events", type: "fanout");
                var queueName = channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: queueName, exchange: "user_events", routingKey: "");
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var userInfo = JsonConvert.DeserializeObject<User>(message);
                    User user = new User();
                    user.UserId = userInfo.UserId;
                    user.Username = userInfo.Username;
                    user.EmailAddress = userInfo.EmailAddress;
                    _userDAO.AddUser(user);

                    // Create user in this service's database
                };
                channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
