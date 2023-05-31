namespace Logbook.ExceptionHandler.Exceptions
{
    public class WeatherException : Exception
    {
        public WeatherException() { }
        public WeatherException(string operation) : base($"Error during Weather operation: {operation}") { }
        public WeatherException(string operation, Exception innerException) : base ($"Error during Weather operation: {operation}", innerException) { }

    }
}
