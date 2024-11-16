using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.BlogDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsAuthorAboutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsAuthorAboutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7190/api/Blogs/GetAuthorByBlogId?id="+id);
            if(response.IsSuccessStatusCode)
            {
                var stringData=await response.Content.ReadAsStringAsync();
                var jsonData=JsonConvert.DeserializeObject<GetAuthorByBlogIdResultDto>(stringData);
                return View(jsonData);
            }
            return View();
        }
    }
}
