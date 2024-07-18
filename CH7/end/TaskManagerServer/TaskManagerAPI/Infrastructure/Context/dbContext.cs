using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Domain.Models;

namespace TaskManagerAPI.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserTask> UserTasks { get; set; }

        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Tasks");
        }
    }
}
