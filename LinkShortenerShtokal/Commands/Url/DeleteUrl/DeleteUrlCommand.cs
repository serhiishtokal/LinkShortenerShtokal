using LinkShortenerShtokal.Commands.Base;

namespace LinkShortenerShtokal.Commands.Url.DeleteUrl
{
    public class DeleteUrlCommand : ICommand<DeleteUrlCommandResult>
    {
        public DeleteUrlCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
