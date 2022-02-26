using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuizChallenge.WebUI.Models;
using System.Net;
using System.Text;

namespace QuizChallenge.WebUI.Controllers
{
    public class QuizController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Quiz> listQuiz = new List<Quiz>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7073/api/Quiz");

            if (response.IsSuccessStatusCode)
            {
                var readstring = await response.Content.ReadAsStringAsync();
                listQuiz = JsonConvert.DeserializeObject<List<Quiz>>(readstring);
                return View(listQuiz);
            }

            return View(listQuiz);
        }


        public async Task<IActionResult> CreateQuiz(Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                var jsonQuiz = JsonConvert.SerializeObject(quiz);
                StringContent content = new StringContent(jsonQuiz, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PostAsync("https://localhost:7073/api/Quiz", content);
                if (message.IsSuccessStatusCode)
                {
                    return RedirectPermanent("Index");
                }
                else
                    ModelState.AddModelError("Error", "There is an API error");
                return View(quiz);
            }
            else
            {
                return View();
            }
        }


        public async Task<IActionResult> UpdateQuiz(int Id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync("https://localhost:7073/api/Quiz/" + Id);
            if (message.IsSuccessStatusCode)
            {
                var jsonQuiz = await message.Content.ReadAsStringAsync();
                Quiz quiz = JsonConvert.DeserializeObject<Quiz>(jsonQuiz);
                return View(quiz); 

            }
            else
            return RedirectToAction("CreateQuiz");

        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuiz(Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                var jsonQuiz = JsonConvert.SerializeObject(quiz);
                StringContent content = new StringContent(jsonQuiz, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PutAsync("https://localhost:7073/api/Quiz", content);
                if (message.IsSuccessStatusCode)
                {
                    return RedirectPermanent("Index");
                }
                else
                    ModelState.AddModelError("Error", "There is an API error");
                return View(quiz);
            }
            else
            {
                return View(quiz);
            }
        }


        public async Task<IActionResult> DeleteQuiz(int Id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.DeleteAsync("https://localhost:7073/api/Quiz/" + Id);
            if (message.IsSuccessStatusCode)

                return RedirectToAction("Index");
            else
                return View();
        }
    }
}
