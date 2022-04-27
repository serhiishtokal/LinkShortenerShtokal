using LinkShortenerShtokal.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace LinkShortenerShtokal.Queries.Base
{
    public class QueryDispatcher : IQueryDispatcher
    {
        //private readonly ApplicationContext _dbContext;
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider/*, ApplicationContext dbContext*/)
        {
            _serviceProvider = serviceProvider;
            //_dbContext = dbContext;
        }

        public async Task<TQueryResult> QueryAsync<TQuery, TQueryResult>(TQuery command)
            where TQuery : IQuery<TQueryResult>
            //where TQueryResult : IQueryResult
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command),
                    $"Query: '{typeof(TQuery).Name}' cannot be null.");
            }

            using var scope = _serviceProvider.CreateScope();
            ApplicationContext dbContext = scope.ServiceProvider.GetService<ApplicationContext>();
            var handler = scope.ServiceProvider.GetService<IQueryHandler<TQuery, TQueryResult>>();
            TQueryResult result = default;
            using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                result = await handler.HandleAsync(command);
                try
                {
                    await dbContext.SaveChangesAndCommitAsync();
                }
                catch (DbUpdateException ex)
                {
                    //await handler.OnSaveExceptionAsync(ex);
                    throw;
                }
            }
            //await handler.AfterSaveAsync();
            return result;
        }
    }
}
