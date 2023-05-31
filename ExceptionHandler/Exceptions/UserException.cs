namespace Logbook.ExceptionHandler.Exceptions
{
    public class UserException : Exception
    {
        public UserException() { }
        public UserException(string operation) : base($"Error during User operation: {operation}") { }
        public UserException(string operation, Exception innerException) : base($"Error during User operation: {operation}", innerException) { }
    }

}
