using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nhom17.Models;

namespace nhom17.Controllers
{
    public class BlogController : Controller
    {
        private readonly Nhom17Context _context;

        public BlogController(Nhom17Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/blog/{alias}-{id}.html")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbBlogs == null)
            {
                return NotFound();
            }

            var blog = await _context.TbBlogs.FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }

            ViewBag.blogComment = _context.TbBlogComments.Where(i => i.BlogId == id).ToList();
            return View(blog);

        }

    }
}
