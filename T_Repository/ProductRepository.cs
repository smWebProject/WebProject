﻿using Microsoft.EntityFrameworkCore;
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
        public async Task<Product[]> GetProducts(int [] ?categoryIds, string ?name, int? price_from, int? price_to,  int start, int limit, string? direction = "ASC", string? orderBy = "price")
        {

            {
                var query = _context.Products.Where(product => (name == null ? (true) : (product.Description.Contains(name)))
                  && ((price_from == null) ? (true) : (product.Price >= price_from))
                 /*&& (categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.Category))*/
                  && ((price_to == null) ? (true) : (product.Price <= price_to))).OrderBy(product => orderBy);
                Console.WriteLine(query);

                List<Product> products = query.ToList();
                return products.ToArray();

            }
        }


        }
}