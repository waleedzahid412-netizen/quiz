using Microsoft.EntityFrameworkCore;
using quiz.Models.Entities;

namespace quiz.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet <Quiz> StudentQuizzes { get; set; }
        public DbSet <Students> student { get; set; }
    }
}
