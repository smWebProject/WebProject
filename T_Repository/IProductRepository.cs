using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_Repository
{
    public interface IProductRepository
    {
        Task<Product[]> GetProducts(int[]? categoryIds,string? name, int? price_from, int? price_to, int start, int limit, string? direction = "ASC", string? orderBy = "price");

    }
}
