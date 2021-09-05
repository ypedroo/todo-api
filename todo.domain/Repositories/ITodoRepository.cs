using todo.domain.Entities;

namespace todo.domain.Repositories
{
    public interface ITodoRepository
    {
        void Create(TodoItem todoItem);
        void Update(TodoItem todoItem);
    }
}