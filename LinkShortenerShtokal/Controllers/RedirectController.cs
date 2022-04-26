using LinkShortenerShtokal.Commands.Base;
using LinkShortenerShtokal.Commands.Url.RedirectToOriginalUrl;
using LinkShortenerShtokal.Core.Domain;
using LinkShortenerShtokal.Queries.Base;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortenerShtokal.Controllers
{
    [ApiController]
    [Route("")]
    public class RedirectController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ILogger<RedirectController> _logger;

        public RedirectController(ILogger<RedirectController> logger, IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _logger = logger;
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("{urlAlias}", Name = "GetWeatherForecast")]
        public async Task<IActionResult> GetAsync(string urlAlias)
        {
            var command = new GetOriginalUrlCommand(urlAlias);
            var result = await _commandDispatcher.DispatchAsync<GetOriginalUrlCommand, GetOriginalUrlCommandResult>(command);
            return Redirect(result.OriginalUrl);

        }


    }
}