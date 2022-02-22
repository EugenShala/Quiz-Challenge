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

        public async Task<CreateQuestionDto> AddQuestion(CreateQuestionDto question)
        {
            var questions = mapper.Map<Question>(question);
            await _dbContext.AddAsync(questions);
            await _dbContext.SaveChangesAsync();
            return question;
            
        }

        public async Task<DeleteQuestionDto> DeleteQuestion(int id)
        {
            var question = await DeleteQuestion(id);
            _dbContext.Set<DeleteQuestionDto>().Remove(question);
            await _dbContext.SaveChangesAsync();
            return question;
        }

        public async Task<List<ReadQuestionDto>> GetAllQuestions()
        {
            return await _dbContext.Questions.Include(a => a.Answers).ProjectTo<ReadQuestionDto>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<QuestionDetailsDto> GetQuestionDetails(int id)
        {
            return await _dbContext
             .Questions.Include(q => q.Answers)
             .ProjectTo<QuestionDetailsDto>(mapper.ConfigurationProvider)
             .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<QuestionDetailsDto> GetQuestionById(int? id)
        {
            var question = await _dbContext.Questions.FindAsync(id);
            return mapper.Map<QuestionDetailsDto>(question);
        }

        public async Task<bool> HasQuestion(int id)
        {
            var question = await GetQuestionById(id);
            return question != null;
        }

        public async Task<UpdateQuestionDto> UpdateQuestion(UpdateQuestionDto question)
        {
            var questions = mapper.Map<Question>(question);
            _dbContext.Entry(questions).State = EntityState.Detached;
            //_dbContext.Entry(questions).State = EntityState.Modified;
             _dbContext.Questions.Update(questions);
            await _dbContext.SaveChangesAsync();
            return question;
        }
    }
}
