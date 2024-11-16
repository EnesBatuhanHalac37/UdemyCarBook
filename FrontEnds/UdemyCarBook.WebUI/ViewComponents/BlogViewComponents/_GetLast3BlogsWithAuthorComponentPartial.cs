using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.BlogDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _GetLast3BlogsWithAuthorComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _GetLast3BlogsWithAuthorComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseData = await client.GetAsync("https://localhost:7190/api/Blogs/GetLast3BlogsWithAuthorList");
            if (responseData.IsSuccessStatusCode)
            {
                var jsonData = await responseData.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<GetLast3BlogWithAuthorResultDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
