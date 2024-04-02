using Microsoft.EntityFrameworkCore;
using Tester_todo_app.Entities;

namespace Tester_todo_app.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
