using Microsoft.AspNetCore.Mvc;
using Task = TodoApp.Backend.Models.Task;
using TodoApp.Backend.Repositories;

namespace TodoApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        // GET: api/tasks
        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return taskRepository.GetAllTasks();
        }

        // GET: api/tasks/{taskId}
        [HttpGet("{taskId}")]
        public IActionResult Get(int taskId)
        {
            var task = taskRepository.GetTaskById(taskId);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        // POST: api/tasks
        [HttpPost]
        public IActionResult Post([FromBody] Task task)
        {
            if (ModelState.IsValid)
            {
                taskRepository.AddTask(task);
                return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/tasks/{taskId}
        [HttpPut("{taskId}")]
        public IActionResult Put(int taskId, [FromBody] Task task)
        {
            if (ModelState.IsValid && taskId == task.Id)
            {
                var existingTask = taskRepository.GetTaskById(taskId);
                if (existingTask == null)
                {
                    return NotFound();
                }
                taskRepository.UpdateTask(task);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/tasks/{taskId}
        [HttpDelete("{taskId}")]
        public IActionResult Delete(int taskId)
        {
            var existingTask = taskRepository.GetTaskById(taskId);
            if (existingTask == null)
            {
                return NotFound();
            }
            taskRepository.DeleteTask(taskId);
            return NoContent();
        }
    }
}
