namespace Logbook.ExceptionHandler.Exceptions
{
    public class AircraftException : Exception
    {
        public AircraftException() { }
        public AircraftException(string operation) : base($"Error during Aircraft operation: {operation}") { }
        public AircraftException(string operation, Exception innerException) : base ($"Error during Aircraft operation: {operation}", innerException) { }

    }
}
