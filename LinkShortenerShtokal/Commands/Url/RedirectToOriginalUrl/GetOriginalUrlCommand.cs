using LinkShortenerShtokal.Commands.Base;

namespace LinkShortenerShtokal.Commands.Url.RedirectToOriginalUrl
{
    public class GetOriginalUrlCommand : ICommand<GetOriginalUrlCommandResult>
    {
        public string UrlAlias { get; set; }

        public GetOriginalUrlCommand(string urlAlias)
        {
            UrlAlias = urlAlias;
        }
    }
}
