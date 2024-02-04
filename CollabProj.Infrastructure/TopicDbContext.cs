using CollabProj.Domain.Entities.Content;
using CollabProj.Domain.Entities.Content.Statistics;
using Microsoft.EntityFrameworkCore;

namespace CollabProj.Infrastructure
{
    public class TopicDbContext : DbContext
    {
        public TopicDbContext(DbContextOptions<TopicDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // If needed we seed database with test data to make it easier work with data
            // We use extention method for that
            modelBuilder.Seed();
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
    public static class ModelBuilderExtensions
    { 
        public static void Seed(this ModelBuilder modelBuilder) 
        {
            var library = new TopicLibrary()
            {
                Author = new FakeUser(),
                Id = 1,
                Title = "Sample topic library",
                Statistics = new ContentStatistics()
                {
                    Id = 1,  Likes = 50,  Views = 130,  CreationDate = DateTime.Now, LastViewDate = DateTime.Now,
                }
            };
            var topics = new List<Topic>()
            {
                new Topic()
                {
                    Id = 1,
                    Title = "Programming Basics",
                    TopicLibrary = library,
                    Statistics = new ContentStatistics()
                    {
                        Id = 2, Likes = 50, Views = 123, CreationDate = DateTime.Now, LastViewDate = DateTime.Now,
                    },
                    TopicContent = new List<ContentPiece>()
                    {
                        new ContentPiece()
                        {
                            Id = 1, InnerText = "Introduction to Programming", Type = ContentPieceType.Header
                        },
                        new ContentPiece()
                        {
                            Id = 2, InnerText = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nobis ipsum nam eligendi. Labore magnam, dolorum, quos suscipit obcaecati officiis nihil vero ea commodi ut omnis? Eum, minima? Minus, facere sed?", Type = ContentPieceType.Text
                        },
                        new ContentPiece()
                        {
                            Id = 3, InnerText = "Functions and Closures", Type = ContentPieceType.Text
                        }
                    }
                },
                new Topic()
                {
                    Id = 2,
                    Title = "Advanced Programming Concepts",
                    TopicLibrary = library,
                    Statistics = new ContentStatistics()
                    {
                        Id = 3, CreationDate= DateTime.Now, LastViewDate= DateTime.Now, Likes = 32, Views = 135
                    },
                    TopicContent = new List<ContentPiece>()
                    {
                        new ContentPiece()
                        {
                            Id = 4, InnerText = "Object-Oriented Programming (OOP)", Type = ContentPieceType.Header
                        },
                        new ContentPiece()
                        {
                            Id = 5, InnerText = "Design Patterns", Type = ContentPieceType.Header
                        },
                        new ContentPiece()
                        {
                            Id = 6, InnerText = "console.log(\"Hello world!\")", Type = ContentPieceType.Code
                        },
                    }
                } 
            };

            var statistics = new List<ContentStatistics>
            {
                library.Statistics
            };

            foreach (var topic in topics)
            {
                topic.TopicContent.ForEach(content => content.Topic = topic);
                statistics.Add(topic.Statistics);
            }
            library.Topics = topics;

            var contentPieces = topics[0].TopicContent;

            for (int i = 1; i < topics.Count; i++) 
            {
                contentPieces.AddRange(topics[i].TopicContent);
            }

            modelBuilder.Entity<TopicLibrary>().HasData(library);
            modelBuilder.Entity<Topic>().HasData(topics);
            modelBuilder.Entity<ContentPiece>().HasData(contentPieces);
            modelBuilder.Entity<ContentStatistics>().HasData(statistics);
        }
    }

}
