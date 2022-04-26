using LinkShortenerShtokal.Commands.Base;

namespace LinkShortenerShtokal.Commands.Url.AddUrl
{
    public class AddUrlCommand : ICommand<AddUrlResult>
    {
        public string Url { get; set; }

        public AddUrlCommand(string url)
        {
            Url = url;
        }
    }
}
