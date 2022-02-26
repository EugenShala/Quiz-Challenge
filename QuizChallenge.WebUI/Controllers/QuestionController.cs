using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuizChallenge.WebUI.Models;
using QuizChallenge.WebUI.Models.View_Models;
using System.Text;

namespace QuizChallenge.WebUI.Controllers
{
    public class QuestionController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync("https://localhost:7073/api/Question");
            if (message.IsSuccessStatusCode)
            {
                var questionJson = await message.Content.ReadAsStringAsync();
                List<Question> list = JsonConvert.DeserializeObject<List<Question>>(questionJson);
                return View(list);
            }
            else
            return View(new List<Question>());
        }

        public IActionResult CreateQuestion()
        {
            Question question = new Question();
            return View(question);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(Question question)
        {
            if (!ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                var jsonQuiz = JsonConvert.SerializeObject(question);
                StringContent content = new StringContent(jsonQuiz, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PostAsync("https://localhost:7073/api/Question", content);
                if (message.IsSuccessStatusCode)
                {
                    return RedirectPermanent("Index");
                }
                else
                    ModelState.AddModelError("Error", "There is an API error");
                return View(question);
            }
            else
            {
                return View();
            }
         
        }
    }
}
