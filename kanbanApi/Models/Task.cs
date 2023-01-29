using System.Collections.Generic;

namespace kanbanApi.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ColumnId { get; set; }

        public Column column { get; set; }
        public List<SubTask> subTasks { get; set; }
    }
}
