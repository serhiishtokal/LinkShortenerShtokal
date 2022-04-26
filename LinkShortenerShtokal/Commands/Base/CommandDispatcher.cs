using LinkShortenerShtokal.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace LinkShortenerShtokal.Commands.Base
{
    public class CommandDispatcher : ICommandDispatcher
    {
        //private readonly ApplicationContext _dbContext;
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(/*ApplicationContext dbContext,*/ IServiceProvider serviceProvider)
        {
            //_dbContext = dbContext;
            _serviceProvider = serviceProvider;
        }

        public async Task<TCommandResult> DispatchAsync<TCommand, TCommandResult>(TCommand command) 
            where TCommand : ICommand<TCommandResult> 
            where TCommandResult : ICommandResult
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command),
                    $"Command: '{typeof(TCommand).Name}' cannot be null.");
            }

            using var scope = _serviceProvider.CreateScope();
            ApplicationContext dbContext = scope.ServiceProvider.GetService<ApplicationContext>();
            var handler = scope.ServiceProvider.GetService<ICommandHandler<TCommand, TCommandResult>>();
            TCommandResult result = default;
            using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                //var kj = handler.Handle2(command);
                //var isContextEqual = kj == dbContext;
                //if (isContextEqual)
                //{

                //}
                result = await handler.HandleAsync(command);
                try
                {
                    await dbContext.SaveChangesAndCommitAsync();
                }
                catch (DbUpdateException ex)
                {
                    await handler.OnSaveExceptionAsync(ex);
                    throw;
                }
            }
            await handler.AfterSaveAsync();
            return result;
        }
    }
}
