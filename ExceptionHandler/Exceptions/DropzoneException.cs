namespace Logbook.ExceptionHandler.Exceptions
{
    public class DropzoneException : Exception
    {
        public DropzoneException() { }
        public DropzoneException(string operation) : base($"Error during dropzone operation: {operation}") { }
        public DropzoneException(string operation, Exception innerException) : base ($"Error during dropzone operation: {operation}", innerException) { }

    }
}
