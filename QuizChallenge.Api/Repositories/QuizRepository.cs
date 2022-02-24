using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using QuizChallenge.Api.DataTransferObject.QuizDtos;
using QuizChallenge.Api.Entities;
using QuizChallenge.Api.IRepository;
using QuizChallenge.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Api.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper mapper;
        public QuizRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<Quiz> AddQuiz(Quiz quiz)
        {
            await _dbContext.AddAsync(quiz);
            await _dbContext.SaveChangesAsync();
            return quiz;
        }

        public async Task<Quiz> DeleteQuiz(int id)
        {
            var quiz = await GetQuizById(id);
            _dbContext.Set<Quiz>().Remove(quiz);
            await _dbContext.SaveChangesAsync();
            return quiz;
        }

        public async Task<List<Quiz>> GetAllQuiz()
        {
            return await _dbContext.Set<Quiz>().ToListAsync();
        }

        public async Task<Quiz> GetQuizById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await _dbContext.Set<Quiz>().FindAsync(id);
        }

        public async Task<QuizDetailsDto> GetQuizDetails(int id)
        {
            return await _dbContext
                .Quizzes.Include(q => q.Questions)
                .ProjectTo<QuizDetailsDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

        }

        public async Task<bool> HasQuiz(int id)
        {
            var quiz = await GetQuizById(id);
            return quiz != null;    
        }

        public async Task<Quiz> UpdateQuiz(Quiz quiz)
        {
            _dbContext.Update(quiz);
            await _dbContext.SaveChangesAsync();
            return quiz;
        }
    }
}
