using Task = TodoApp.Backend.Models.Task;

namespace TodoApp.Backend.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAllTasks();
        Task GetTaskById(int taskId);
        void AddTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(int taskId);
    }
}
