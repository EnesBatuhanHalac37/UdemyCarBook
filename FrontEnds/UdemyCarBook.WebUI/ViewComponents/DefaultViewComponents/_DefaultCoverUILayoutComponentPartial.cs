using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.BannerDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultCoverUILayoutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultCoverUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseData = await client.GetAsync("https://localhost:7190/api/Banners");
            if (responseData.IsSuccessStatusCode)
            {
                var jsonData=await responseData.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
