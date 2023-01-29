using kanbanApi.Models;
using System.Collections.Generic;

namespace kanbanApi.Dtos.BoardDtos
{
    public class CreateBoardDto
    {
        public string Title { get; set; }
        public int CompanyId { get; set; }

        public List<string> columns { get; set; }
    }
}
