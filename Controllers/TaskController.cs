using Microsoft.AspNetCore.Mvc;
using dotNET_Api.Context;
using dotNET_Api.Models;

namespace dotNET_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly OrganizerContext _context;

        public TaskController(OrganizerContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            var tasks = _context.Tasks.ToList();

            if (tasks == null)
                return NotFound();

            return Ok(tasks);
        }

        [HttpGet("FindByTitle")]
        public IActionResult FindByTitle(string title)
        {
            var tasks = _context.Tasks.Where(x => x.Title.Contains(title));

            if (tasks == null)
                return NotFound();

            return Ok(tasks);
        }

        [HttpGet("FindByDate")]
        public IActionResult FindByDate(DateTime date)
        {
            var task = _context.Tasks.Where(x => x.Date.Date == date.Date);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpGet("FindByStatus")]
        public IActionResult FindByStatus(EnumTaskStatus status)
        {
            var tasks = _context.Tasks.Where(x => x.Status == status);

            if (tasks == null)
                return NotFound();

            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult Create(TaskSchedule task)
        {
            if (task.Date == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            _context.Add(task);
            _context.SaveChanges();

            return CreatedAtAction(nameof(FindById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public  IActionResult Update(int id, TaskSchedule task)
        {
            var taskDb = _context.Tasks.Find(id);

            if (taskDb == null)
                return NotFound();

            if (task.Date == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            taskDb.Title = task.Title;
            taskDb.Description = task.Description;
            taskDb.Date = task.Date;
            taskDb.Status = task.Status;

            _context.Update(taskDb);
            _context.SaveChanges();

            return Ok(taskDb);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var taskDb = _context.Tasks.Find(id);

            if (taskDb == null)
                return NotFound();

            _context.Tasks.Remove(taskDb);
            _context.SaveChanges();

            return NoContent();
        }
    }
}