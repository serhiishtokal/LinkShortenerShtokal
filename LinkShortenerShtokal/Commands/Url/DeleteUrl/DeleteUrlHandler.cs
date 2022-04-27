using LinkShortenerShtokal.Commands.Base;
using LinkShortenerShtokal.Core.Domain;
using LinkShortenerShtokal.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace LinkShortenerShtokal.Commands.Url.DeleteUrl
{

    public class DeleteUrlHandler : ICommandHandler<DeleteUrlCommand, DeleteUrlCommandResult>
    {
        private readonly ApplicationContext _context;
        private readonly IQueryable<ShortenedUrl> _shortenedUrls;


        public DeleteUrlHandler(ApplicationContext context)
        {
            _context = context;
            _shortenedUrls = context.Set<ShortenedUrl>();
        }

        public async Task<DeleteUrlCommandResult> HandleAsync(DeleteUrlCommand command)
        {
            var shortenedUrl = await _shortenedUrls.Where(x => x.Id == command.Id).FirstOrDefaultAsync();
            if (shortenedUrl == null)
            {
                throw new ArgumentException();
            }
            shortenedUrl.IsDeleted = true;
            return new DeleteUrlCommandResult();
        }
    }
}
