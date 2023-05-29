using Logbook.DataAccessLayer.Interfaces;
using Microsoft.Extensions.Primitives;
using System.Data;

namespace Logbook.DataAccessLayer.Utilities
{
    public class DaoUtilities : IDaoUtilities
    {
        public void AddParameter(IDbCommand cmd, Object dataObject)
        { 
            foreach (var prop in dataObject.GetType().GetProperties())
            {
                var Parameter = cmd.CreateParameter();
                Parameter.ParameterName = "@" + char.ToLowerInvariant(prop.Name[0]) + prop.Name.Substring(1);
                Parameter.Value = prop.GetValue(dataObject);
                cmd.Parameters.Add(Parameter);
            }
        }

        public void AddParameter(IDbCommand cmd, int id, string paramName)
        {
            var Parameter = cmd.CreateParameter();
            Parameter.ParameterName = paramName;
            Parameter.Value = id;
            cmd.Parameters.Add(Parameter);
        }

        public void AddParameter(IDbCommand cmd, string value, string paramName)
        {
            var Parameter = cmd.CreateParameter();
            Parameter.ParameterName = paramName;
            Parameter.Value = value;
            cmd.Parameters.Add(Parameter);
        }

        public List<T> MapDataToList<T>(IDataReader reader) where T : new()
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
