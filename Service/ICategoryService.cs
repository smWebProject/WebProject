using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_Repository;

namespace Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category?>> GetAllCategories();

        //Task<Category?> GetCategories(int?[] categoryIds);
    }
}
