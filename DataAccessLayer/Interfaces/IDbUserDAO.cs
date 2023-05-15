using Logbook.Models;

namespace Logbook.DataAccessLayer.Interfaces
{
    public interface IDbUserDAO
    {
        User AddUser(User user);
    }
}
