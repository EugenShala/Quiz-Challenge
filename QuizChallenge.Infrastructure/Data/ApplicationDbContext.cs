using Microsoft.EntityFrameworkCore;
using QuizChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Infrastructure.Data
{
    public  class ApplicationDbContext : DbContext
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

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(50);

            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.CorrectAnswerId);

                entity.Property(e => e.Text).HasMaxLength(50);

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK_Questions_ToTable");
            });


            modelBuilder.Entity<Quiz>().HasData(new[]
            {
            new Quiz
             {
                Id = 3,
                Title = "Iphone"
             },
            new Quiz
            {
                 Id = 4,
                Title = "Samsung"
            }
           });
             
        modelBuilder.Entity<Question>().HasData(new[]
            {
               new Question
               {
                  Id = 1,
                  Text = "System",
                   CorrectAnswerId = 1
               },
               new Question
               {
                  Id = 2,
                  Text = "Work",
                   CorrectAnswerId = 2
               }
            });

        }


    }
}

