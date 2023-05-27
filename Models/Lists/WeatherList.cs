using Logbook.PresentationLayer.DTO;

namespace Logbook.Models.Lists
{
    public class WeatherList
    {
        public List<Weather> Weather { get; set; }

        public WeatherList()
        {
          
        }

        public WeatherList(WeatherListDTO dto)
        {
            Weather = dto.weatherList;
        }
    }
}
