using Microsoft.EntityFrameworkCore;
using todo.domain.Entities;

namespace todo.infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> Todos { get; set; }
    }
}