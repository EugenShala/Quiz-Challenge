using QuizChallenge.Core.DataTransferObject.AnswerDtos;
using QuizChallenge.Core.DataTransferObject.QuestionDtos;
using QuizChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeDemo.Core.IRepository
{
    public interface IQuestionRepository 
    {
        Task<Question> GetQuestionById(int? id);
        Task<List<Question>> GetAllQuestions();
        Task<Question> AddQuestion(Question question);
        Task<Question> UpdateQuestion(Question question);
        Task<Question> DeleteQuestion(int id);
        Task<bool> HasQuestion(int id);
        Task<QuestionDetailsDto> GetQuestionDetails(int id);
    }
}
