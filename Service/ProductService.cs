using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_Repository;
using Entities;

namespace Service
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _iProductRepository;
        public ProductService(IProductRepository iProductRepository)
        {
            _iProductRepository = iProductRepository;
        }

        public async Task<Product[]> GetProducts(string ?name, int? price_from, int? price_to, int[] ?categoryIds, int start, int limit, string? direction = "ASC", string? orderBy = "price")
        {
            var product = await _iProductRepository.GetProducts(name, price_from,price_to, categoryIds,start, limit,direction , orderBy);
            if (product != null)
                return product;
            return null;
        }

     
    }
}
