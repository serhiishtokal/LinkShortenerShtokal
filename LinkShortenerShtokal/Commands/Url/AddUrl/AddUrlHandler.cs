using AutoMapper;
using LinkShortenerShtokal.Commands.Base;
using LinkShortenerShtokal.Core.Domain;
using LinkShortenerShtokal.Infrastructure.EF;
using LinkShortenerShtokal.Infrastructure.Services;

namespace LinkShortenerShtokal.Commands.Url.AddUrl
{
    public class AddUrlHandler : ICommandHandler<AddUrlCommand, AddUrlResult>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly ILinkShortenerService _linkShortenerService;
        public AddUrlHandler(ApplicationContext context, ILinkShortenerService linkShortenerService, IMapper mapper)
        {
            _context = context;
            _linkShortenerService = linkShortenerService;
            _mapper = mapper;
        }

        public async Task<AddUrlResult> HandleAsync(AddUrlCommand command)
        {
            var shortenedUrl = new ShortenedUrl(command.Url);
            await _context.AddAsync(shortenedUrl);
            await _context.SaveChangesAsync();
            var encodedUrl = _linkShortenerService.Encode(shortenedUrl.UrlId);
            shortenedUrl.UrlAlias = encodedUrl;

            var result = _mapper.Map<AddUrlResult>(shortenedUrl);
            return result;
        }
    }
}
