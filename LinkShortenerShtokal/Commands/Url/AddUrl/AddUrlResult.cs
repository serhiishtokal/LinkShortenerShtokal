using LinkShortenerShtokal.Commands.Base;

namespace LinkShortenerShtokal.Commands.Url.AddUrl
{
    public class AddUrlResult: ICommandResult
    {
        public string UrlAlias { get; set; }
    }
}
