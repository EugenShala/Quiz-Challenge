using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuizChallenge.WebUI.Models;
using System.Text;

namespace QuizChallenge.WebUI.Controllers
{
    public class AnswerController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Answer> listAnswers = new List<Answer>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7073/api/Answer");

            if (response.IsSuccessStatusCode)
            {
                var readstring = await response.Content.ReadAsStringAsync();
                listAnswers = JsonConvert.DeserializeObject<List<Answer>>(readstring);
                return View(listAnswers);
            }

            return View(listAnswers);
        }


        public async Task<IActionResult> CreateAnswer(Answer answer)
        {
            if (!ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                var jsonQuiz = JsonConvert.SerializeObject(answer);
                StringContent content = new StringContent(jsonQuiz, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PostAsync("https://localhost:7073/api/Answer", content);
                if (message.IsSuccessStatusCode)
                {
                    return RedirectPermanent("Index");
                }
                else
                    ModelState.AddModelError("Error", "There is an API error");
                return View(answer);
            }
            else
            {
                return View();
            }
        }


        public async Task<IActionResult> UpdateAnswer(int Id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync("https://localhost:7073/api/Answer/" + Id);
            if (message.IsSuccessStatusCode)
            {
                var jsonAnswer = await message.Content.ReadAsStringAsync();
                Answer answer = JsonConvert.DeserializeObject<Answer>(jsonAnswer);
                return View(answer);

            }
            else
                return RedirectToAction("CreateAnswer");

        }

        [HttpPost]
        public async Task<IActionResult> UpdateAnswer(Answer answer)
        {
            if (!ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                var jsonQuiz = JsonConvert.SerializeObject(answer);
                StringContent content = new StringContent(jsonQuiz, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PutAsync("https://localhost:7073/api/Answer", content);  //https://localhost:7073/api/Answer

                if (message.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                    return View(answer);
            }
            else
                return View(answer);
        }




        public async Task<IActionResult> DeleteAnswer(int Id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.DeleteAsync("https://localhost:7073/api/Answer/" + Id);
            if (message.IsSuccessStatusCode)

                return RedirectToAction("Index");
            else
                return View();
        }
    }
}
