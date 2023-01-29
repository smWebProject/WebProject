using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<Product[]> GetProducts(string? name, int? price_from, int? price_to, int[]? categoryIds, int start, int limit, string? direction = "ASC", string? orderBy = "price");

    }
}
