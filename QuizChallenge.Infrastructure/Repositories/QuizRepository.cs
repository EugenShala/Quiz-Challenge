using QuizChallenge.Core.Entities;
using QuizChallenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeDemo.Core.IRepository;
using QuizChallenge.Core.Entities.QuizDtos;
using AutoMapper;

namespace QuizChallenge.Infrastructure.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public QuizRepository(ApplicationDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<QuizDto> CreateUpdateQuiz(QuizDto quizDto)
        {
            Quiz quiz = _mapper.Map<QuizDto, Quiz>(quizDto);
            if (quiz.QuizId > 0)
            {
                _dbContext.Quizzes.Update(quiz);
            }
            else
            {
                _dbContext.Quizzes.Add(quiz);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Quiz, QuizDto>(quiz);
        }

        public async Task<bool> DeleteQuiz(int quizId)
        {
            try
            {
                Quiz quiz = await _dbContext.Quizzes.FirstOrDefaultAsync(u => u.QuizId == quizId);
                if (quiz == null)
                {
                    return false;
                }
                _dbContext.Quizzes.Remove(quiz);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<QuizDto> GetQuizById(int quizId)
        {
            Quiz quiz = await _dbContext.Quizzes.Where(x => x.QuizId == quizId).FirstOrDefaultAsync();
            return _mapper.Map<QuizDto>(quiz);
        }

        public async Task<IEnumerable<QuizDto>> GetQuizes()
        {
            List<Quiz> quizList = await _dbContext.Quizzes.ToListAsync();
            return _mapper.Map<List<QuizDto>>(quizList);
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
