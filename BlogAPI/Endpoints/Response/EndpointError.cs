using BlogAPI.Endpoints.Response.Types.Errors;

namespace BlogAPI.Endpoints.Response
{
    public class EndpointError
    {
        public ErrorCodes ErrorCode { get; set; }
        public string Message { get; set; }
        public string Origin { get; set; }
    }
}
