using Microsoft.AspNetCore.Identity;

namespace kanbanApi.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public  int? CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
