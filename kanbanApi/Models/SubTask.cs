namespace kanbanApi.Models
{
    public class SubTask
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public int TaskId { get; set; }
        public Task task { get; set; }
    }
}
