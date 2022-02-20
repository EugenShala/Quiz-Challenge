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
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AnswerRepository(ApplicationDbContext dbContext) 
        {
           _dbContext = dbContext;
        }
        //public async Task<bool> CreateAnswer(Answer createAnswer)
        //{
        //    await _dbContext.AddAsync(createAnswer);
        //    await Save();
        //    return true;
        //}

        //public async Task<bool> DeleteAnswer(int answerId)
        //{
        //    try
        //    {
        //        Answer answer = await _dbContext.Answers.FirstOrDefaultAsync(q => q.Id == answerId);
        //        if (answer == null)
        //        {
        //            return false;
        //        }
        //        _dbContext.Answers.Remove(answer);
        //        await Save();
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //        // throw;
        //    }
        //}

        //public async Task<Answer> GetAnswer(int answerId)
        //{
        //    return await _dbContext.Answers.FirstOrDefaultAsync(q => q.Id == answerId);
        //}

        //public async Task<ICollection<Answer>> GetAnswers()
        //{
        //    return await _dbContext.Answers.OrderBy(q => q.Text).ToListAsync();
        //}

        //public async Task<bool> AnswerExists(string answerName)
        //{
        //    bool value = await _dbContext.Answers.AnyAsync(q => q.Text.ToLower().Trim() == answerName.ToLower().Trim());
        //    return value;
        //}

        //public async Task<bool> AnswerExists(int answerId)
        //{
        //    return await _dbContext.Answers.AnyAsync(q => q.Id == answerId);
        //}

        //public async Task<bool> Save()
        //{
        //    return await _dbContext.SaveChangesAsync() >= 0 ? true : false;
        //}

        //public async Task<bool> UpdateAnswer(Answer updateAnswer)
        //{
        //    _dbContext.Answers.Update(updateAnswer);
        //    return await Save();
        //}    
    }
}
