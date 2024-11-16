using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.BrandDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class AdminBrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7190/api/Brands");
            if(response.IsSuccessStatusCode)
            {
                var datastring=await response.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<ResultBrandDto>>(datastring);
                return View(jsonData);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent (jsonData,Encoding.UTF8,"application/json");
            var response = await client.PostAsync("https://localhost:7190/api/Brands", content);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrand(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var data = await client.GetAsync($"https://localhost:7190/api/Brands/{id}");
            var stringData = await data.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<UpdateBrandDto>(stringData);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
            var postData =await client.PutAsync("https://localhost:7190/api/Brands", content);
            if(postData.IsSuccessStatusCode)
            {

            return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult>RemoveBrand(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7190/api/Brands/{id}");
            return RedirectToAction("Index");
      
        }

    }
}
