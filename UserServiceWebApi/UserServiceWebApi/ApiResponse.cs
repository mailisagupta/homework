using System.Text.Json.Serialization;

namespace UserServiceWebApi
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Message { get; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message; 
        }

        
    }
}
