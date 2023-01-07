using ApiMVCclient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace ApiMVCclient.Controllers
{
    public class TypeController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var responseMessage = client.GetAsync("https://localhost:44311/api/Movie").Result;
            List<MovieType> movieTypes = null;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                movieTypes = JsonConvert.DeserializeObject<List<MovieType>>(responseMessage.Content.ReadAsStringAsync().Result);
            }
            return View(movieTypes);
        }
        public IActionResult Add()
        {

            return View(new MovieType());
        }
        [HttpPost]
        public IActionResult Add(MovieType MovieType)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(MovieType), System.Text.Encoding.UTF8, "application/json");
            var responseMessage = httpClient.PostAsync("https://localhost:44311/api/Movie", content).Result;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Ekleme İşlemi Başarısız");
            return View();
        }
        public IActionResult Edit(int id)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = httpClient.GetAsync($"https://localhost:44311/api/Movie/{id}").Result;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var MovieType = JsonConvert.DeserializeObject<MovieType>(responseMessage.Content.ReadAsStringAsync().Result);
                return View(MovieType);
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Edit(MovieType MovieType)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(MovieType), System.Text.Encoding.UTF8, "application/json");
            var responseMessage = httpClient.PutAsync($"https://localhost:44311/api/Movie/{MovieType.TypeID}", content).Result;
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = httpClient.DeleteAsync($"https://localhost:44311/api/Movie/{id}").Result;
            return RedirectToAction("Index");

        }

    }
}