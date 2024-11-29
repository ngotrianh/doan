using Microsoft.AspNetCore.Mvc;
using nhom17.Models;

namespace nhom17.Controllers
{
    public class ContactController : Controller
    {

        private readonly Nhom17Context _context;

        public ContactController(Nhom17Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(string name,string phone,string email,string message)
        {
            try
            {
                TbContact contact = new TbContact();
                contact.Name = name;
                contact.Phone = phone;
                contact.Email = email;
                contact.Message = message;
                contact.CreatedDate = DateTime.Now;
                _context.Add(contact);
                _context.SaveChangesAsync();
                return Json(new { status = true });
            }
            catch
            {
                return Json(new {status = false });
            }
        }
    }
}
