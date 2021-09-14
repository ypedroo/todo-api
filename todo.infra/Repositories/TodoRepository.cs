using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using todo.domain.Entities;
using todo.domain.Queries;
using todo.domain.Repositories;
using todo.infra.Contexts;

namespace todo.infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _dataContext;

        public TodoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(TodoItem todoItem)
        {
            _dataContext.Todos.Add(todoItem);
            _dataContext.SaveChanges();
        }

        public void Update(TodoItem todoItem)
        {
            _dataContext.Entry(todoItem).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public TodoItem GetById(Guid commandId, string user)
        {
            return _dataContext.Todos.AsNoTracking().FirstOrDefault(x => x.Id == commandId && x.RefUser == user);
            
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            return _dataContext.Todos.AsNoTracking().Where(TodoQueries.GetAll(user)).OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            return _dataContext.Todos.AsNoTracking().Where(TodoQueries.GetAllDone(user)).OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            return _dataContext.Todos.AsNoTracking().Where(TodoQueries.GeAllUndone(user)).OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            return _dataContext.Todos.AsNoTracking().Where(TodoQueries.GetByPeriod(user, date, done))
                .OrderBy(x => x.Date);
        }
    }
}