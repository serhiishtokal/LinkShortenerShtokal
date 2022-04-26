using LinkShortenerShtokal.Commands.Base;
using LinkShortenerShtokal.Core.Domain;
using LinkShortenerShtokal.Infrastructure.EF;
using LinkShortenerShtokal.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace LinkShortenerShtokal.Commands.Url.RedirectToOriginalUrl
{
    public class GetOriginalUrlCommandHandler : ICommandHandler<GetOriginalUrlCommand, GetOriginalUrlCommandResult>
    {
        private readonly ApplicationContext _context;
        private readonly IQueryable<ShortenedUrl> _shortenedUrls;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRedirectService _redirectService;


        public GetOriginalUrlCommandHandler(ApplicationContext context, IHttpContextAccessor httpContextAccessor, IRedirectService redirectService)
        {
            _context = context;
            _shortenedUrls = context.Set<ShortenedUrl>();
            _httpContextAccessor = httpContextAccessor;
            _redirectService = redirectService;
        }

        public async Task<GetOriginalUrlCommandResult> HandleAsync(GetOriginalUrlCommand query)
        {
            var shortenedUrl = await _redirectService.GetUrlForRedirectAsync(query.UrlAlias);
            return new GetOriginalUrlCommandResult() { OriginalUrl = shortenedUrl.OriginalUrl };
        }
    }
}
