using LinkShortenerShtokal.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace LinkShortenerShtokal.Commands.Base
{
    public interface ICommandHandler<TCommand, TResult> 
        where TCommand : ICommand<TResult> 
        where TResult : ICommandResult
    {
        Task<TResult> HandleAsync(TCommand command);
        Task AfterSaveAsync() => Task.CompletedTask;
        Task OnSaveExceptionAsync(DbUpdateException ex) => Task.CompletedTask;
    }
}
