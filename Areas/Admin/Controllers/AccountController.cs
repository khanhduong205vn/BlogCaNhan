using Microsoft.AspNetCore.Mvc;

namespace wweblog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            // TODO: Replace with real authentication logic
            if (Username == "admin" && Password == "admin")
            {
                // Đăng nhập thành công, chuyển đến dashboard admin
                return RedirectToAction("Main", "Dashboard", new { area = "Admin" });
            }
            // Sai thì hiển thị lại trang đăng nhập với thông báo lỗi
            ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không đúng.";
            return View();
        }
    }
}
