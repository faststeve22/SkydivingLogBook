using Logbook.Models;
using Logbook.Models.Lists;

namespace Logbook.PresentationLayer.DTO
{
    public class WeatherListDTO
    {
        public List<Weather> weatherList { get; set; }

        public WeatherListDTO()
        {

        }

        public WeatherListDTO(WeatherList list)
        {
            weatherList = list.Weather;
        }
    }
}
