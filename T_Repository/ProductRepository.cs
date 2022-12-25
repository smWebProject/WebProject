using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_Repository
{
    public class ProductRepository:IProductRepository
    {
        WebSiteContext _context;
        public ProductRepository(WebSiteContext context)
        {
            _context = context;
        }
        public async Task<Product?> GetProducts(string name_מ, int? price_from, int? price_to, int?[] categoryIds, int start, int limit, string? direction = "ASC", string? orderBy="price")
        {
            return null;
        }


    }
}
