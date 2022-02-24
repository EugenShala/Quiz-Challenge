using AutoMapper;
using ChallengeDemo.Core.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizChallenge.Core.DataTransferObject;
using QuizChallenge.Core.DataTransferObject.QuestionDtos;
using QuizChallenge.Core.Entities;

namespace QuizChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        protected ResponseDto responseDto;

        public QuestionController(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            this._mapper = mapper;
            responseDto = new ResponseDto();
        }

        #region Read Only Questions


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadQuestionDto>>> GetQuestions()
        {
            try
            {
                var questionModel = await _questionRepository.GetAllQuestions();
                var questionDto = _mapper.Map<IEnumerable<ReadQuestionDto>>(questionModel);
                responseDto.Result = questionDto;
                return Ok(questionDto);
            }
            catch (Exception ex)
            {
                responseDto.Success = false;
                return StatusCode(500, responseDto.Error = new List<string>() { ex.ToString() });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionDetailsDto>> GetQuestionDetails(int id)
        {
            try
            {
                var quiz = await _questionRepository.GetQuestionDetails(id);

                if (quiz == null)
                {
                    return NotFound();
                }

                responseDto.Result = quiz;
                return Ok(quiz);
            }

            catch (Exception ex)
            {
                responseDto.Success = false;
                return StatusCode(500, responseDto.Error = new List<string>() { ex.ToString() });
            }
        }


        #endregion


        #region Create Question

        [HttpPost]
        public async Task<ActionResult<CreateQuestionDto>> PostQuestion(CreateQuestionDto questionDto)
        {
            try
            {
                var quiz = _mapper.Map<Question>(questionDto);
                await _questionRepository.AddQuestion(quiz);
                responseDto.Result = questionDto;

                return CreatedAtAction("GetQuestions", new { id = questionDto }, questionDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, responseDto.Error = new List<string>() { ex.ToString() });
            }
        }

        #endregion


        #region Update Question

        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, UpdateQuestionDto questionDto)
        {
            try

            {

                if (id != questionDto.Id)
                {
                    return BadRequest();
                }

                var question = await _questionRepository.GetQuestionById(id);
                if (question == null)
                {
                    return NotFound();
                }

                _mapper.Map(questionDto, question);
                await _questionRepository.UpdateQuestion(question);
                responseDto.Result = questionDto;

            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await HasQuestion(id))
                {
                    return NotFound();
                }
                else
                {
                    responseDto.Success = false;
                    return StatusCode(500, responseDto.Error = new List<string>() { ex.ToString() });
                } 
            }
            return NoContent();
        }

        #endregion

        #region Remove Question


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            try
            {
                var question = await _questionRepository.GetQuestionById(id);
                if (question == null)
                {
                    return NotFound();
                }

                await _questionRepository.DeleteQuestion(id);

                responseDto.Result = question;
                return Ok(question);
            }
            catch (Exception ex)
            {
                responseDto.Success = false;
                return StatusCode(500, responseDto.Error = new List<string>() { ex.ToString() });
            }
        }

        #endregion
        private async Task<bool> HasQuestion(int id)
        {
            return await _questionRepository.HasQuestion(id);
        }
    }
}
