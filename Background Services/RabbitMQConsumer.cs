using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using Logbook.Models;
using Logbook.DataAccessLayer.Interfaces;

namespace Logbook.Background_Services
{
    public class RabbitMQConsumer : BackgroundService
    {
        private readonly IDbUserDAO _userDAO;
        private IConnection _connection;
        private IModel channel;

        public RabbitMQConsumer(IDbUserDAO userDAO)
        {
            _userDAO = userDAO;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672, 
                UserName = "Username",
                Password = "Password"
            };
            this._connection = factory.CreateConnection();
            this.channel = _connection.CreateModel();
            {
                channel.ExchangeDeclare(exchange: "user_events", type: "fanout");
                var queueName = channel.QueueDeclare(queue: "UserQueue").QueueName;
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
                    user.FirstName = userInfo.FirstName;
                    user.LastName = userInfo.LastName;
                    user.EmailAddress = userInfo.EmailAddress;
                    _userDAO.AddUser(user);
                };
                channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

                return Task.CompletedTask;
            }
        }
    }
}
