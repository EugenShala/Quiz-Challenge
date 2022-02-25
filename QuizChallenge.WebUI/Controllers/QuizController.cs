using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuizChallenge.WebUI.Models;
using System.Net;

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
    }
}
