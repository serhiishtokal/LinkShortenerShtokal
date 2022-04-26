namespace LinkShortenerShtokal.Commands.Base
{
    public interface ICommandDispatcher
    {
        Task<TCommandResult> DispatchAsync<TCommand, TCommandResult>(TCommand command)
            where TCommand : ICommand<TCommandResult>
            where TCommandResult : ICommandResult;
    }
}