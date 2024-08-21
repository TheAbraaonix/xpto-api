namespace XptoAPI.Exceptions
{
    public class RecordAlreadyExistsException : Exception
    {
        public string Message { get; }
        
        public RecordAlreadyExistsException(string message) : base(message)
        { 
            Message = message;
        }
    }
}
