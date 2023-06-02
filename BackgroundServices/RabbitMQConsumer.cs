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

        public ExceptionDTO BuildExceptionDTO(Exception ex)
        {
            if (ex == null)
            {
                return null;
            }

            return new ExceptionDTO
            {
                Message = ex.Message,
                Source = ex.Source,
                InnerException = BuildExceptionDTO(ex.InnerException)
            };
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 0000, 
                UserName = "Username",
                Password = "Password"
            };
            this._connection = factory.CreateConnection();
            this._channel = _connection.CreateModel();
            {
                _channel.ExchangeDeclare(exchange: "user_events", type: "fanout");
                var queueName = _channel.QueueDeclare(queue: "UserQueue").QueueName;
                _channel.QueueBind(queue: queueName, exchange: "user_events", routingKey: "Info");
                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += (model, ea) =>
                {
                    try
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        var userInfo = JsonConvert.DeserializeObject<UserDTO>(message);
                        _userDAO.AddUser(userInfo);
                    }
                    catch(Exception ex)
                    {
                        ExceptionDTO dto = BuildExceptionDTO(ex);
                        _rabbitMQPublisher.PublishError(dto);
                    }
                };
                _channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

                return Task.CompletedTask;
            }
        }
    }
}
