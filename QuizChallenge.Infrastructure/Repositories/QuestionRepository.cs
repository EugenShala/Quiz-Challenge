using QuizChallenge.Core.Entities;
using QuizChallenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeDemo.Core.IRepository;

namespace QuizChallenge.Infrastructure.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public QuestionRepository(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<Question> AddQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public Task<Question> DeleteQuestion(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Question>> GetAllQuestions()
        {
            throw new NotImplementedException();
        }

        public Task<Question> GetQuestionById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasQuestion(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Question> UpdateQuestion(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
