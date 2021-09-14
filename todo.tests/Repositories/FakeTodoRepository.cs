using System;
using System.Collections.Generic;
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

        public IEnumerable<TodoItem> GetAll(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            throw new NotImplementedException();
        }
    }
}