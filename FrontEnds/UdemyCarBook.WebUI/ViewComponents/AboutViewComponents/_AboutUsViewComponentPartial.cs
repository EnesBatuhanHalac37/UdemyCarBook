using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.AboutDtos;

namespace UdemyCarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsViewComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFacktory;

        public _AboutUsViewComponentPartial(IHttpClientFactory httpClientFacktory)
        {
            _httpClientFacktory = httpClientFacktory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFacktory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7190/api/Abouts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
