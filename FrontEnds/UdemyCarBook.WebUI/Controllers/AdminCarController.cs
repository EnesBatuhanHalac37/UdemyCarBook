using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.BrandDtos;
using UdemyCarBook.Dto.CarDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7190/api/Cars/GetCarsWithBrand");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7190/api/Brands");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
            List<SelectListItem> brandValues = (from i in values
                                                select new SelectListItem
                                                {
                                                    Text = i.Name,
                                                    Value = i.BrandID.ToString()
                                                }).ToList();
            ViewBag.BrandValues=brandValues;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>CreateCar(CreateCarDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(dto);
            var stringContent = new StringContent(data,Encoding.UTF8,"application/json");
            var postdata = await client.PostAsync("https://localhost:7190/api/Cars", stringContent);
            if(postdata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var removeData = await client.DeleteAsync($"https://localhost:7190/api/Cars/{id}");
            if(removeData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseBrand = await client.GetAsync("https://localhost:7190/api/Brands");
            var dataBrand=await responseBrand.Content.ReadAsStringAsync();
            var valuesBrand = JsonConvert.DeserializeObject<List<ResultBrandDto>>(dataBrand);
            List<SelectListItem> brandList = (from i in valuesBrand
                                              select new SelectListItem
                                              {
                                                  Text = i.Name,
                                                  Value = i.BrandID.ToString()
                                              }).ToList();
            ViewBag.BrandValues = brandList;






            var responseMessage = await client.GetAsync($"https://localhost:7190/api/Cars/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
                return View(response);
            }
            return View(); 
        }


        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCar)
        {
            var client= _httpClientFactory.CreateClient();
            var dataJson=JsonConvert.SerializeObject(updateCar);
            var stringContent=new StringContent(dataJson,Encoding.UTF8,"application/json");
            var postdata = await client.PutAsync("https://localhost:7190/api/Cars/", stringContent);
            if(postdata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
