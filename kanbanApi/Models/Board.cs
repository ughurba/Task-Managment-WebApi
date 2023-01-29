using System.Collections.Generic;

namespace kanbanApi.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public List<Column>  columns{ get; set; } 
    }
}
