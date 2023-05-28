using System.Data;

namespace Logbook.DataAccessLayer
{
    public static class DataMapper
    {
        public static List<T> MapDataToList<T>(IDataReader reader) where T : new()
        {
            var results = new List<T>();

            while (reader.Read())
            {
                var result = new T();
                var type = typeof(T);
                Dictionary<string, object> CurrentRow = new Dictionary<string, object>();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    CurrentRow.Add(reader.GetName(i).Replace("_", ""), reader.GetValue(i));
                }

                foreach (var prop in type.GetProperties())
                {
                    if (CurrentRow.ContainsKey($"{prop.Name.ToLower()}"))
                    {
                        prop.SetValue(result, CurrentRow[prop.Name.ToLower()]);
                    }
                }
                results.Add(result);

            }
            return results;
        }
    }
}
