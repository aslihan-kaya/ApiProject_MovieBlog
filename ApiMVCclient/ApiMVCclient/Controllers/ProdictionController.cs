using ApiMVCclient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace ApiMVCclient.Controllers
{
    public class ProdictionController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var responseMessage = client.GetAsync("https://localhost:44311/api/Movie").Result;
            List<ProductionCompany> ProductionCompanys = null;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ProductionCompanys = JsonConvert.DeserializeObject<List<ProductionCompany>>(responseMessage.Content.ReadAsStringAsync().Result);
            }
            return View(ProductionCompanys);
        }
        public IActionResult Add()
        {

            return View(new ProductionCompany());
        }
        [HttpPost]
        public IActionResult Add(ProductionCompany ProductionCompany)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(ProductionCompany), System.Text.Encoding.UTF8, "application/json");
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
                var ProductionCompany = JsonConvert.DeserializeObject<ProductionCompany>(responseMessage.Content.ReadAsStringAsync().Result);
                return View(ProductionCompany);
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Edit(ProductionCompany ProductionCompany)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(ProductionCompany), System.Text.Encoding.UTF8, "application/json");
            var responseMessage = httpClient.PutAsync($"https://localhost:44311/api/Movie/{ProductionCompany.ID}", content).Result;
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