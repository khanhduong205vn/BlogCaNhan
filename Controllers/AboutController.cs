using Microsoft.AspNetCore.Mvc;

namespace wweblog.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            // TODO: Hiển thị thông tin cá nhân tác giả
            return View();
        }
    }
}
