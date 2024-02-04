using CollabProj.Domain.Entities.Content;
using CollabProj.Domain.Entities.Content.Statistics;
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

        /// <summary>
        /// Database set of topic libraries
        /// </summary>
        public DbSet<TopicLibrary> TopicLibraries { get; set; }

        /// <summary>
        /// Database set of topics
        /// </summary>
        public DbSet<Topic> Topics { get; set; }

        /// <summary>
        /// Database set for content statistics
        /// </summary>
        public DbSet<ContentStatistics> ContentStatistics { get; set; }

        /// <summary>
        /// Database set for content pieces in topics
        /// </summary>
        public DbSet<ContentPiece> ContentPieces { get; set; }
    }
}
