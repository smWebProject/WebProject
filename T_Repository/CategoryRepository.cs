using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var list = await (from c in _context.Categories
                              select c).ToListAsync();

            //foreach (var category in list)
            //{
            //    foreach (var item in _context.Products)
            //    {
            //        if (item.CategoryId==category.Id)
            //        {
            //             category.Products.Add(item);
            //        }
            //    }
            //}

            return list;
        }
        //public async Task<Category?> GetCategories(int?[] categoryIds)
        //{
        //    return null;
        //}
    }
}
