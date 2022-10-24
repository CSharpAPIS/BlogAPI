
namespace BlogAPI.Endpoints.Response
{
    public class EndpointResponse<T> where T : EndpointResult
    {
        public bool Success { get; set; }
        public EndpointError Error { get; set; }
        public T Result { get; set; }
    }
}
