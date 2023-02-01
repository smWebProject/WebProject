using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Entities;

namespace Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category?>> GetAllCategories();

    }
}
