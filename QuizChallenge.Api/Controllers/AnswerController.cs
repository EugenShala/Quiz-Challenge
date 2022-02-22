using ChallengeDemo.Core.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuizChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerRepository _answerRepository;
        public AnswerController(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }
    }
}
