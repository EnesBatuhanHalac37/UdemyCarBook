using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.CarDtos;
using UdemyCarBook.Dto.FeatureDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class AdminFeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminFeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var data = await client.GetAsync("https://localhost:7190/api/Features");
            if (data.IsSuccessStatusCode)
            {
            var dataStr=await data.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(dataStr);
            return View(jsonData);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var postData = await client.PostAsync("https://localhost:7190/api/Features",stringContent);
            if (postData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult>RemoveFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var data = await client.DeleteAsync($"https://localhost:7190/api/Features/{id}");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var client = _httpClientFactory.CreateClient(); 
            var responseMessage = await client.GetAsync($"https://localhost:7190/api/Features/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
                return View(response);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(dto);
            StringContent stringContent=new StringContent(data,Encoding.UTF8,"application/json");
            var response = await client.PutAsync("https://localhost:7190/api/Features",stringContent);
            return RedirectToAction("Index");
        }
    }
}
