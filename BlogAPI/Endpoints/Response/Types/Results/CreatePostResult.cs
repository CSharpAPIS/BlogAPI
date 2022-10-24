namespace BlogAPI.Endpoints.Response.Types.Results
{
    public class CreatePostResult : EndpointResult
    {
        /// <summary>
        /// The blog that created post belongs to.
        /// </summary>
        public int BlogId { get; set; }
        /// <summary>
        /// The id of the post that has been created.
        /// </summary>
        public int PostId { get; set; }
        /// <summary>
        /// The url of the post that has been created.
        /// it will be like: <c>$HOST/blog-url-here/something-here</c>,
        /// this protperty will contain everything that comes after $HOST.
        /// </summary>
        public string PostUrl { get; set; }
    }
}
