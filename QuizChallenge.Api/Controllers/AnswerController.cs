using AutoMapper;
using ChallengeDemo.Core.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizChallenge.Core.DataTransferObject;
using QuizChallenge.Core.DataTransferObject.AnswerDtos;
using QuizChallenge.Core.Entities;

namespace QuizChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;
        protected ResponseDto responseDto;

        public AnswerController(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            this._mapper = mapper;
            responseDto = new ResponseDto();
        }

        #region Read Only Answers


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadAnswerDto>>> GetAnswers()
        {
            try
            {
                var answerModel = await _answerRepository.GetAllAnswers();
                var answerDto = _mapper.Map<IEnumerable<ReadAnswerDto>>(answerModel);
                responseDto.Result = answerDto;
                return Ok(answerDto);
            }
            catch (Exception ex)
            {
                responseDto.Success = false;
                return StatusCode(500, responseDto.Error = new List<string>() { ex.ToString() });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnswerDetailsDto>> GetAnswerDetails(int id)
        {
            try
            {
                var answer = await _answerRepository.GetAnswerDetails(id);

                if (answer == null)
                {
                    return NotFound();
                }

                responseDto.Result = answer;
                return Ok(answer);
            }

            catch (Exception ex)
            {
                responseDto.Success = false;
                return StatusCode(500, responseDto.Error = new List<string>() { ex.ToString() });
            }
        }


        #endregion


        #region Create Answer

        [HttpPost]
        public async Task<ActionResult<CreateAnswerDto>> PostAnswer(CreateAnswerDto createAnswerDto)
        {
            try
            {
                var answer = _mapper.Map<Answer>(createAnswerDto);
                await _answerRepository.AddAnswer(answer);
                responseDto.Result = createAnswerDto;

                return CreatedAtAction("GetAnswers", new { id = answer.Id }, createAnswerDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, responseDto.Error = new List<string>() { ex.ToString() });
            }
        }

        #endregion


        #region Update Answer


        [HttpPut("{id}")]
        public async Task<ActionResult> PutAnswer(int id, UpdateAnswerDto updateAnswerDto)
        {
            try
            {
                if (id != updateAnswerDto.Id)
                {
                    return BadRequest();
                }

                var answer = await _answerRepository.GetAnswerById(id);
                if (answer == null)
                {
                    return NotFound();
                }

                _mapper.Map(updateAnswerDto, answer);
                await _answerRepository.UpdateAnswer(answer);
                responseDto.Result = updateAnswerDto;

            }
            catch (Exception ex )
            {
                if (!await HasAnswer(id))
                {
                    return NotFound();
                }
                else
                {
                    responseDto.Success = false;
                    return StatusCode(500, responseDto.Error = new List<string>() { ex.ToString(), ex.ToString() });
                }
            }

            return NoContent();
        }


        #endregion


        #region Remove Answer


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            try
            {
                var answer = await _answerRepository.GetAnswerById(id);
                if (answer == null)
                {
                    return NotFound();
                }

                await _answerRepository.DeleteAnswer(id);

                responseDto.Result = answer;
                return Ok(answer);
            }
            catch (Exception ex)
            {
                responseDto.Success = false;
                return StatusCode(500, responseDto.Error = new List<string>() { ex.ToString() });
            }
        }

        #endregion


        private async Task<bool> HasAnswer(int id)
        {
            return await _answerRepository.HasAnswer(id);
        }
    }
}
