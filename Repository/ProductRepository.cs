using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        WebSiteContext _context;
        public ProductRepository(WebSiteContext context)
        {
            _context = context;
        }
        public async Task<Product[]> GetProducts(string? name, int? price_from, int? price_to, int[]? categoryIds, int start, int limit, string? direction = "ASC", string? orderBy = "price")
        {
            {
                var qurey = _context.Products.Where(product => (name == null ? (true) : (product.Name.Contains(name)))
             && ((price_from == null) ? (true) : (product.Price >= price_from))
             && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId)))
             && ((price_to == null) ? (true) : (product.Price <= price_to))).OrderBy(product => orderBy);
                Console.WriteLine(qurey);

                List<Product> products = qurey.ToList();
                return products.ToArray();
            }
        }
    }
}
