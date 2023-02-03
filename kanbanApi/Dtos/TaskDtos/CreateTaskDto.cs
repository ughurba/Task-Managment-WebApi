using System.Collections.Generic;

namespace kanbanApi.Dtos.TaskDtos
{
    public class CreateTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> subTasks{ get; set; }
        public int columnId { get; set; }

    }
}
