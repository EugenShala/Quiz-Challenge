using Microsoft.AspNetCore.Mvc;

namespace QuizChallenge.WebUI.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateQuestion()
        {
            return View();
        }
    }
}
