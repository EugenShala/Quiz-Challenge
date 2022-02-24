using QuizChallenge.Api.Entities;
using QuizChallenge.Api.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeDemo.Api.Services.IRepository;
using QuizChallenge.Api.DataTransferObject.AnswerDtos;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace QuizChallenge.Api.Services.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper mapper;

        public AnswerRepository(ApplicationDbContext dbContext, IMapper mapper) 
        {
           _dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<Answer> AddAnswer(Answer answer)
        {
            await _dbContext.AddAsync(answer);
            await _dbContext.SaveChangesAsync();
            return answer;
        }

        public async Task<Answer> DeleteAnswer(int id)
        {
            var answer = await GetAnswerById(id);
            _dbContext.Set<Answer>().Remove(answer);
            await _dbContext.SaveChangesAsync();
            return answer;
        }

        public async Task<List<Answer>> GetAllAnswers()
        {
            return await _dbContext.Answers.Include(a => a.Question).ToListAsync();
        }

        public async Task<Answer> GetAnswerById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await _dbContext.Set<Answer>().FindAsync(id);
        }

        public async Task<AnswerDetailsDto> GetAnswerDetails(int id)
        {
            return await _dbContext
              .Answers.Include(q => q.Question)
              .ProjectTo<AnswerDetailsDto>(mapper.ConfigurationProvider)
              .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<bool> HasAnswer(int id)
        {
            var answer = await GetAnswerById(id);
            return answer != null;
        }

        public async Task<Answer> UpdateAnswer(Answer answer)
        {
            _dbContext.Update(answer);
            await _dbContext.SaveChangesAsync();
            return answer;
        }
    }
}
