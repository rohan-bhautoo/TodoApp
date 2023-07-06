using Microsoft.EntityFrameworkCore;
using TodoApp.Backend.Data;
using Task = TodoApp.Backend.Models.Task;

namespace TodoApp.Backend.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TodoAppBackendContext dbContext;

        public TaskRepository(TodoAppBackendContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return dbContext.Task.ToList();
        }

        public Task GetTaskById(int id)
        {
            return dbContext.Task.Find(id);
        }

        public void AddTask(Task task)
        {
            dbContext.Task.Add(task);
            dbContext.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            dbContext.Entry(task).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var task = dbContext.Task.Find(id);
            dbContext.Task.Remove(task);
            dbContext.SaveChanges();
        }
    }
}
