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
    public class QuizRepository : GenericRepository<Quiz>, IQuizRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public QuizRepository(ApplicationDbContext dbContext) : base (dbContext)
        {
            _dbContext = dbContext;
        }
        //public async Task<bool> CreateQuiz(Quiz createQuiz)
        //{
        //   await _dbContext.AddAsync(createQuiz);
        //   await Save();
        //    return true;
        //}
        //public async Task<bool> DeleteQuiz(int quizId)
        //{
        //    try
        //    {
        //        Quiz quiz = await _dbContext.Quizzes.FirstOrDefaultAsync(q => q.Id == quizId);
        //        if (quiz == null)
        //        {
        //            return false;
        //        }
        //        _dbContext.Quizzes.Remove(quiz);
        //        await Save();
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //       // throw;
        //    }
        //}
        //public async Task<Quiz> GetQuiz(int quizId)
        //{
        //    return await _dbContext.Quizzes.Include(q => q.Id == quizId).FirstOrDefaultAsync(q => q.Id == quizId);
        //}

        //public async Task<ICollection<Quiz>> GetQuizes()
        //{
        //    return await _dbContext.Quizzes.OrderBy(q => q.Title).ToListAsync();
        //}
        //public async Task<bool> QuizExists(string quizName)
        //{
        //    bool value = await _dbContext.Quizzes.AnyAsync(q => q.Title.ToLower().Trim() == quizName.ToLower().Trim());
        //    return value;
        //}

        //public async Task<bool> QuizExists(int quizId)
        //{
        //    return await _dbContext.Quizzes.AnyAsync(q => q.Id == quizId);
        //}

        //public async Task<bool> Save()
        //{
        //    return await _dbContext.SaveChangesAsync() >= 0 ? true : false ;
        //}

        //public async Task<bool> UpdateQuiz(Quiz updateQuiz)
        //{
        //     _dbContext.Quizzes.Update(updateQuiz);
        //    return await Save();
        //}
    }
}
