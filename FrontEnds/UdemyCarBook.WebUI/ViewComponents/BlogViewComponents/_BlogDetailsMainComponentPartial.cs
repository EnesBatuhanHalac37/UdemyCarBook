using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.BlogDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsMainComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7190/api/Blogs/"+id);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse= await response.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<GetBlogByIdResult>(stringResponse);
                return View(jsonData);
            }
            return View();
        }
    }
}
