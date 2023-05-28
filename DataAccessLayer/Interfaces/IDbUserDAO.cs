using Logbook.PresentationLayer.DTO;

namespace Logbook.DataAccessLayer.Interfaces
{
    public interface IDbUserDAO
    {
        void AddUser(UserDTO user);
        UserDTO GetUser(int userId);
        void UpdateUser(UserDTO user);
        void DeleteUser(int userId);

    }

}
