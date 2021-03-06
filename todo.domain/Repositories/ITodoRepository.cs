using System;
using System.Collections;
using System.Collections.Generic;
using todo.domain.Entities;

namespace todo.domain.Repositories
{
    public interface ITodoRepository
    {
        void Create(TodoItem todoItem);
        void Update(TodoItem todoItem);
        TodoItem GetById(Guid commandId, string user); 
        IEnumerable<TodoItem> GetAll(string user);

        IEnumerable<TodoItem> GetAllDone(string user);

        IEnumerable<TodoItem> GetAllUndone(string user);


        IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done);
    }
}