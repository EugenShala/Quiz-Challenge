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
        Task<QuestionDetailsDto> GetQuestionById(int? id);
        Task<List<ReadQuestionDto>> GetAllQuestions();
        Task<CreateQuestionDto> AddQuestion(CreateQuestionDto question);
        Task<UpdateQuestionDto> UpdateQuestion(UpdateQuestionDto question);
        Task<DeleteQuestionDto> DeleteQuestion(int id);
        Task<bool> HasQuestion(int id);
        Task<QuestionDetailsDto> GetQuestionDetails(int id);
    }
}
