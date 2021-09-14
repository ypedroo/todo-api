using System;
using System.Linq.Expressions;
using todo.domain.Entities;

namespace todo.domain.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAll(string user)
        {
            return x => x.RefUser == user;
        }
        
        public static Expression<Func<TodoItem, bool>> GeAllDone(string user)
        {
            return x => x.RefUser == user && x.Done;
        }

        public static Expression<Func<TodoItem, bool>> GeAllUndone(string user)
        {
            return x => x.RefUser == user && x.Done == false;
        }

        public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime date, bool done)
        {
            return x => x.RefUser == user && x.Done && x.Date.Date == date.Date;
        }
    }
}