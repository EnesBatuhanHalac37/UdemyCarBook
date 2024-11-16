using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.CarDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultLast5CarsWithBrandsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultLast5CarsWithBrandsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7190/api/Cars/GetLast5CarsWithBrand");
            if(response.IsSuccessStatusCode)
            {
                var responseData=await response.Content.ReadAsStringAsync();
                var jsonData=JsonConvert.DeserializeObject<List<ResultGetLastFiveCarsWithBrandDto>>(responseData);
                return View(jsonData);
            }
            return View();

        }
    }
}
