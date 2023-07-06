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

        // GET: api/tasks/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var task = taskRepository.GetTaskById(id);
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

        // PUT: api/tasks/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Task task)
        {
            if (ModelState.IsValid && id == task.Id)
            {
                var existingTask = taskRepository.GetTaskById(id);
                if (existingTask == null)
                {
                    return NotFound();
                }
                taskRepository.UpdateTask(task);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/tasks/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingTask = taskRepository.GetTaskById(id);
            if (existingTask == null)
            {
                return NotFound();
            }
            taskRepository.DeleteTask(id);
            return NoContent();
        }
    }
}
