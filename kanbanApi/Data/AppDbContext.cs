using kanbanApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace kanbanApi.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
        public DbSet<Board> boards { get; set; }
        public DbSet<Column> columns { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Task> tasks { get; set; }
        public DbSet<SubTask> subTasks { get; set; }

    }
}
