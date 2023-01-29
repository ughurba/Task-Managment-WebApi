using kanbanApi.Data;
using kanbanApi.Dtos.ColumnDtos;
using kanbanApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace kanbanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColumnController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ColumnController(AppDbContext context)
        {

            _context = context;

        }


        [HttpGet("{id}")]
        public IActionResult GetlAll(int id)
        {

            IQueryable<GetColumnDto> query = _context.columns
                .Include(x => x.tasks)
                .Where(x=>x.BoardId == id)
                .Select(x => new GetColumnDto
            {
                Id = x.Id,
                Title = x.Title,
                tasks = x.tasks.Select(x => new Task
                {
                    Title = x.Title,
                    Id = x.Id,
                }).ToList()
            });
            var result = query.ToList();

            return Ok(result);
        }

        [HttpPost("create")]
        [Authorize]


        public IActionResult CreateColumn(CreateColumnDto createColumnDto)
        {

            bool existNameColumn = _context.boards.Any(c => c.Title == createColumnDto.Title);
            if (existNameColumn)
            {
                return BadRequest("Xəta baş verib:Eyni adlı Column artıq mövcuddur");
            }

            Column column = new Column
            {
                BoardId = createColumnDto.BoardId,
                Title = createColumnDto.Title,
            };

            _context.columns.Add(column);
            _context.SaveChanges();

            return StatusCode(200);
        }
    }
}
