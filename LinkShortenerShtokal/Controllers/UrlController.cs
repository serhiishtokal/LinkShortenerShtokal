using LinkShortenerShtokal.Commands.Base;
using LinkShortenerShtokal.Commands.Url.AddUrl;
using LinkShortenerShtokal.Commands.Url.DeleteUrl;
using LinkShortenerShtokal.Core.Models;
using LinkShortenerShtokal.Queries.Base;
using LinkShortenerShtokal.Queries.ShortenedUrls.GetAllUrlsStatistic;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LinkShortenerShtokal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        public UrlController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName()); // `Dns.Resolve()` method is deprecated.
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            var result = await _queryDispatcher.QueryAsync<GetAllUrlsStatisticQuery, List<ShortenedUrlDto>>(new GetAllUrlsStatisticQuery());
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string url)
        {
            var result = await _commandDispatcher.DispatchAsync<AddUrlCommand, AddUrlResult>(new AddUrlCommand(url));
            return Json(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _commandDispatcher.DispatchAsync<DeleteUrlCommand, DeleteUrlCommandResult>(new DeleteUrlCommand(id));
            return Json(result);
        }
    }
}
