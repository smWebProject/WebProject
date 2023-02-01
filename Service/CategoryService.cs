using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace Service
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _iCategoryRepository;
        public CategoryService(ICategoryRepository iCategoryRepository)
        {
            _iCategoryRepository = iCategoryRepository;
        }

        public async Task<IEnumerable<Category?>> GetAllCategories()
        {
            var categories = await _iCategoryRepository.GetAllCategories();
            if (categories != null)
                return categories;
            return null;
        }

    }
}
