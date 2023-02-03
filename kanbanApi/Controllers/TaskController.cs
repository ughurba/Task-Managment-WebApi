using kanbanApi.Data;
using kanbanApi.Dtos.TaskDtos;
using kanbanApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace kanbanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TaskController(AppDbContext context)
        {

            _context = context;

        }

        [HttpPost("createTask")]
        [Authorize]
        public IActionResult CreateTask(CreateTaskDto createTaskDto)
        {

            bool existNameTask = _context.tasks.Any(c => c.Title == createTaskDto.Title);
            if (existNameTask)
            {
                return BadRequest("Xəta baş verib:Eyni adlı Task artıq mövcuddur");
            }

            Task task = new Task
            {
                Title = createTaskDto.Title,
                Description = createTaskDto.Description,
                ColumnId = createTaskDto.columnId,

            };

            if (createTaskDto.subTasks.Count != 0)
            {
                task.subTasks = new List<SubTask>();
                for (int i = 0; i < createTaskDto.subTasks.Count; i++)
                {
                    SubTask subTask = new SubTask();

                    subTask.Name = createTaskDto.subTasks[i];
                    subTask.Completed = false;
                    task.subTasks.Add(subTask);
                }

            }
            _context.tasks.Add(task);
            _context.SaveChanges();

            return StatusCode(200);
        }
    }
}
