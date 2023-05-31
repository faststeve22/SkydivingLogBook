namespace Logbook.ExceptionHandler.Exceptions
{
    public class EquipmentException : Exception
    {
        public EquipmentException() { }
        public EquipmentException(string operation) : base($"Error during Equipment operation: {operation}") { }
        public EquipmentException(string operation, Exception innerException) : base ($"Error during Equipment operation: {operation}", innerException) { }

    }
}
