using AutoMapper;
using ChallengeDemo.Core.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizChallenge.Core.DataTransferObject;
using QuizChallenge.Core.DataTransferObject.AnswerDtos;

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
    }
}
