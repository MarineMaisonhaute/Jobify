using Jobify.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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
        public DbSet<Response> Response { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(e => e.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rating>()
                .HasOne(e => e.RaterUser)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Response>()
                .HasOne(e => e.Post)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Job>()
                .HasData(new Job
                {
                    JobId = 1,
                    Name = "AUCUN"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
