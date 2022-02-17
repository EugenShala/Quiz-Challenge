using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizChallenge.Core.DataTransferObject.QuizDtos;
using QuizChallenge.Core.Entities;
using QuizChallenge.Infrastructure.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper  _mapper;

        public QuizController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #region Read Only Quiz
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadQuizDto>>> GetQuizs()
        {
            var quizModel = await _dbContext.Quizzes.ToListAsync();
            var quizDto = _mapper.Map<IEnumerable<ReadQuizDto>>(quizModel);
            return Ok(quizDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadQuizDto>> GetQuizs(int id)
        {
            var quiz = await _dbContext.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            var quizDto = _mapper.Map<ReadQuizDto>(quiz);
            return quizDto;
        }

        #endregion

        #region Create Quize
      
        [HttpPost]
        public async Task<ActionResult<CreateQuizDto>> PostQuiz(CreateQuizDto quizDto)
        {
           var quiz = _mapper.Map<Quiz>(quizDto);

            await _dbContext.Quizzes.AddAsync(quiz);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetQuizs", new { id = quiz.QuizId }, quiz);
        }

        #endregion

        #region Update Quiz

        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuiz(int id, UpdateQuizDto quizDto)
        {
            if (id != quizDto.Id)
            {
                return BadRequest();
            }


            var quiz = await _dbContext.Quizzes.FindAsync(id);

            if (quiz == null)
            {
                return NotFound();
            }

             _mapper.Map(quizDto, quiz);
            _dbContext.Entry(quiz).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await QuizExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        #endregion

        #region Delete Quiz

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz(int id)
        {
            var quiz = await _dbContext.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            _dbContext.Quizzes.Remove(quiz);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        private async Task<bool> QuizExists(int id)
        {
            return _dbContext.Quizzes.Any(q => q.QuizId == id);
        }

    }
}
