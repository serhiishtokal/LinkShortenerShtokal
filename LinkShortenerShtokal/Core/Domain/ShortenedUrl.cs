using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkShortenerShtokal.Core.Domain
{
    public class ShortenedUrl : DomainBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UrlId { get; set; }
        public string OriginalUrl { get; set; }
        public string UrlAlias { get; set; }
        public int NumberOfUsages { get; set; }

        public ShortenedUrl(string originalUrl)
        { 
            OriginalUrl = originalUrl;
        }
    }
}
