namespace SwordLand.API.Contracts
{
    public class PostRequest
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summery { get; set; }
        public string Category { get; set; }
    }
}
