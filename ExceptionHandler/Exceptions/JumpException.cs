namespace Logbook.ExceptionHandler.Exceptions
{
    public class JumpException : Exception
    {
        public JumpException() { }
        public JumpException(string operation) : base ($"Error during Jump operation: {operation}") { }
        public JumpException(string operation, Exception innerException) : base ($"Error during Jump operation: {operation}", innerException) { }
    }
}
