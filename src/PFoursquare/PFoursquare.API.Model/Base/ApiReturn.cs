namespace PFoursquare.API.Model
{
    public class ApiReturn<T> : ApiReturn
    {
        public new T Data { get; set; }
    }

    public class ApiReturn
    {
        public ApiStatusCode Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public bool Success { get; set; }
    }

    public class ApiError
    {
        public string Message { get; set; }
        public ApiStatusCode Code { get; set; }
    }
}
