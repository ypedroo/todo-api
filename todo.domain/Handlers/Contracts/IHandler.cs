using todo.domain.Commands.Contracts;

namespace todo.domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}