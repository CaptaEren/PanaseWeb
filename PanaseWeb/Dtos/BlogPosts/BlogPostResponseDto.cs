namespace PanaseWeb.Dtos.BlogPosts
{
    public class BlogPostResponseDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public string Excerpt => Content.Length > 100 ? Content[..100] + "..." : Content;
        public DateTime PublishedDate { get; set; }
    }
}
