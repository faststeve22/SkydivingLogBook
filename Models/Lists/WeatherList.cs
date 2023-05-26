namespace Logbook.Models.Lists
{
    public class WeatherList
    {
        public List<Weather> Weather { get; set; }
        public WeatherList(List<Weather> weather)
        {
            Weather = weather;
        }
    }
}
