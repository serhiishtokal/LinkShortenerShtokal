using LinkShortenerShtokal.Commands.Url.RedirectToOriginalUrl;
using LinkShortenerShtokal.Core.Domain;
using LinkShortenerShtokal.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LinkShortenerShtokal.Infrastructure.Services
{

    public interface IRedirectService
    {
        Task<ShortenedUrl> GetUrlForRedirectAsync(string urlAlias);
    }
    public class RedirectService : IRedirectService
    {
        private readonly ApplicationContext _context;
        private readonly IQueryable<ShortenedUrl> _shortenedUrls;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RedirectService(ApplicationContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _shortenedUrls = context.Set<ShortenedUrl>().AsNoTracking();
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ShortenedUrl> GetUrlForRedirectAsync(string urlAlias)
        {
            var shortenedUrl = await _shortenedUrls
                .Where(x => x.UrlAlias == urlAlias)
                .FirstOrDefaultAsync();
            if (shortenedUrl == null) throw new Exception("Not found");
            AfterRedirectActions(shortenedUrl);
            return shortenedUrl;
        }

        private void AfterRedirectActions(ShortenedUrl shortenedUrl)
        {
            shortenedUrl.NumberOfUsages++;
            var iPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var newRedirectRequest = new RedirectRequest(iPAddress, shortenedUrl.Id);
            _context.Add(newRedirectRequest);
            
            _context.Update(shortenedUrl);
        }
    }

}
