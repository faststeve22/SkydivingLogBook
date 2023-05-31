using Logbook.DataAccessLayer.Interfaces;
using Logbook.ExceptionHandler.Exceptions;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
using System.Data;
using System.Data.SqlClient;

namespace Logbook.DataAccessLayer.DAO
{
    public class WeatherDAO : IWeatherDAO
    {
        IDbConnectionFactory _connectionFactory;
        IDaoUtilities _daoUtilities;
        public WeatherDAO(IDbConnectionFactory connectionFactory, IDaoUtilities daoUtilities)
        {
            _connectionFactory = connectionFactory;
            _daoUtilities = daoUtilities;
        }

        public WeatherDTO AddWeather(WeatherDTO dto)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO Weather (ground_temperature, ground_wind_speed, additional_notes, ground_wind_direction_at_takeoff, ground_wind_direction_at_landing, temperature_at_jump_altitude) VALUES (@groundTemperature, @groundWindSpeed, @notes, @groundWindDirectionAtTakeoff, @groundWindDirectionAtLanding, @temperatureAtJumpAltitude)";
                    _daoUtilities.AddParameter(cmd, dto);
                    IDataReader reader = cmd.ExecuteReader();
                    return new WeatherDTO(_daoUtilities.MapDataToList<Weather>(reader)[0]);
                }
            }
            catch(SqlException ex)
            {
                throw new WeatherException("AddWeather", ex);
            }
        }

        public WeatherDTO GetWeatherById(int weatherId)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT weather_id, ground_temperature, ground_wind_speed, additional_notes, ground_wind_direction_at_takeoff, ground_wind_direction_at_landing, temperature_at_jump_altitude FROM Weather WHERE weather_id = @weatherId";
                    _daoUtilities.AddParameter(cmd, weatherId, "@weatherId");
                    IDataReader reader = cmd.ExecuteReader();
                    return new WeatherDTO(_daoUtilities.MapDataToList<Weather>(reader)[0]);
                }
            }
            catch (SqlException ex)
            {
                throw new WeatherException("GetWeatherById", ex);
            }
        }

        public WeatherListDTO GetWeatherList()
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT weather_id, ground_temperature, ground_wind_speed, additional_notes, ground_wind_direction_at_takeoff, ground_wind_direction_at_landing, temperature_at_jump_altitude FROM Weather";
                    IDataReader reader = cmd.ExecuteReader();
                    return new WeatherListDTO(_daoUtilities.MapDataToList<Weather>(reader));
                }
            }
            catch(SqlException ex)
            {
                throw new WeatherException("GetWeatherList", ex);
            }
        }

        public WeatherListDTO GetWeatherListByUserId(int userId)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT Weather.weather_id, ground_temperature, ground_wind_speed, additional_notes, ground_wind_direction_at_takeoff, ground_wind_direction_at_landing, temperature_at_jump_altitude FROM Weather JOIN Jump ON Jump.weather_id = Weather.weather_id WHERE user_id = @userId";
                    _daoUtilities.AddParameter(cmd, userId, "@userId");
                    IDataReader reader = cmd.ExecuteReader();
                    return new WeatherListDTO(_daoUtilities.MapDataToList<Weather>(reader));
                }
            }
            catch(SqlException ex)
            {
                throw new WeatherException("GetWeatherListByUserId", ex);
            }
        }


        public void UpdateWeather(WeatherDTO dto)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "UPDATE Weather SET ground_temperature = @groundTemperature, ground_wind_speed = @groundWindSpeed, additional_notes = @notes, ground_wind_direction_at_takeoff = @groundWindDirectionAtTakeoff, ground_wind_direction_at_landing = @groundWindDirectionAtLanding, temperature_at_jump_altitude = @temperatureAtJumpAltitude WHERE weather_id = @weatherId";
                    _daoUtilities.AddParameter(cmd, dto);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw new WeatherException("UpdateWeather", ex);
            }
        }

        public void DeleteWeather(int weatherId)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Weather WHERE weather_id = @weatherId";
                    _daoUtilities.AddParameter(cmd, weatherId, "@weatherId");
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw new WeatherException("DeleteWeather", ex);
            }
        }

        public void DeleteWeatherByUserId(int userId)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Weather WHERE weather_id IN (SELECT weather_id FROM Jump WHERE user_id = @userId)";
                    _daoUtilities.AddParameter(cmd, userId, "@userId");
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw new WeatherException("DeleteWeatherByUserId", ex);
            }
        }
    }
}
