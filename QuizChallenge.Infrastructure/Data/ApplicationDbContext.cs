using Microsoft.EntityFrameworkCore;
using QuizChallenge.Core.DataTransferObject.QuestionDtos;
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


        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Quiz> Quizzes { get; set; }


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
                Id = 1,
                Title = "Iphone"
             },
            new Quiz
            {
                 Id = 2,
                Title = "Samsung"
            }
           });
             
        modelBuilder.Entity<Question>().HasData(new[]
            {
               new Question
               {
                  Id = 1,
                  Text = "System",
                   CorrectAnswerId = 1,
                   QuizId = 2,
               },
               new Question
               {
                  Id = 2,
                  Text = "Work",
                   CorrectAnswerId = 2,
                   QuizId = 1,
               }
            });

        }


    }
}

