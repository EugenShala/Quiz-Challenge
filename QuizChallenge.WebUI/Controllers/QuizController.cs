using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuizChallenge.WebUI.Models;
using System.Net;
using System.Text;

namespace QuizChallenge.WebUI.Controllers
{
    public class QuizController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7073/api");
        HttpClient client;

        public QuizController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public async Task<IActionResult> Index()
        {
            List<Quiz> listQuiz = new List<Quiz>();
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "/Quiz");

            if (response.IsSuccessStatusCode)
            {
                string readstring = await response.Content.ReadAsStringAsync();
                listQuiz = JsonConvert.DeserializeObject<List<Quiz>>(readstring);
            }

            return View(listQuiz);
        }

        public IActionResult CreateQuiz()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuiz(Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                string jsonQuiz = JsonConvert.SerializeObject(quiz);
                StringContent content = new StringContent(jsonQuiz, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PostAsync(client.BaseAddress + "/Quiz", content);
                if (message.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                    ModelState.AddModelError("Error", "There is an API error");
            }
             return View();   
        }


        public IActionResult UpdateQuiz(int Id)
        {
            Quiz quizModel = new Quiz();

            HttpResponseMessage message = client.GetAsync(client.BaseAddress + "/Quiz/" + Id).Result;
            if (message.IsSuccessStatusCode)
            {
                string jsonQuiz = message.Content.ReadAsStringAsync().Result;
                quizModel = JsonConvert.DeserializeObject<Quiz>(jsonQuiz);

            }
            return View(quizModel);


        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuiz(Quiz quiz)
        {

            string jsonQuiz = JsonConvert.SerializeObject(quiz);
            StringContent content = new StringContent(jsonQuiz, Encoding.UTF8, "application/json");

            HttpResponseMessage message = await client.PutAsync(client.BaseAddress + "/quiz/" + quiz.Id, content);

            if (message.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(quiz);
        }


        public async Task<IActionResult> DeleteQuiz(int Id)
        {
            HttpResponseMessage message = await client.DeleteAsync(client.BaseAddress + "/quiz/" + Id);
            if (message.IsSuccessStatusCode)

                return RedirectToAction("Index");
            else
                return View();
        }
    }
}
