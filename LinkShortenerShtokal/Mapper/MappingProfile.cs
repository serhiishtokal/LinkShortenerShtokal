using AutoMapper;
using LinkShortenerShtokal.Core.Domain;
using LinkShortenerShtokal.Queries.ShortenedUrls.GetAllUrlsStatistic;

namespace LinkShortenerShtokal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ShortenedUrl, ShortenedUrlDto>();
        }
    }
}
