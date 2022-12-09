using Jobify.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jobify.DBContext
{
    public class JobifyDBContext : IdentityDbContext<User, Role, Guid>
    {
        public JobifyDBContext(DbContextOptions<JobifyDBContext> options): base(options)
        {

        }
        public DbSet<Job> Job { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet <Response> Response { get; set; } 
    }
}
