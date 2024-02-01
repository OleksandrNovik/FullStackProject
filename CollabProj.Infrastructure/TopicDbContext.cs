using Microsoft.EntityFrameworkCore;

namespace CollabProj.Infrastructure
{
    public class TopicDbContext : DbContext
    {
        public TopicDbContext(DbContextOptions<TopicDbContext> options) : base(options)
        {
            if (Database.EnsureCreated())
            {
                //TODO: Add db seeding 
                Console.WriteLine("Hello world");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: implement OnModelCreation if needed
            base.OnModelCreating(modelBuilder);
        }
    }
}
