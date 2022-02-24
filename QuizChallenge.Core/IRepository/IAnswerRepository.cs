using QuizChallenge.Core.DataTransferObject.AnswerDtos;
using QuizChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeDemo.Core.IRepository
{
    public interface IAnswerRepository 
    {
        Task<Answer> GetAnswerById(int? id);
        Task<List<Answer>> GetAllAnswers();
        Task<Answer> AddAnswer(Answer answer);
        Task<Answer> UpdateAnswer(Answer answer);
        Task<Answer> DeleteAnswer(int id);
        Task<bool> HasAnswer(int id);
        Task<AnswerDetailsDto> GetAnswerDetails(int id);
    }
}
