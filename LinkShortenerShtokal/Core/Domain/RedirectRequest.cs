namespace LinkShortenerShtokal.Core.Domain
{
    public class RedirectRequest : DomainBase
    {
        public RedirectRequest(string remoteIpAddress, Guid shortenedUrlId)
        {
            RemoteIpAddress = remoteIpAddress;
            ShortenedUrlId = shortenedUrlId;
        }

        public string RemoteIpAddress { get; set; }
        public Guid ShortenedUrlId { get; set; }
        public ShortenedUrl ShortenedUrl { get; set; }
    }
}
