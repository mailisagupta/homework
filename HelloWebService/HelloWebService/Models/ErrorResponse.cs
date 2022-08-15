namespace HelloWebService.Models
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public int DBCode { get; set; }

        public string Field { get; set; }

        public object data { get; set; }
    }
}
