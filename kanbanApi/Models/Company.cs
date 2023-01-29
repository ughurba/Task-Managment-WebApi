using System.Collections.Generic;

namespace kanbanApi.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecretCode { get; set; }
        public List<AppUser> appUsers { get; set; }
        public List<Board> boards { get; set; }
    }
}
