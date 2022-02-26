using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuizChallenge.WebUI.Models;
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
                var jsonQuestion = JsonConvert.SerializeObject(question);
                StringContent content = new StringContent(jsonQuestion, Encoding.UTF8, "application/json");
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



        public async Task<IActionResult> UpdateQuestion(int Id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync("https://localhost:7073/api/Question/" + Id);
            if (message.IsSuccessStatusCode)
            {
                var jsonQuestion = await message.Content.ReadAsStringAsync();
                Question question = JsonConvert.DeserializeObject<Question>(jsonQuestion);
                return View(question);

            }
            else
                return RedirectToAction("CreateQuestion");

        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuestion(Question question)
        {
            if (!ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                var jsonQuestion = JsonConvert.SerializeObject(question);
                StringContent content = new StringContent(jsonQuestion, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PutAsync("https://localhost:7073/api/Question", content);

                if (message.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(question);
                }
            }
            else
                return View(question);
        }



        public async Task<IActionResult> DeleteQuestion(int Id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.DeleteAsync("https://localhost:7073/api/Question/" + Id);
            if (message.IsSuccessStatusCode)

                return RedirectToAction("Index");
            else
                return View();
        }

    }
}
