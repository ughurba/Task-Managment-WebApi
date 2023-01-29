using System.Collections.Generic;

namespace kanbanApi.Models
{
    public class Column
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int BoardId { get; set; }
        public Board board { get; set; }

        public List<Task> tasks { get; set; }   
     }
}
