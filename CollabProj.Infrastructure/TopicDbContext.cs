using CollabProj.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using CollabProj.Domain.Entities.Content;
using CollabProj.Domain.Entities.Content.Statistics;

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
            // If needed we seed database with test data to make it easier work with data
            // We use extension method for that
            modelBuilder.Seed();
            //Binding User and UserPhoto using modelBuilder
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserPhoto)
                .WithOne(up => up.User)
                .HasForeignKey<UserPhoto>(up => up.Id);

            //Implementation of password hashing
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasConversion(
                    password => BCrypt.Net.BCrypt.HashPassword(password),
                    hashedPassword => hashedPassword
                );

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Database Set of Users
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Database Set of User Photos
        /// </summary>
        public DbSet<UserPhoto> UserPhotos { get; set; }
        
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
                //TODO: get this fake user out of here
                Author = new User(),
                Id = 1,
                Title = "Sample topic library",
                Statistics = new ContentStatistics()
                {
                    Id = 1,  CreationDate = DateTime.Now, LastViewDate = DateTime.Now, 
                    Liked = new List<User>(), Viewed = new List<User>()
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
                        Id = 2, CreationDate = DateTime.Now, LastViewDate = DateTime.Now,
                        Liked = new List<User>(), Viewed = new List<User>()
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
                        Id = 3, CreationDate= DateTime.Now, LastViewDate= DateTime.Now,
                        Liked = new List<User>(), Viewed = new List<User>()
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
                foreach(var content in topic.TopicContent)
                {
                    content.Topic = topic;
                }
                statistics.Add(topic.Statistics);
            }
            library.Topics = topics;

            var contentPieces = topics[0].TopicContent.ToList();

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
