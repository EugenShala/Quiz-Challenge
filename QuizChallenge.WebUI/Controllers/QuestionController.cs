using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuizChallenge.WebUI.Models;
using System.Text;

namespace QuizChallenge.WebUI.Controllers
{
    public class QuestionController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:7073/api");
        HttpClient client;

        public QuestionController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }


        public async Task<IActionResult> Index()
        {
            List<Question> listQuestion = new List<Question>();
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "/Question");

            if (response.IsSuccessStatusCode)
            {
                string readstring = await response.Content.ReadAsStringAsync();
                listQuestion = JsonConvert.DeserializeObject<List<Question>>(readstring);
            }

            return View(listQuestion);
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
                string jsonQuestion = JsonConvert.SerializeObject(question);
                StringContent content = new StringContent(jsonQuestion, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PostAsync(client.BaseAddress + "/Question", content);
                if (message.IsSuccessStatusCode)
                {
                    return RedirectPermanent("Index");
                }
            }
                return View();
         
        }



        public async Task<IActionResult> UpdateQuestion(int Id)
        {

            Question quizModel = new Question();

            HttpResponseMessage message = await client.GetAsync(client.BaseAddress + "/Question/" + Id);
            if (message.IsSuccessStatusCode)
            {
                string jsonQuestion = await message.Content.ReadAsStringAsync();
                quizModel = JsonConvert.DeserializeObject<Question>(jsonQuestion);

            }
            return View(quizModel);


        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuestion(Question question)
        {
            string jsonQuestion = JsonConvert.SerializeObject(question);
            StringContent content = new StringContent(jsonQuestion, Encoding.UTF8, "application/json");

            HttpResponseMessage message = await client.PutAsync(client.BaseAddress + "/Question/" + question.Id, content);

            if (message.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(question);
        }



        public async Task<IActionResult> DeleteQuestion(int Id)
        {
            HttpResponseMessage message = await client.DeleteAsync(client.BaseAddress + "/Question/" + Id);
            if (message.IsSuccessStatusCode)

                return RedirectToAction("Index");
            else
                return View();
        }

    }
}
