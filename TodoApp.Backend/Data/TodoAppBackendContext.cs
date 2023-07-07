using Microsoft.EntityFrameworkCore;

namespace TodoApp.Backend.Data
{
    public class TodoAppBackendContext : DbContext
    {
        public TodoAppBackendContext (DbContextOptions<TodoAppBackendContext> options)
            : base(options)
        {
        }

        public DbSet<TodoApp.Backend.Models.Task> Task { get; set; } = default!;
        public DbSet<TodoApp.Backend.Models.User> User { get; set; } = default!;
    }
}
