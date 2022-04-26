using LinkShortenerShtokal.Queries.Base;

namespace LinkShortenerShtokal.Queries.ShortenedUrls.GetAllUrlsStatistic
{
    public class GetAllUrlsStatisticResult : IQueryResult
    {
        public List<ShortenedUrlDto> ShortenedUrlDtos { get; set; }
    }

    public class ShortenedUrlDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string OriginalUrl { get; set; }
        public string UrlAlias { get; set; }
        public int NumberOfUsages { get; set; }
    }
}
