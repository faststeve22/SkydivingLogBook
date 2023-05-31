using Logbook.Models;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IRabbitMQPublisher
    {
        void PublishEventMessage(Jumper createdUser);
    }
}