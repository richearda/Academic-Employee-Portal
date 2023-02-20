namespace ISMS_API.Handlers
{
    public class ValidationResult
    {
        public string Key { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        
        public ValidationResult(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public ValidationResult(string key, string message, int statusCode)
        {
            Key = key;
            Message = message;
            StatusCode = statusCode;
        }
    }
}