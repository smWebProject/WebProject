using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace T_Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        WebSiteContext _context;
        public CategoryRepository(WebSiteContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category?>> GetAllCategories()
        {
            List<Category> Categorys = await _context.Categories
              .Include(category => category.Products).ToListAsync();
            return Categorys;
        }
    }
}
