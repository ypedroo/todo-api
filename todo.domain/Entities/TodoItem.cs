using System;

namespace todo.domain.Entities
{
    public class TodoItem : Entity
    {
        public TodoItem(string title, DateTime date, string refUser)
        {
            Title = title;
            Done = false;
            Date = date;
            RefUser = refUser;
        }
        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; private set; }
        public string RefUser { get; private set; }

        public void MarkAsDone()
        {
            Done = true;
        }
        
        public void MarkAsUndone()
        {
            Done = false;
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }
    }
}