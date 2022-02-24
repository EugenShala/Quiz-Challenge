using QuizChallenge.Core.Entities;
using QuizChallenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeDemo.Core.IRepository;
using QuizChallenge.Core.DataTransferObject.QuestionDtos;
using QuizChallenge.Core.DataTransferObject.AnswerDtos;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace QuizChallenge.Infrastructure.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper mapper;

        public QuestionRepository(ApplicationDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<Question> AddQuestion(Question question)
        {
            await _dbContext.AddAsync(question);
            await _dbContext.SaveChangesAsync();
            return question;

        }

        public async Task<Question> DeleteQuestion(int id)
        {
            var question = await GetQuestionById(id);
            _dbContext.Set<Question>().Remove(question);
            await _dbContext.SaveChangesAsync();
            return question;
        }

        public async Task<List<Question>> GetAllQuestions()
        {
            //return await _dbContext.Questions.Include(a => a.Answers).ProjectTo<Question>(mapper.ConfigurationProvider).ToListAsync();
            return await _dbContext.Questions.Include(a => a.Answers).ToListAsync();

        }

        public async Task<QuestionDetailsDto> GetQuestionDetails(int id)
        {
            return await _dbContext
             .Questions.Include(q => q.Answers)
             .ProjectTo<QuestionDetailsDto>(mapper.ConfigurationProvider)
             .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Question> GetQuestionById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await _dbContext.Set<Question>().FindAsync(id);
        }

        public async Task<bool> HasQuestion(int id)
        {
            var question = await GetQuestionById(id);
            return question != null;
        }

        public async Task<Question> UpdateQuestion(Question question)
        {
             _dbContext.Update(question);
            await _dbContext.SaveChangesAsync();
            return question;
        }
    }
}
