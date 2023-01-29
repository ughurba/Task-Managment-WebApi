using kanbanApi.Models;
using System.Collections.Generic;

namespace kanbanApi.Dtos.ColumnDtos
{
    public class GetColumnDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Task> tasks{ get; set; } 
    }
}
