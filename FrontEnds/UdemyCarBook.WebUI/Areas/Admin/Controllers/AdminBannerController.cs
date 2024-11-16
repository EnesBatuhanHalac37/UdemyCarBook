using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    public class AdminBannerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
