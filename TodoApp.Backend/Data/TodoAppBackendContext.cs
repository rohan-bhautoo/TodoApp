using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Backend.Models;

namespace TodoApp.Backend.Data
{
    public class TodoAppBackendContext : DbContext
    {
        public TodoAppBackendContext (DbContextOptions<TodoAppBackendContext> options)
            : base(options)
        {
        }

        public DbSet<TodoApp.Backend.Models.Task> Task { get; set; } = default!;
    }
}
