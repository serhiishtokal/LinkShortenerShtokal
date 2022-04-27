using AutoMapper;
using LinkShortenerShtokal.Commands.Url.AddUrl;
using LinkShortenerShtokal.Core.Domain;
using LinkShortenerShtokal.Core.Models;
using LinkShortenerShtokal.Queries.ShortenedUrls.GetAllUrlsStatistic;

namespace LinkShortenerShtokal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ShortenedUrl, ShortenedUrlDto>();
            CreateMap<ShortenedUrl, AddUrlResult>();
        }
    }
}
