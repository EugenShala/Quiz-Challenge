using QuizChallenge.Core.DataTransferObject.QuizDtos;
using QuizChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Core.IRepository
{
    public interface IQuizRepository
    {
        Task<Quiz> GetQuizById (int? id);
        Task<List<Quiz>> GetAllQuiz();
        Task <Quiz> AddQuiz(Quiz quiz); 
        Task<Quiz> UpdateQuiz(Quiz quiz);
        Task<Quiz> DeleteQuiz(int id);
        Task<bool> HasQuiz(int id);
        Task<QuizDetailsDto> GetQuizDetails(int id);    
    }
}
