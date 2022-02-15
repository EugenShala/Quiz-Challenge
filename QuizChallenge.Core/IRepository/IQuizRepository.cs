using QuizChallenge.Core.Entities;
using QuizChallenge.Core.Entities.QuizDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeDemo.Core.IRepository
{
    public interface IQuizRepository 
    {
        //Task<ICollection<Quiz>> GetQuizes();
        //Task<Quiz> GetQuiz(int quizId);
        //Task<bool> QuizExists(string quizName);
        //Task<bool> QuizExists(int quizId);
        //Task<bool> CreateQuiz(Quiz createQuiz);
        //Task<bool> UpdateQuiz(Quiz updateQuiz);
        //Task<bool> DeleteQuiz(int quizId);
        //Task<bool> Save();

        Task<IEnumerable<QuizDto>> GetQuizes();
        Task<QuizDto> GetQuizById(int quizId);
        Task<QuizDto> CreateUpdateQuiz(QuizDto quizDto);
        Task<bool> DeleteQuiz(int quizId);
    }
}
