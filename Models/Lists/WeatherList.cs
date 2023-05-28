using Logbook.PresentationLayer.DTO;

namespace Logbook.Models.Lists
{
    public class WeatherList
    {
        public List<Weather> _weather { get; set; }

        public WeatherList()
        {
            _weather = new List<Weather>();
        }

        public WeatherList(WeatherListDTO dto)
        {
            _weather = new List<Weather>();
            _weather = dto.weatherList;

        }

        public void Add(Weather weather)
        {
            _weather.Add(weather);
        }
    }
}
