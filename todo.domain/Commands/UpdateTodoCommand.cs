using System;
using Flunt.Notifications;
using Flunt.Validations;
using ICommand = todo.domain.Commands.Contracts.ICommand;

namespace todo.domain.Commands
{
    public class UpdateTodoCommand : Notifiable, ICommand
    {
        public UpdateTodoCommand(Guid id, string user, string title)
        {
            Id = id;
            User = user;
            Title = title;
        }

        public Guid Id { get; set; }
        public string User { get; set; }
        public string Title { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Title, 3, "Title", "Invalid Title should be greater than 3")
                    .HasMinLen(User, 6, "User", "Invalid User should be greater than 6"));
        }
    }
}