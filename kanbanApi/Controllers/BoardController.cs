using kanbanApi.Data;
using kanbanApi.Dtos.BoardDtos;
using kanbanApi.Dtos.ColumnDtos;
using kanbanApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kanbanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public BoardController(UserManager<AppUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;

        }

        [HttpGet]

        public async Task<IActionResult> GetAll(string secretCode)
        {
            Company company = new Company();
            AppUser user = new AppUser();
            if (secretCode == null)
            {
                string UserToken = HttpContext.Request.Headers["Authorization"].ToString();
                var userId = Helper.Helper.DecodeToken(UserToken);
                 user = await _userManager.FindByIdAsync(userId);
            }
            else
            {
                company = _context.companies.FirstOrDefault(x => x.SecretCode == secretCode);
            }
            

            List<Board> boards = _context.boards
                .Where(x => (user.CompanyId != null ? x.CompanyId == user.CompanyId : x.CompanyId == company.Id) )
                .ToList();
           
            return Ok(boards);
        }

       


        [HttpPost("create")]
        [Authorize]


        public async Task<IActionResult> CreateBoard(CreateBoardDto createBoardDto)
        {
            string UserToken = HttpContext.Request.Headers["Authorization"].ToString();
            var userId = Helper.Helper.DecodeToken(UserToken);
            AppUser user = await _userManager.FindByIdAsync(userId);
            bool existNameBoard = _context.boards.Any(c => c.Title == createBoardDto.Title);
            if (existNameBoard)
            {
                return BadRequest("Xəta baş verib:Eyni adlı kateqoriya artıq mövcuddur");
            }

            Board board = new Board
            {
                Title = createBoardDto.Title,
                CompanyId = user.CompanyId,
            };

            if (createBoardDto.columns.Count != 0)
            {
                board.columns = new List<Column>();
                for (int i = 0; i < createBoardDto.columns.Count; i++)
                {
                    Column column = new Column();

                    column.Title = createBoardDto.columns[i];
                    board.columns.Add(column);
                }

            }
            _context.boards.Add(board);
            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete("removeBoard/{boardId}")]

        public async Task<IActionResult> RemoveBoard(int boardId)
        {
            Board board = _context.boards.FirstOrDefault(b => b.Id == boardId);


            _context.boards.Remove(board);
            _context.SaveChanges();

            return Ok();
        }
    }
}
