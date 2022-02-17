using AutoMapper;
using ChallengeDemo.Core.IRepository;
using Microsoft.AspNetCore.Mvc;
using QuizChallenge.Core.DataTransferObject;
using QuizChallenge.Core.Entities;
using QuizChallenge.Core.Entities.QuizDtos;

namespace QuizChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizsController : ControllerBase
    {
        private readonly IQuizRepository _quiz;
        protected ResponseDto _response;
        public QuizsController(IQuizRepository quiz)
        {
            _quiz = quiz;
            this._response = new ResponseDto();
        }


        [HttpGet]
        public async Task<object> GetQuiz()
        {
            try
            {
                IEnumerable<QuizDto> quizzes = await _quiz.GetQuizes();
                _response.Result = quizzes;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Error = new List<string>() { ex.ToString() };
            }
           return  _response;
        }

        [HttpGet("{id}")]
        public async Task<object> GetQuiz(int id)
        {
            try
            {
                QuizDto quizDto = await _quiz.GetQuizById(id);
                _response.Result = quizDto;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Error
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST api/<QuizController>
        [HttpPost]
        public async Task<object> Post([FromBody] QuizDto quizDto)
        {
            try
            {
                QuizDto model = await _quiz.CreateUpdateQuiz(quizDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Error
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{id}")]
        public async Task<object> Put(int id, [FromBody] QuizDto quizDto)
        {
            try
            {
                QuizDto model = await _quiz.CreateUpdateQuiz(quizDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Error
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _quiz.DeleteQuiz(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Error
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
