using QuizChallenge.Api.DataTransferObject.AnswerDtos;
using QuizChallenge.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeDemo.Api.Services.IRepository
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
