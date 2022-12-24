using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category?>> GetAllCategories();
        //Task<Category?> GetCategories(int?[] categoryIds);
    }
}
