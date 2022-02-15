using Microsoft.EntityFrameworkCore;
using QuizChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Quiz>().HasData(new Quiz
            {
                QuizId = 3,
                Title = "Iphone",
               
            });
            modelBuilder.Entity<Quiz>().HasData(new Quiz
            {
                QuizId = 4,
                Title = "Samsung",
            });

        }
    }
}
