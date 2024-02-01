using CollabProj.Domain.Entities.User;
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
            //Binding User and UserPhoto using modelBuilder
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserPhoto)
                .WithOne(up => up.User)
                .HasForeignKey<UserPhoto>(up => up.ID);

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
        DbSet<User> Users { get; set; }

        /// <summary>
        /// Database Set of User Photos
        /// </summary>
        DbSet<UserPhoto> UserPhotos { get; set; }
    }
}
