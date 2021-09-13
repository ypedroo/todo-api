using Flunt.Notifications;
using todo.domain.Commands;
using todo.domain.Commands.Contracts;
using todo.domain.Entities;
using todo.domain.Handlers.Contracts;
using todo.domain.Repositories;

namespace todo.domain.Handlers
{
    public class TodoHandler : Notifiable, IHandler<CreateTodoCommand>, IHandler<UpdateTodoCommand>, IHandler<MarkTodoAsDoneCommand>, IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Error creating the task", command.Notifications);

            var todo = new TodoItem(command.Title, command.Date, command.User);
            _repository.Create(todo);

            return new GenericCommandResult(true, "Task Persisted", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Error creating the task", command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);
            _repository.Update(todo);

            return new GenericCommandResult(true, "Task Persisted", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Error creating the task", command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);
           todo.MarkAsDone();
            _repository.Update(todo);

            return new GenericCommandResult(true, "Task Persisted", todo);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Error creating the task", command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);
            todo.MarkAsUndone();
            _repository.Update(todo);

            return new GenericCommandResult(true, "Task Persisted", todo);
        }
    }
}