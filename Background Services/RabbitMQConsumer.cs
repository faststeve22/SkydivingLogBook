using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using Logbook.Models;
using Logbook.DataAccessLayer.DAO;

namespace Logbook.Background_Services
{
    public class RabbitMQConsumer : BackgroundService
    {
        private readonly DbUserDAO _userDAO;

        public RabbitMQConsumer(DbUserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
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
                };
                channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

                return Task.CompletedTask;
            }
        }
    }
}
