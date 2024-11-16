using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.TagCloudDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsTagCloudComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsTagCloudComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7190/api/TagClouds/GetTagCloudListByBlogId?id="+id);
            if(response.IsSuccessStatusCode)
            {
                var jsondata=await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<GetTagCloudByBlogIdDto>>(jsondata);
                return View(data);
            }
            return View();
        }
    }
}
