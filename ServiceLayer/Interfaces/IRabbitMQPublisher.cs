
namespace Logbook.ServiceLayer.Interfaces
{
    public interface IRabbitMQPublisher
    {
        void PublishError(string errorMessage);

    }
}