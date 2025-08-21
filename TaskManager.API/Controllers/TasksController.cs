using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.DTOs;
using TaskManager.Domain.Entities;
using TaskManager.Persistence.Data;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TasksController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _context.Tasks.ToList();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(Guid id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public ActionResult CreateTask([FromBody] TaskItemDto taskDto)
        {
            // No se necesita validar manualmente ModelState. Si dto no es válido, el middleware responderá con 400.
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            /*var task = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = taskDto.Title,
                Description = taskDto.Description,
                IsCompleted = taskDto.IsCompleted,
                CreatedAt = DateTime.UtcNow,
                DueDate = taskDto.DueDate
            };*/
            var task = _mapper.Map<TaskItem>(taskDto);

            _context.Tasks.Add(task);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(Guid id, [FromBody] TaskItemDto taskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingTask = _context.Tasks.Find(id);
            if (existingTask == null)
                return NotFound();

            existingTask.Title = taskDto.Title;
            existingTask.Description = taskDto.Description;
            existingTask.IsCompleted = taskDto.IsCompleted;

            _context.SaveChanges();

            return NoContent(); // 204
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(Guid id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
                return NotFound();

            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return NoContent(); // 204
        }
    }
}