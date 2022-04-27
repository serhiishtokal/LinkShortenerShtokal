namespace LinkShortenerShtokal.Core.Models
{
    public class ShortenedUrlDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string OriginalUrl { get; set; }
        public string UrlAlias { get; set; }
        public int NumberOfUsages { get; set; }
    }
}
