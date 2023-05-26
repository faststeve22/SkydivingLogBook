using Logbook.Models;

namespace Logbook.DataAccessLayer.Interfaces
{
    public interface IDbUserDAO
    {
        void AddUser(Jumper user);
    }
}
