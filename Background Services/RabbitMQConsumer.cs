using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using Logbook.Models;
using Logbook.DataAccessLayer.Interfaces;
using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;

namespace Logbook.Background_Services
{
    public class RabbitMQConsumer : BackgroundService
    {
        private readonly IDbUserDAO _userDAO;
        private IConnection _connection;
        private IModel _channel;
        private IRabbitMQPublisher _rabbitMQPublisher;
        public RabbitMQConsumer(IDbUserDAO userDAO, IRabbitMQPublisher rabbitMQPublisher)
        {
            _userDAO = userDAO;
            _rabbitMQPublisher = rabbitMQPublisher;
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
            this._channel = _connection.CreateModel();
            {
                _channel.ExchangeDeclare(exchange: "user_events", type: "fanout");
                var queueName = _channel.QueueDeclare(queue: "UserQueue").QueueName;
                _channel.QueueBind(queue: queueName, exchange: "user_events", routingKey: "");
                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += (model, ea) =>
                {
                    try
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        var userInfo = JsonConvert.DeserializeObject<Jumper>(message);
                        UserDTO user = new UserDTO();
                        user.UserId = userInfo.UserId;
                        user.Username = userInfo.Username;
                        user.FirstName = userInfo.FirstName;
                        user.LastName = userInfo.LastName;
                        user.EmailAddress = userInfo.EmailAddress;
                        _userDAO.AddUser(user);
                    }
                    catch(Exception ex)
                    {
                        string queueName = "ErrorQueue";  
                        _rabbitMQPublisher.PublishError(ex.Message);
                    }

                };
                _channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

                return Task.CompletedTask;
            }
        }
    }
}
