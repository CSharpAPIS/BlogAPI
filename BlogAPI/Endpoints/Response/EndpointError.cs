namespace BlogAPI.Endpoints.Response
{
    public class EndpointError
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public string Origin { get; set; }
    }
}
