using Microsoft.AspNetCore.Mvc;
using nhom17.Models;

namespace nhom17.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent
    {
        private readonly Nhom17Context _context;
        public MenuTopViewComponent(Nhom17Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbMenus.Where( m => (bool) m.IsActive).
                OrderBy(m => m.Position).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
