using Microsoft.AspNetCore.Mvc;

namespace wweblog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            // Chuyển hướng về trang đăng nhập quản trị
            return RedirectToAction("Login", "Account", new { area = "Admin" });
        }

        public IActionResult Main()
        {
            // Trang chính admin sau khi đăng nhập thành công
            return View();
        }
    }
}
