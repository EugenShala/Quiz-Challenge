using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizChallenge.Api.DataTransferObject;
using QuizChallenge.Api.DataTransferObject.QuizDtos;
using QuizChallenge.Api.Entities;
using QuizChallenge.Api.Services.IRepository;
using QuizChallenge.Api.Data;


namespace QuizChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IMapper  _mapper;
        protected ResponseDto responseDto;
        private readonly IQuizRepository _quizRepository;

        public QuizController(IMapper mapper, IQuizRepository quizRepository)
        {
            _mapper = mapper;
            this.responseDto = new ResponseDto();
            _quizRepository = quizRepository;   
        }

        #region Read Only Quiz
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadQuizDto>>> GetQuizs()
        {
            try
            {
                var quizModel = await _quizRepository.GetAllQuiz();
                var quizDto = _mapper.Map<IEnumerable<ReadQuizDto>>(quizModel);
                responseDto.Result = quizDto;
                return Ok(quizDto);
            }
            catch (Exception ex)
            {
                responseDto.Success = false;
                return StatusCode(500, responseDto.Error = new List<string>() { ex.ToString() });
            }
           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuizDetailsDto>> GetQuiz(int id)
        {
            try
            {
                var quiz = await _quizRepository.GetQuizDetails(id);

                if (quiz == null)
                {
                    return NotFound();
                }

                responseDto.Result = quiz;
                return Ok(quiz);
            }
            
            catch (Exception ex)
            {
                responseDto.Success=false;
                return StatusCode(500, responseDto.Error = new List<string>() { ex.ToString() });
            }
        }


        #endregion

        #region Create Quize

            [HttpPost]
        public async Task<ActionResult<CreateQuizDto>> PostQuiz(CreateQuizDto quizDto)
        {
            try
            {
                var quiz = _mapper.Map<Quiz>(quizDto);
                await _quizRepository.AddQuiz(quiz);
                responseDto.Result = quizDto;

                return CreatedAtAction("GetQuizs", new { id = quiz.Id }, quiz);
            } 
            catch (Exception ex)
            {
                return StatusCode(500, responseDto.Error = new List<string>() { ex.ToString() });
            }
        
            
        }

        #endregion

        #region Update Quiz

        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuiz(int id, UpdateQuizDto quizDto)
        {

            try
            {
                if (id != quizDto.Id)
                {
                    return BadRequest();
                }

                var quiz = await _quizRepository.GetQuizById(id);

                if (quiz == null)
                {
                    return NotFound();
                }

                _mapper.Map(quizDto, quiz);
                await _quizRepository.UpdateQuiz(quiz);
                responseDto.Result = quizDto;

            }
            catch (Exception ex)
            {
                if (!await QuizExists(id))
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

        #region Delete Quiz

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz(int id)
        {
            try
            {
                var quiz = await _quizRepository.GetQuizById(id);
                if (quiz == null)
                {
                    return NotFound();
                }

                await _quizRepository.DeleteQuiz(id);
                responseDto.Result = quiz;
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, responseDto.Error = new List<string>() { ex.ToString() });
            }
         }

        #endregion

        private async Task<bool> QuizExists(int id)
        {
            return await _quizRepository.HasQuiz(id);
        }

    }
}
