using System;
using todo.domain.Entities;
using todo.domain.Repositories;

namespace todo.tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todoItem)
        {
        }

        public void Update(TodoItem todoItem)
        {
        }

        public TodoItem GetById(Guid commandId, string commandUser)
        {
            return new TodoItem("test", new DateTime(), "test");
        }
    }
}