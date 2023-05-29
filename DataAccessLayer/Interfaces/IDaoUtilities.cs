using System.Data;

namespace Logbook.DataAccessLayer.Interfaces
{
    public interface IDaoUtilities
    {
        List<T> MapDataToList<T>(IDataReader reader) where T : new();
        void AddParameter(IDbCommand cmd, Object dataObject);
        void AddParameter(IDbCommand cmd, int id, string paramName);
        void AddParameter(IDbCommand cmd, string value, string paramName);


    }
}
