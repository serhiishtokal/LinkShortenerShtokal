using AutoMapper;
using LinkShortenerShtokal.Core.Domain;
using LinkShortenerShtokal.Infrastructure.EF;
using LinkShortenerShtokal.Queries.Base;
using Microsoft.EntityFrameworkCore;

namespace LinkShortenerShtokal.Queries.ShortenedUrls.GetAllUrlsStatistic
{
    public class GetAllUrlsStatisticHandler : IQueryHandler<GetAllUrlsStatisticQuery, GetAllUrlsStatisticResult>
    {
        private readonly IQueryable<ShortenedUrl> _shortenedUrlsQuery;
        private readonly IMapper _mapper;

        public GetAllUrlsStatisticHandler(ApplicationContext dbContext, IMapper mapper)
        {
            _shortenedUrlsQuery = dbContext.Set<ShortenedUrl>().AsNoTracking();
            _mapper = mapper;
        }

        public async Task<GetAllUrlsStatisticResult> HandleAsync(GetAllUrlsStatisticQuery query)
        {
            var activeShortenedUrls = await _shortenedUrlsQuery.Where(x => !x.IsDeleted).ToListAsync();
            var results = _mapper.Map<List<ShortenedUrlDto>>(activeShortenedUrls);
            return new GetAllUrlsStatisticResult() { ShortenedUrlDtos = results };
        }
    }
}
