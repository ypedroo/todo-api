using System;
using Flunt.Notifications;
using Flunt.Validations;
using todo.domain.Commands.Contracts;

namespace todo.domain.Commands
{
    public class CreateTodoCommand : Notifiable, IValidatable
    {
        public CreateTodoCommand()
        {
        }

        public CreateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public string Title { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Title, 3 , "Title", "Invalid Title should be greater than 3")
                    .HasMinLen(User, 6 , "User", "Invalid User should be greater than 6"));
        }
    }
}