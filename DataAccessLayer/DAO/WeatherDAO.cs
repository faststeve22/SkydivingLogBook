using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.Models.Lists;
using System.Data;

namespace Logbook.DataAccessLayer.DAO
{
    public class WeatherDAO : IWeatherDAO
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public WeatherDAO(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void AddWeather(Weather weather)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Weather (ground_temperature, ground_wind_speed, additional_notes, ground_wind_direction_at_takeoff, ground_wind_direction_at_landing, temperature_at_jump_altitude) VALUES (@groundTemperature, @groundWindSpeed, @additionalNotes, @groundWindDirectionAtTakeoff, @groundWindDirectionAtLanding, @temperatureAtJumpAltitude)";
                AddParameter(cmd, "@groundTemperature", weather.GroundTemperature);
                AddParameter(cmd, "@groundWindSpeed", weather.GroundWindSpeed);
                AddParameter(cmd, "@additionalNotes", weather.Notes);
                AddParameter(cmd, "@groundWindDirectionAtTakeoff", weather.GroundWindDirectionAtTakeoff);
                AddParameter(cmd, "@groundWindDirectionAtLanding", weather.GroundWindDirectionAtLanding);
                AddParameter(cmd, "@temperatureAtJumpAltitude", weather.TemperatureAtJumpAltitude);
                cmd.ExecuteNonQuery();
            }
        }

        public Weather GetWeather(int weatherId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT weather_id, ground_temperature, ground_wind_speed, additional_notes, ground_wind_direction_at_takeoff, ground_wind_direction_at_landing, temperature_at_jump_altitude FROM Weather WHERE weather_id = @weatherId";
                AddParameter(cmd, "@weatherId", weatherId);
                IDataReader reader = cmd.ExecuteReader();
                return WeatherReader(reader)[0];
            }
        }

        public WeatherList GetWeatherList(int userId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT weather_id, ground_temperature, ground_wind_speed, additional_notes, ground_wind_direction_at_takeoff, ground_wind_direction_at_landing, temperature_at_jump_altitude FROM Weather JOIN Jump ON Jump.weather_id = Weather.weather_id WHERE user_id = @userId";
                AddParameter(cmd, "@userId", userId);
                IDataReader reader = cmd.ExecuteReader();
                return new WeatherList(WeatherReader(reader));
            }
        }


        public void UpdateWeather(Weather weather)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Weather SET ground_temperature = @groundTemperature, ground_wind_speed = @groundWindSpeed, additional_notes = @additionalNotes, ground_wind_direction_at_takeoff = @groundWindDirectionAtTakeoff, ground_wind_direction_at_landing = @groundWindDirectionAtLanding, temperature_at_jump_altitude = @temperatureAtJumpAltitude WHERE weather_id = @weatherId";
                AddParameter(cmd, "@weatherId", weather.WeatherId);
                AddParameter(cmd, "@groundTemperature", weather.GroundTemperature);
                AddParameter(cmd, "@groundWindSpeed", weather.GroundWindSpeed);
                AddParameter(cmd, "@additionalNotes", weather.Notes);
                AddParameter(cmd, "@groundWindDirectionAtTakeoff", weather.GroundWindDirectionAtTakeoff);
                AddParameter(cmd, "@groundWindDirectionAtLanding", weather.GroundWindDirectionAtLanding);
                AddParameter(cmd, "@temperatureAtJumpAltitude", weather.TemperatureAtJumpAltitude);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteWeather(int weatherId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Weather WHERE weather_id = @weatherId";
                AddParameter(cmd, "@weatherId", weatherId);
                cmd.ExecuteNonQuery();
            }
        }

        private List<Weather> WeatherReader(IDataReader reader)
        {
            List<Weather> WeatherList = new List<Weather>();
            while(reader.Read())
            {
                Weather weather = new Weather();
                weather.WeatherId = Convert.ToInt32(reader["weather_id"]);
                weather.GroundTemperature = Convert.ToString(reader["ground_temperature"]);
                weather.GroundWindSpeed = Convert.ToString(reader["ground_wind_speed"]);
                weather.Notes = Convert.ToString(reader["additional_notes"]);
                weather.GroundWindDirectionAtTakeoff = Convert.ToString(reader["ground_wind_direction_at_takeoff"]);
                weather.GroundWindDirectionAtLanding = Convert.ToString(reader["ground_wind_direction_at_landing"]);
                weather.TemperatureAtJumpAltitude = Convert.ToInt32(reader["temperature_at_jump_altitude"]);
                WeatherList.Add(weather);
            }
            return WeatherList;
        }

        private void AddParameter(IDbCommand cmd, string paramName, object value)
        {
            var Parameter = cmd.CreateParameter();
            Parameter.ParameterName = paramName;
            Parameter.Value = value;
            cmd.Parameters.Add(Parameter);
        }
    }
}
