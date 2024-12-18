﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.BannerDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminBanner")]
    public class AdminBannerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBannerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7190/api/Banners");
            if (response.IsSuccessStatusCode)
            {
                var datastring = await response.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<ResultBannerDto>>(datastring);
                return View(jsonData);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateBanner")]
        public async Task<IActionResult> CreateBanner()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateBanner")] 
        public async Task<IActionResult> CreateBanner(CreateBannerDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7190/api/Banners", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBanner", new {area="Admin"});
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateBanner/{id}")]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var data = await client.GetAsync($"https://localhost:7190/api/Banners/{id}");
            var stringData = await data.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<UpdateBannerDto>(stringData);
            return View(response);
        }

        [HttpPost]
        [Route("UpdateBanner/{id}")]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var postData = await client.PutAsync("https://localhost:7190/api/Banners", content);
            if (postData.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("RemoveBanner/{id}")]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7190/api/Banners?id={id}");
            return RedirectToAction("Index");

        }

    }
}
