using Microsoft.AspNetCore.Mvc;
using wweblog.Data;
using wweblog.Models;
using System.Linq;

namespace wweblog.Controllers
{
    public class PostController : Controller
    {
        private readonly BlogDbContext _context;
        public PostController(BlogDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            // Lấy bình luận theo PostId (demo: id là 1)
            var comments = _context.Comments
                .Where(c => c.PostId == id)
                .OrderByDescending(c => c.CreatedAt)
                .ToList();
            ViewBag.PostId = id;
            ViewBag.Comments = comments;
            return View();
        }

        [HttpPost]
        public IActionResult Index(int id, string email, string content)
        {
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(content))
            {
                var comment = new Comment
                {
                    Email = email,
                    Content = content,
                    CreatedAt = DateTime.Now,
                    PostId = id
                };
                _context.Comments.Add(comment);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", new { id });
        }
    }
}
