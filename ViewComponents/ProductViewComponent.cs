using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nhom17.Models;

namespace nhom17.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly Nhom17Context _context;
       
        public ProductViewComponent(Nhom17Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbProducts.Include(m => m.CategoryProduct)
                .Where(m => (bool)m.IsActive).Where(m => m.IsNew);
            return await Task.FromResult<IViewComponentResult>
                (View(items.OrderByDescending(m => m.ProductId).ToList()));
        }
    }
}
