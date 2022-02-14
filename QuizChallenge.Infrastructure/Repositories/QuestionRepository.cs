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
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public QuestionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        //public async Task<bool> CreateQuestion(Question createQuestion)
        //{
        //   await _dbContext.AddAsync(createQuestion);
        //   await Save();
        //    return true;
        //}

        //public async Task<bool> DeleteQuestion(int questionId)
        //{
        //    try
        //    {
        //        Question question = await _dbContext.Questions.FirstOrDefaultAsync(q => q.Id == questionId);
        //        if (question == null)
        //        {
        //            return false;
        //        }
        //        _dbContext.Questions.Remove(question);
        //        await Save();
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //       // throw;
        //    }
        //}

        //public async Task<Question> GetQuestion(int questionId)
        //{
        //    return await _dbContext.Questions.Include(q => q.Quiz).FirstOrDefaultAsync(a => a.Id == questionId);

        //}

        //public async Task<ICollection<Question>> GetQuestions()
        //{
        //    return await _dbContext.Questions.Include(q => q.Quiz).ToListAsync();

        //}

        //public async Task<bool> QuestionExists(string questionName)
        //{
        //    bool value = await _dbContext.Questions.AnyAsync(q => q.Text.ToLower().Trim() ==  questionName.ToLower().Trim());
        //    return value;
        //}

        //public async Task<bool> QuestionExists(int questionId)
        //{
        //    return await _dbContext.Questions.AnyAsync(q => q.Id == questionId);
        //}

        //public async Task<bool> Save()
        //{
        //    return await _dbContext.SaveChangesAsync() >= 0 ? true : false ;
        //}

        //public async Task<bool> UpdateQuestion(Question updateQuestion)
        //{
        //     _dbContext.Questions.Update(updateQuestion);
        //    return await Save();
        //}
    }
}
