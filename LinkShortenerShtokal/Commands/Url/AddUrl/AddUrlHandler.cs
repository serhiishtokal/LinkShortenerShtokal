using LinkShortenerShtokal.Commands.Base;
using LinkShortenerShtokal.Core.Domain;
using LinkShortenerShtokal.Infrastructure.EF;
using LinkShortenerShtokal.Infrastructure.Services;

namespace LinkShortenerShtokal.Commands.Url.AddUrl
{
    public class AddUrlHandler : ICommandHandler<AddUrlCommand, AddUrlResult>
    {
        private readonly ApplicationContext _context;
        private readonly ILinkShortenerService _linkShortenerService;
        public AddUrlHandler(ApplicationContext context, ILinkShortenerService linkShortenerService)
        {
            _context = context;
            _linkShortenerService = linkShortenerService;
        }

        public async Task<AddUrlResult> HandleAsync(AddUrlCommand command)
        {
            var shortenedUrl = new ShortenedUrl(command.Url);
            await _context.AddAsync(shortenedUrl);
            await _context.SaveChangesAsync();
            var encodedUrl = _linkShortenerService.Encode(shortenedUrl.UrlId);
            shortenedUrl.UrlAlias = encodedUrl;
            var result = new AddUrlResult() { UrlAlias = encodedUrl };
            return result;
        }
    }
}
