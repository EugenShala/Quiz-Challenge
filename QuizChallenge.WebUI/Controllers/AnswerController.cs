using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuizChallenge.WebUI.Models;
using System.Text;

namespace QuizChallenge.WebUI.Controllers
{
    public class AnswerController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7073/api");
        HttpClient client;

        public AnswerController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }


        public async Task<IActionResult> Index()
        {
            List<Answer> listAnswer = new List<Answer>();
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "/Answer");

            if (response.IsSuccessStatusCode)
            {
                string readstring = await response.Content.ReadAsStringAsync();
                listAnswer = JsonConvert.DeserializeObject<List<Answer>>(readstring);
            }

            return View(listAnswer);
        }



        public IActionResult CreateAnswer()
        {
            Answer answer = new Answer();
            return View(answer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnswer(Answer answer)
        {
            if (!ModelState.IsValid)
            {
                string jsonAnswer = JsonConvert.SerializeObject(answer);
                StringContent content = new StringContent(jsonAnswer, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PostAsync(client.BaseAddress + "/Answer", content);
                if (message.IsSuccessStatusCode)
                {
                    return RedirectPermanent("Index");
                }
            }
            return View();

        }


        public async Task<IActionResult> UpdateAnswer(int Id)
        {

            Answer answerModel = new Answer();

            HttpResponseMessage message = await client.GetAsync(client.BaseAddress + "/Answer/" + Id);
            if (message.IsSuccessStatusCode)
            {
                string jsonAnswer = await message.Content.ReadAsStringAsync();
                answerModel = JsonConvert.DeserializeObject<Answer>(jsonAnswer);

            }
            return View(answerModel);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateAnswer(Answer answer)
        {
            string jsonAnswer = JsonConvert.SerializeObject(answer);
            StringContent content = new StringContent(jsonAnswer, Encoding.UTF8, "application/json");

            HttpResponseMessage message = await client.PutAsync(client.BaseAddress + "/Answer/" + answer.Id, content);

            if (message.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(answer);
        }




        public async Task<IActionResult> DeleteAnswer(int Id)
        {
            HttpResponseMessage message = await client.DeleteAsync(client.BaseAddress + "/Answer/" + Id);
            if (message.IsSuccessStatusCode)

                return RedirectToAction("Index");
            else
                return View();
        }
    }
}
