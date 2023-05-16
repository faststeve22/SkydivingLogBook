using Logbook.Models;

namespace Logbook.DataAccessLayer.Interfaces
{
    public interface IDbUserDAO
    {
        void AddUser(User user);
    }
}
