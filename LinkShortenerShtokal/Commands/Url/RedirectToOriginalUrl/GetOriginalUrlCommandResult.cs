using LinkShortenerShtokal.Commands.Base;
using LinkShortenerShtokal.Queries.Base;
using System.Net.Mail;

namespace LinkShortenerShtokal.Commands.Url.RedirectToOriginalUrl
{

    public class GetOriginalUrlCommandResult : ICommandResult
    {
        public string OriginalUrl { get; set; }
    }
}
