namespace API.DbEntities.Errors
{
    public class ApiException
    {
        public ApiException(int statusCode, string description, string message)
        {
            StatusCode = statusCode;
            Description = description;
            Message = message;
        }

        public int StatusCode { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
    }
}
